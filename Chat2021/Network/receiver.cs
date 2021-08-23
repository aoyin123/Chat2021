using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chat2021.Mysql;
using udp_ns;

namespace Chat2021.Network
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ModifyStruct
    {
        public int index;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string head;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string msg;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string tableName;
    }

    public class ModifyStructEventArgs
    {
        public ModifyStruct modifyStruct;
        public ModifyStructEventArgs(ModifyStruct modifyStruct)
        {
            this.modifyStruct = modifyStruct;
        }
    }
    public delegate void ModifyStructEventHandler(ModifyStructEventArgs e);

    class Receiver
    {
        #region field
        private Mysql.Mysql mysql = Mysql.Mysql.getInstance();
        private Udp udp = Udp.GetInstance();
        private Thread thdUDPListen;
        public event ModifyStructEventHandler DataArrive;
        private static Receiver receiver;
        #endregion

        //construct
        private Receiver()
        {
            thdUDPListen = new Thread(new ThreadStart(udp.ReceiveData));
            thdUDPListen.IsBackground = true;           //将线程设为后台运行 
            thdUDPListen.Start();

            udp.MessageArrive += GetModifyStruct;
        }

        public static Receiver GetInstance()
        {
            if(null == receiver)
            {
                receiver = new Receiver();
            }
            return receiver;
        }

        //method
        public static object ByteToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }

            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, structPtr, size);
            object obj = Marshal.PtrToStructure(structPtr, type);
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        public void GetModifyStruct(MessageArriveEventArgs e)
        {
            ModifyStruct modifyStruct = (ModifyStruct)ByteToStruct(e.message, typeof(ModifyStruct));
            DataArrive(new ModifyStructEventArgs(modifyStruct));
        }

        //destruct
        ~Receiver()
        {
            udp.CloseUDP();
        }
    }
}
