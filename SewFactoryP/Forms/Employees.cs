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
    public partial class Employees : Form
    {
        public SqlConnection sqlConnection = null;
        public Employees()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SFactory"].ConnectionString);
            sqlConnection.Open();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select Employees.ID,Employees.Surname,Employees.Name,Employees.Patronymic  from Employees";
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
           string sql = "select Employees_Info.Id,Employees_Info.BirthDate as Дата_рождения,Emp_gender.Name_gender  as Пол,Employees_Info.Phone as Телефон,Employees_Info.Email as Почта,Emp_city.Name_city as Город,Employees_Info.Street as Улица  from Employees_Info inner join Emp_gender on Emp_gender.ID = Employees_info.Gender  inner join Emp_city on Emp_city.ID = Employees_info.City";

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
            string sql = "select Emp_city.ID, Emp_city.Name_city as Город  from Emp_city ";
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
            string sql = "select Emp_gender.ID ,Emp_gender.Name_gender as Пол from Emp_gender ";
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
            string sql = "select Shop.ID ,Shop.Name as Цех from Shop ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView5.DataSource = dataSet.Tables[0];
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
