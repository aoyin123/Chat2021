using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Chat2021.pool
{
    /// <summary>
    /// 线程池工作函数委托
    /// </summary>
    /// <param name="item"></param>
    public delegate void PoolWork(object item);
    public class ThreadPoolWork
    {
        /// <summary>
        /// 线程池大小
        /// </summary>
        private int _pool_size;//线程池大小
        /// <summary>
        /// 线程状态
        /// </summary>
        private int _pool_state = 1;//线程状态
        /// <summary>
        /// 工作中
        /// </summary>
        private int _work_run = 0;//工作中
        /// <summary>
        /// 闲置线程数
        /// </summary>
        private int _work_leave = 0;//闲置的工作线程
        /// <summary>
        /// 等待执行的任务数
        /// </summary>
        private int _work_wait = 0;//等待执行的任务数量
        /// <summary>
        /// 等待超时
        /// </summary>
        private int _work_timeout;//等待超时
        /// <summary>
        /// 工作任务列队
        /// </summary>
        private Queue<PoolItem> _pool_item = new Queue<PoolItem>();//工作任务列队
        /// <summary>
        /// 工作线程集合
        /// </summary>
        private List<Thread> _pool_thread = new List<Thread>();//工作线程集合
        /// <summary>
        /// 工作信号
        /// </summary>
        private Semaphore _semaphore_work;//工作信号

        /// <summary>
        /// 监控线程
        /// </summary>
        private Thread _monitor;//监控线程
        /// <summary>
        /// 设置或读取线程池的并发数
        /// </summary>
        public int Pool_size { get => _pool_size; set => Interlocked.Exchange(ref _pool_size, value); }
        /// <summary>
        /// 正在工作的线程数
        /// </summary>
        public int Work_run { get => _work_run; }
        /// <summary>
        /// 处于闲置的线程数
        /// </summary>
        public int Work_leave { get => _work_leave; }
        /// <summary>
        /// 等待处理的任务数
        /// </summary>
        public int Work_wait { get => _work_wait; }
        /// <summary>
        /// 设置或读取工作线程等待超时
        /// </summary>
        public int Work_timeout { get => _work_timeout; set => Interlocked.Exchange(ref _work_timeout, value); }
        /// <summary>
        /// 启动线程池
        /// </summary>
        /// <param name="size">线程池大小</param>
        /// <param name="timeout">工作线程最大等待时间</param>
        /// <returns></returns>
        public bool Start(int size, int timeout = 5000)
        {
            if (_monitor != null)
            {//如果监控线程不为空
                return false;
            }
            _semaphore_work = new Semaphore(0, Int32.MaxValue);//工作信号
            //_semaphore_monitor = new Semaphore(0, Int32.MaxValue);//监控信号

            Interlocked.Exchange(ref _pool_state, 1);//设置线程状态为正常运行

            //设置线程池大小
            _pool_size = size;
            //设置等待超时
            _work_timeout = timeout;
            //创建监控线程
            _monitor = new Thread(MonitorThread);
            _monitor.Name = "监控线程";
            _monitor.IsBackground = true;
            _monitor.Start();
            return true;
        }
        /// <summary>
        /// 监控线程
        /// </summary>
        private void MonitorThread()
        {  
            Thread thread;
            while (_pool_state == 1)
            {
                while (_work_leave == 0 && _work_run < _pool_size && _work_wait > 0)
                {
                    thread = new Thread(WorkThread); //创建新的工作线程
                    Interlocked.Add(ref _work_run, 1);//工作中+1
                    thread.Start();//运行新创建的工作线程
                    lock (_pool_thread)
                    {
                        _pool_thread.Add(thread);//添加到工作线程集合
                    }
                    Thread.Sleep(10);
                }
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// 工作执行线程
        /// </summary>
        private void WorkThread()
        {
            PoolItem poolItem;
            Interlocked.Add(ref _work_leave, 1);//闲置线程+1
            while (_semaphore_work.WaitOne(_work_timeout) && _pool_state == 1) //循环等待工作信号且线程池状态为正常
            {              
                Interlocked.Decrement(ref _work_wait);//等待执行的任务-1
                lock (_pool_item)
                {
                    poolItem = _pool_item.Dequeue();//取出任务
                }
                Interlocked.Decrement(ref _work_leave);//闲置线程-1
                poolItem.PoolWork(poolItem.Item);//执行任务
                Interlocked.Add(ref _work_leave, 1);//闲置线程+1

                if (_work_run > _pool_size)//如果线程过大
                {
                    break;
                }
            }
            Interlocked.Decrement(ref _work_run);//工作中-1
            Interlocked.Decrement(ref _work_leave);//闲置线程-1
            lock (_pool_thread)
            {
                _pool_thread.Remove(Thread.CurrentThread);//把运行完的工作线程从集合中删掉
            }
            Thread.CurrentThread.Abort();
        }
        /// <summary>
        /// 加入工作(压入一个任务)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void ADD(PoolItem item)
        {
            lock (_pool_item)
            {
                _pool_item.Enqueue(item);//把参数加入到工作任务列队
            }
            _semaphore_work.Release();//发送任务信号
            Interlocked.Add(ref _work_wait, 1);//等待处理的任务+1
        }
        /// <summary>
        /// 挂起线程池
        /// </summary>
        public void Suspend()
        {
            lock (_pool_thread)
            {
                foreach (Thread item in _pool_thread)
                {
                    item.Suspend();
                }
            }
        }
        /// <summary>
        /// 恢复线程池
        /// </summary>
        public void Resume()
        {
            lock (_pool_thread)
            {
                foreach (Thread item in _pool_thread)
                {
                    if (item.ThreadState == ThreadState.Suspended)
                    {
                        item.Resume();
                    }
                    else
                    {
                        break;
                    }
                    //item.ThreadState;
                    
                }
            }
        }
        /// <summary>
        /// 销毁线程
        /// </summary>
        public void Abort()
        {
            Interlocked.Exchange(ref _pool_state, 0);//设置线程状态为非正常运行
            _monitor.Abort();//终止监控线程
            _pool_item.Clear();//清除所有的任务
            lock (_pool_thread)//终止所有工作线程
            {
                foreach (Thread item in _pool_thread)
                {
                    item.Abort();
                }
                _pool_thread.Clear();//清除所有的线程
            }
            _semaphore_work.Close();//清理工作信号
            Interlocked.Exchange(ref _work_run, 0);//重置工作中数量
            Interlocked.Exchange(ref _work_leave, 0);//重置闲置的线程数量
            Interlocked.Exchange(ref _work_wait, 0);//重置等待执行的任务数据
            _monitor = null;
        }
    }
    /// <summary>
    /// 任务参数表
    /// </summary>
    public struct PoolItem
    {
        public PoolWork PoolWork;
        public object Item;
    }
}
