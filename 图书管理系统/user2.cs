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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
            Table();    //在构造方法里或Load方法里执行都可以
        }

        private void user2_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 显示已经借阅的图书
        /// </summary>
        public void Table()
        {
            dataGridView1.Rows.Clear(); //首先清空控件中已经存在的旧数据
            Dao dao = new Dao();
            string sql = "select * from t_book";
            //构造一个读取结果集
            //把他实例化成一个对象
            //执行dao类的read方法，将SQL语句传过去
            //然后从数据库读取一个结果，把结果返回到dc里面
            //然后就可以对dc进行操作
            IDataReader dc = dao.read(sql);

            //对dc进行读
            while (dc.Read())    //读取一行数据后，自身指向下一行数据，如果下一行无数据，返回false 
            {
                //将书本信息数据添加上去
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }//方法结束

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1 这个是控件，通过这个控件选择行列值
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//库存
            if(number < 1)
            {
                MessageBox.Show("库存不足，请联系管理员购入");
            }
            else
            {
                string sql = $"insert into t_lend([uid],bid,[datetime]) values('{Data.UID}','{id}',GETDATE());update t_book set number=number-1 where id='{id}'";
                Dao dao = new Dao();
                if(dao.Execute(sql)>1)  //执行了两条sql，大于1才是都成功了
                {
                    MessageBox.Show($"用户{Data.UName}借出了图书{id}");
                    Table();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
