using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SewFactoryP.Forms
{
    public partial class Clothes : Form
    {
        public SqlConnection sqlConnection = null;

        public Clothes()
        {
            InitializeComponent();

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SFactory"].ConnectionString);
            sqlConnection.Open();


            /*if (sqlConnection.State == ConnectionState.Open) ;
             {
                 MessageBox.Show("true");
             }*/
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "select Model.Id,Model.Name as Название,Cloth.Name  as Ткань, Fittings.Name as Фурнитура, Color_mdl.Name_clr as Цвет ,Model.Materials_1 as Расход from Model inner join Cloth on Cloth.ID = Model.Cloth_id inner join  Fittings on Fittings.id = Model.Fittings1 inner join Color_mdl on Color_mdl.ID = Model.Color_id";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select Cloth.Id,Cloth.Name as Название,Supplier_mat.Surname +' '+ Supplier_Mat.Name +' '+ Supplier_mat.Patronymic  as  Поставщик   from Cloth inner join Supplier_mat on Supplier_mat.ID = Cloth.Supplier_id";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select Fittings.Id,Fittings.Name as Название,Supplier_mat.Surname +' '+ Supplier_Mat.Name +' '+ Supplier_mat.Patronymic  as  Поставщик   from Fittings inner join Supplier_mat on Supplier_mat.ID = Fittings.Supplier_id";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView3.DataSource = dataSet.Tables[0];
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "select Supplier_mat.Id,Supplier_mat.Surname as Фамилия,Supplier_Mat.Name  as Имя,Supplier_mat.Patronymic as Отчество, Supplier_mat.Phone as Телефон,Supplier_mat.Email as Почта,Supplier_mat.Company as Компания from Supplier_mat";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView4.DataSource = dataSet.Tables[0];
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            string sql = "select Size_mdl.ID,Size_mdl.Name_size as Размеры from Size_mdl";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView5.DataSource = dataSet.Tables[0];
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "select Color_mdl.ID,Color_mdl.Name_clr as Цвет from Color_mdl";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView6.DataSource = dataSet.Tables[0];
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

