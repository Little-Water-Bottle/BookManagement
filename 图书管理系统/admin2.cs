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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
            //也可以把 Table();放在这里
            
        }

        /// <summary>
        /// 从数据库读取数据显示在表格控件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //获取书号
        }

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

        /// <summary>
        /// 根据书号显示数据
        /// </summary>
        public void TableID()
        {
            dataGridView1.Rows.Clear(); //首先清空控件中已经存在的旧数据
            Dao dao = new Dao();
            string sql = $"select * from t_book where id='{textBox1.Text}'";
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

        /// <summary>
        /// 书名查询 模糊查询like
        /// </summary>
        public void TableName()
        {
            dataGridView1.Rows.Clear(); //首先清空控件中已经存在的旧数据
            Dao dao = new Dao();
            string sql = $"select * from t_book where name like '%{textBox2.Text}%'";
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

        /// <summary>
        /// 联合ID和书名查询
        /// </summary>
        public void TableIdAndName()
        {
            dataGridView1.Rows.Clear(); //首先清空控件中已经存在的旧数据
            Dao dao = new Dao();
            string sql = $"select * from t_book where id='{textBox1.Text}' and name='{textBox2.Text}'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 a = new admin21();
            a.ShowDialog();
            Table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //选中的行数的第0行 第0个单元格 它的值转为字符串格式 在这里表示书号
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();    //获取书号
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //书号+书名
                //对话框的返回值
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(dr==DialogResult.OK)
                {
                    string sql = $"delete from t_book where id='{id}'";
                    Dao dao = new Dao();
                    if(dao.Execute(sql)>0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                    //执行完数据库后要关闭数据库连接
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("请先在表格选中要删除的图书记录","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();    //获取书号
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                admin22 admin = new admin22(id,name,author,press,number);
                admin.ShowDialog();

                Table();   //刷新数据
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TableIdAndName();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.SelectedRows.Count;   //获取当前选中的行数
            string sql = $"delete from t_book where id in ("; 
            for(int i = 0; i< n;i++)
            {
                sql += $"'{dataGridView1.SelectedRows[i].Cells[0].Value.ToString()}',";
                //MessageBox.Show(dataGridView1.SelectedRows[i].Cells[1].Value.ToString());
            }
            sql = sql.Remove(sql.Length - 1);
            sql += ")";
            MessageBox.Show(sql);
            Dao dao = new Dao();
            if(dao.Execute(sql)>n-1)
            {
                MessageBox.Show($"成功删除{n}条图书信息");
                Table();
            }
           
        }
    }
}
