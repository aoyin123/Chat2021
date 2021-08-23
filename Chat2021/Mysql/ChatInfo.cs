using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chat2021.Mysql
{

    public class LayoutItem
    {
        public static Font msgFont = new Font("宋体", 10);
        public static SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
        public string typeFace;
        public int fontSize;

        public string msg;
        public string tag;

        public Size msgSize;
        public Size headSize;

        public Point msgPos;
        public Point headPos;

        public int top;
        public int end;

        public LayoutItem(string msg, string tag)
        {
            msgSize = new Size();
            headSize = new Size();
            msgPos = new Point();
            headPos = new Point();

            this.tag = tag;
            this.msg = msg;
        }
    }

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
}
