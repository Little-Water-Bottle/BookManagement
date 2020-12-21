using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 图书管理系统
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("账户名或密码名为空，请重新输入");
            }
        }
        /// <summary>
        /// 登录方法    验证是否允许登录，允许返回真
        /// </summary>
        /// <returns></returns>
        public void Login()
        {
            //用户
            if(radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();
                //string sql = "select * from t_user where id='"+textBox1.Text+ "' and psw='"+textBox2.Text+"'";
                //string sql2 = String.Format("select * from t_user where id='{0}' and psw='{1}'",textBox1.Text,textBox2.Text);
                string sql = $"select * from t_user where id='{textBox1.Text}' and psw='{textBox2.Text}'";

                IDataReader dc = dao.read(sql);
                if(dc.Read())
                {
                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();
                    MessageBox.Show("登录成功");
                    this.Hide();
                    user1 user = new user1();
                    user.ShowDialog();
                    this.Show();
                    //return true;
                }
                else
                {
                    MessageBox.Show("登录失败");
                    //return false;
                }
                //MessageBox.Show(dc[0].ToString()+dc["name"].ToString());    //这里的dc[0] dc["name"]两种写法相当于数组和字典访问
                dao.DaoClose(); //关闭数据库连接

            }
            //管理员
            if(radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where id='{textBox1.Text}' and psw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    admin1 a = new admin1();
                    this.Hide();
                    a.ShowDialog();
                    this.Show();
                    //return true;
                }
                else
                {
                    MessageBox.Show("登录失败");
                    //return false;
                }
                dao.DaoClose(); //关闭数据库连接
            } 
            //MessageBox.Show("单选框请先选中");
            //return false;   //两个都失败了，直接返回false

        }//login()
    }
}
