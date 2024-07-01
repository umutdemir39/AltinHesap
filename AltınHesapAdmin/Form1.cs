using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AltınHesapAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=213.238.183.62;Database=altewebt_Jewelry;Uid=altewebt_jewelry_user;Pwd='1810Umut+';";
            
            //info being your table name
            MySqlConnection mysqlCon = new

            MySqlConnection(connectionString);
            mysqlCon.Open();

            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from PCs";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;

                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[0];
                //populate the textbox from specific value of the coordinates of column and row.
                label1.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();

                string text= row.Cells[6].Value.ToString();

            List<String> _ayarList = new List<String>();

            _ayarList = text.Split(';').ToList();
            foreach (string item in _ayarList)
            {
                if (item != "")
                {
                    if (item.Contains(":"))
                    {
                        string[] authorsList = item.Split(':');
                        dataGridView2.Rows.Add(authorsList[0], authorsList[1], authorsList[2]);
                    }
                    else
                    {
                        dataGridView2.Rows.Add(item, "0");
                    }
                }
            }




            dataGridView1.Columns[0].Width = 50;           
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[2].Width = 200;

            dataGridView2.Columns[1].Width = 40;
            dataGridView2.Columns[2].Width = 40;






        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                label1.Text= row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                dataGridView2.Rows.Clear();
                string text = row.Cells[6].Value.ToString();

                List<String> _ayarList = new List<String>();

                _ayarList = text.Split(';').ToList();
                foreach (string item in _ayarList)
                {
                    if (item != "")
                    {
                        if (item.Contains(":"))
                        {
                            string[] authorsList = item.Split(':');
                            dataGridView2.Rows.Add(authorsList[0], authorsList[1], authorsList[2]);
                        }
                        else
                        {
                            dataGridView2.Rows.Add(item, "0");
                        }
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "Server=213.238.183.62;Database=altewebt_Jewelry;Uid=altewebt_jewelry_user;Pwd='1810Umut+';";
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "update PCs set Active='" + this.textBox5.Text + "' where id='" + this.label1.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();//Connection closed here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
