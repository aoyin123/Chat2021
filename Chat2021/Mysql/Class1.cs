using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Chat2021.Mysql
{
    class Mysql
    {
        #region fields
        private static Mysql instance;
        private MySqlConnection conn;
        #endregion

        #region construct

        private Mysql(){}

        #endregion

        #region method

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns>Mysql类实例</returns>
        public static Mysql getInstance()
        {
            if (instance == null)
            {
                instance = new Mysql();
            }
            return instance;
        }

        /// <summary>
        /// 连接mysql数据库 
        /// </summary>
        /// <returns>成功返回true，失败返回false</returns>
        public bool Connect()
        {
            if(conn != null)
            {
                return true;
            }

            string connstr = "server = 127.0.0.1; port = 3306; user = root ; password = ROS123; database = qqaccountdb; charset=utf8";
            conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "数据库连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 从mysql数据库中取出聊天记录
        /// </summary>
        /// <returns></returns>
        public List<LayoutItem> GetChatRecord()
        {
            MySqlCommand cmd;
            MySqlDataReader reader;
            string str1, str2, sql;
            List<LayoutItem> layoutItems = new List<LayoutItem>();


            sql = "use chatrecord;";
            cmd = new MySqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            reader.Close();

            sql = "select * from 11abc";
            cmd = new MySqlCommand(sql, conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    str1 = reader[0].ToString();
                    str2 = reader[1].ToString();
                    layoutItems.Add(new LayoutItem(str1, str2));
                }
            }
            reader.Close();
           
            return layoutItems;
        }

        /// <summary>
        /// 登陆验证，查询账号密码是否正确
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userName">密码</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool LoginVerify(string userName, string pwd)
        {
            string sql = "select * from accountInfo where username='" + 
                          userName + "'" + "and pwd = '" + pwd + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (null != reader)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        /// <summary>
        /// 添加用户的账号及密码到mysql数据库
        /// </summary>
        /// <param name="userName">账号字符串</param>
        /// <param name="pwd">密码字符串</param>
        /// <returns></returns>
        public bool AddUser(string userName, string pwd)
        {
            string sql;
            MySqlCommand cmd;
            int result;

            sql = "insert into QQAccountDB(username,password) " +
                            "values('" + userName + "','" + pwd + "'";
            cmd = new MySqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();
            if (1 == result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 添加消息及其标签
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="head">标签</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool addMsg(string msg, string head)
        {
            msg = "'" + msg + "'";
            head = "'" + head + "'";
            string sql = "insert into 11abc(msg, head)values(" + msg + "," + head + ")";
            //conn.Close();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (1 == result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
