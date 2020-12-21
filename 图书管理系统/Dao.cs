using System.Data.SqlClient;

namespace 图书管理系统
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            //Data Souece=数据库地址 Initial Catalog=数据库名称  Integrated Security=不要用户名和密码是否能连接数据库 true 能 false 不能
            string str = @"Data Source=DESKTOP-96ITNFK;Initial Catalog=图书管理系统;Integrated Security=True";
            sc = new SqlConnection(str);  //创建数据库链接对象
            sc.Open();  //打开数据库
            return sc;  //返回数据库链接对象
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)  //更新操作
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)   //读取操作
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sc.Close(); //关闭数据库连接
        }
    }
}
