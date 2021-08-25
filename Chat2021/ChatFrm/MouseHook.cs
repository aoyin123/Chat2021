using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Chat2021.MainFrm;

namespace HookSpace
{
    public class MousePosEventArgs
    {
        public Point mousePos;
        public MousePosEventArgs(Point mousePos)
        {
            this.mousePos = mousePos;
        }
    }

    public delegate void MouseClickHandler(MousePosEventArgs mousePos);
    public delegate void MouseMoveHandler(MousePosEventArgs mousePos);

    class MouseHook
    {
        private const int WM_MOUSEMOVE   = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP   = 0x202;
        private const int WM_RBUTTONUP   = 0x205;
        private const int WM_MBUTTONUP   = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;
        public const int WH_MOUSE_LL = 14; // mouse hook constant
        public int MouseStatus = 0;
        private static MouseHook mouseHook;
        public MouseMoveHandler mouseMoveEvent;
        public MouseClickHandler mouseClickEvent;

        // 关闭按钮点击回调函数
        public delegate void CloseProc();
        public CloseProc closeEvent;
        public delegate void MiniProc();
        public MiniProc miniEvent;

        /// <summary>
        /// 点
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        

        /// <summary>
        /// 钩子结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        // 装置钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        // 卸下钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("kernel32")]
        public static extern uint GetLastError();

          // 下一个钩挂的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        // 全局的鼠标事件
        //public static event MouseEventHandler OnMouseActivity;


        // 钩子回调函数
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        // 声明鼠标钩子事件类型
        private HookProc _mouseHookProcedure;
        private static int _hMouseHook = 0; // 鼠标钩子句柄
        
        /// <summary>
        /// 构造函数
        /// </summary>
        private MouseHook()
        {
            Start();
            //this.form = form;
        }

        public static MouseHook GetInstance()
        {
            if(null == mouseHook)
            {
                mouseHook = new MouseHook();
            }
            return mouseHook;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~MouseHook()
        {
            Stop();
        }



        private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
            int x = MyMouseHookStruct.pt.x;
            int y = MyMouseHookStruct.pt.y;
            Point mousePos = new Point(x, y);

            //因为透明界面可能有部分区域不响应MouseDown事件，所以用MouseHook来捕捉鼠标按下事件
            //if(MoreBtn.ValidRegion.Contains(mousePos))
            //{
            //    MouseStatus = 1;
            //    //form.Invalidate(); 
            //}
            //else if(CloseBtn.ValidRegion.Contains(mousePos))
            //{
            //    MouseStatus = 2;
            //    //form.Invalidate();
            //}
            //else if(MiniFrmBtn.ValidRegion.Contains(mousePos)) 
            //{
            //    MouseStatus = 3;
            //    //form.Invalidate();
            //}
            //else
            //{
            //    MouseStatus = 0;
            //    //form.Invalidate();
            //}
            mouseMoveEvent(new MousePosEventArgs(mousePos));
            if ((nCode >= 0))
            {
                MouseButtons button = MouseButtons.None;
                int clickCount = 0;
                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                        //if(MouseStatus == 2)
                        //{
                        //    closeEvent();
                        //    return 1;
                        //}
                        //else if(MouseStatus == 3)
                        //{
                        //    miniEvent();
                        //    return 1;
                        //}
                        //else if(MouseStatus == 1)
                        //{

                        //}
                        mouseClickEvent(new MousePosEventArgs(mousePos));
                        button = MouseButtons.Left;
                        clickCount = 1;
                        break;
                    case WM_LBUTTONUP:
                        if (MouseStatus != 0)
                        {
                            return 1;
                        }
                        button = MouseButtons.Left;
                        clickCount = 1;
                        break;
                    case WM_LBUTTONDBLCLK:
                        if (MouseStatus != 0)
                        {
                            return 1;
                        }
                        button = MouseButtons.Left;
                        clickCount = 2;
                        break;
                    case WM_RBUTTONDOWN:
                        if (MouseStatus != 0)
                        {
                            return 1;
                        }
                        button = MouseButtons.Right;
                        clickCount = 1;
                        break;
                    case WM_RBUTTONUP:
                        if (MouseStatus != 0)
                        {
                            return 1;
                        }
                        button = MouseButtons.Right;
                        clickCount = 1;
                        break;
                    case WM_RBUTTONDBLCLK:
                        if (MouseStatus != 0)
                        {
                            return 1;
                        }
                        button = MouseButtons.Right;
                        clickCount = 2;
                        break;
                }  
  
                
                MouseEventArgs e = new MouseEventArgs(button, clickCount, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);
            }
            return CallNextHookEx(_hMouseHook, nCode, wParam, lParam); 
        }

        [DllImport("Kernel32")]
        public static extern int LoadLibraryW(String funcname);
         /// <summary>
        /// 启动全局钩子
        /// </summary>
        public void Start()
        {
            // 安装鼠标钩子
            if (_hMouseHook == 0)
            {
                // 生成一个HookProc的实例.
                _mouseHookProcedure = new HookProc(MouseHookProc);
                uint p = GetLastError();
                IntPtr mar = (IntPtr)LoadLibraryW("user32.dll");
                //_hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookProcedure, Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                _hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookProcedure, mar, 0);
                //如果装置失败停止钩子
                if (_hMouseHook == 0)
                {
                    uint n = GetLastError();
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }
        }


        /// <summary>
        /// 停止全局钩子
        /// </summary>
        public void Stop()
        {
            bool retMouse = true;
 
            if (_hMouseHook != 0)
            {
                retMouse    = UnhookWindowsHookEx(_hMouseHook);
                uint n = GetLastError();
                _hMouseHook = 0;
            }
        }

    }
}
