using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Chat2021.Mysql
{
    public static class MysqlOperation
    {
        private static MySqlConnection conn;
        
        /// <summary>
        /// 连接mysql数据库 
        /// </summary>
        /// <returns></returns>
        public static bool Connect()
        {
            string connstr = "server = 127.0.0.1; port = 3306; user = root ; password = ROS123; database = qqaccountdb";
            conn = new MySqlConnection(connstr);
            try
            {
                //可能出现异常
                conn.Open();
            }
            catch (MySqlException ex)
            {
                
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 查询用户输入的账号和密码是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool Query(string userName, string pwd)
        {
            string sql = "select * from accountInfo where username='" + userName + "'" + "and pwd = '" + pwd + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(null != reader)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加用户的账号及密码到mysql数据库
        /// </summary>
        /// <param name="userName">账号字符串</param>
        /// <param name="pwd">密码字符串</param>
        /// <returns></returns>
        public static bool AddUser(string userName,string pwd)
        {
            string sql = "insert into QQAccountDB(username,password) values('" + userName + "','" + pwd +"'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if(1 == result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
