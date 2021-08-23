using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace udp_ns
{
    public class Udp
    {
        private UdpClient udpPAD;
        private IPEndPoint ipepSendToRemote;                //对端节点的IP地址和端口
        private static Udp udp;

        private string strGLocalIP = Chat2021.Network.Resource.localIP;
        private int iGLocalPort= Convert.ToInt32(Chat2021.Network.Resource.Port);
        /// <summary>
        /// 构造函数，主要是构建对方UDP点的节点信息
        /// </summary>
        private Udp(){ }

        public static Udp GetInstance()
        {
            if(null == udp)
            {
                udp = new Udp();
            }
            return udp;
        }

        /// <summary> 
        /// 在后台运行的接收线程 
        /// </summary> 
        public void ReceiveData()
        {
            IPEndPoint ipepListen=null;
            try
            {
                ipepListen = new IPEndPoint(IPAddress.Any, 0);         //监听的远端网络端点
                IPAddress ipaddPAD = IPAddress.Parse(strGLocalIP);
                IPEndPoint ipepLocal = new IPEndPoint(ipaddPAD, iGLocalPort);                      //绑定的本地网络端点
                udpPAD = new UdpClient(ipepLocal);                //初始化udp
            }
            catch (Exception e)
            {
                if (OpenUDPError != null)
                {
                    OpenUDPError(new OpenUDPErrorArgs(e.ToString()));
                }
                return ;
            }
            if (OpenUDPSuccess != null)
            {
                OpenUDPSuccess(new OpenUDPSuccessArgs());
            }
            //接收从远程主机发送过来的信息
            while (true)
            {
                try
                {
                    //关闭udpClient时此句会产生异常 
                    byte[] bytes = udpPAD.Receive(ref ipepListen);
                    //string str = System.Text.Encoding.Default.GetString(bytes); //Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    //此处激发事件：MessageArrive，可以在类的对象的MessageArrive事件中实现想要的操作

                    //ModifyStruct modifyStruct = (ModifyStruct)ByteToStruct(bytes, typeof(ModifyStruct));
                    if (MessageArrive != null)
                    {
                        MessageArrive(new MessageArriveEventArgs(bytes));
                    }
                }
                catch (SocketException e)          //关闭udpPAD时会发生这个错误
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


        /// <summary>
        /// 发送数据到远程主机 
        /// </summary>
        /// <param name="strSendData">需要发送的字符串</param>
        public void SendData(string strRemouteIP,int iRemotePort,string strSendData)
        {
            IPAddress RemoteIP;
            if (!IPAddress.TryParse(strRemouteIP, out RemoteIP))
            {
                MessageBox.Show("远程IP地址格式有误");
                return;
            }
            ipepSendToRemote = new IPEndPoint(RemoteIP, iRemotePort);

            byte[] bytes = System.Text.Encoding.Default.GetBytes(strSendData);//System.Text.Encoding.UTF8.GetBytes(strSendData);
            try
            {
                udpPAD.Send(bytes, bytes.Length, ipepSendToRemote);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 发送数据到远程主机 
        /// </summary>
        /// <param name="bytarySendData">需要发送的byte数组</param>
        public void SendData(byte[] bytarySendData)
        {
            try
            {
                udpPAD.Send(bytarySendData, bytarySendData.Length, ipepSendToRemote);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 关闭UDP
        /// </summary>
        public void CloseUDP()
        {
            if (udpPAD != null)
            {
                udpPAD.Close();
            }
        }

        public event OpenUDPErrorHandler OpenUDPError;
        public event OpenUDPSuccessHandler OpenUDPSuccess;
        public event MessageArriveHandler MessageArrive;
    }

    //以下定义MessageArrive事件相关
    public class MessageArriveEventArgs
    {
        public byte[] message;
        public MessageArriveEventArgs(byte[] bytary)
        {
            message = bytary;
        }
    }
    public delegate void MessageArriveHandler(MessageArriveEventArgs e);

    public class OpenUDPSuccessArgs
    {
    }
    public delegate void OpenUDPSuccessHandler(OpenUDPSuccessArgs e);

    //以下定义OpenUDPError事件相关
    public class OpenUDPErrorArgs
    {
        public string error;
        public OpenUDPErrorArgs(string str)
        {
            error = str;
        }
    }
    public delegate void OpenUDPErrorHandler(OpenUDPErrorArgs e);
}
