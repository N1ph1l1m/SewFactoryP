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
    public partial class Requests : Form
    {
        public SqlConnection sqlConnection = null;
        public Requests()
        {
            InitializeComponent();
        }

   
     

        private void Form4_Load_1(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SFactory"].ConnectionString);
            sqlConnection.Open();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            string sql = "select Employees.Id, Employees.Surname +' '+ Employees.Name +' '+ Employees.Patronymic as Работники, Shop.Name as Цех from Shop_Emp inner join Employees on Employees.Id= Shop_Emp.ID_emp inner join Shop on Shop.Id = Shop_Emp.ID_shop";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView41.DataSource = dataSet.Tables[0];
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button42_Click(object sender, EventArgs e)
        {


            string sql = "select   Orders.Reg_Time as Дата_регистрации,Customer.Surname +'' + Customer.Name+ '' as ФИ_Заказчика, Model.Name as Название_Одежды, Size_mdl.Name_size as Размер ,Orders.Number as Колличество,Orders.Price_for_one as Цена_за_1,Orders.Price as Итого,Shop.Name as Цех,Status_order.Name_status as Статус from Orders  inner join Customer on Customer.ID = Orders.Customer_id inner join  Model on Model.id = Orders.Model_id  inner join Size_mdl on Size_mdl.ID = Orders.Size_mdl inner join  Shop on Shop.Id = Orders.Shop_id inner join  Status_order on Status_order.ID = Orders.Status  where Reg_Time >= '2019-01-01' and Reg_Time < '2020-01-01'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView42.DataSource = dataSet.Tables[0];
        }

        private void dataGridView42_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select distinct Model.Name as Одежда,sum(Number) as 'Произведено ' from orders inner join Model on Model.id = Orders.Model_id  where Status = 1 GROUP BY Model.Name";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView3.DataSource = dataSet.Tables[0];
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Employees WHERE Patronymic LIKE '%вич'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView44.DataSource = dataSet.Tables[0];
        }

        private void dataGridView44_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
