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
    public partial class Заказы : Form
    {
        public SqlConnection sqlConnection = null;
        public Заказы()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SFactory"].ConnectionString);
            sqlConnection.Open();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            string sql = "select Orders.Reg_Time as Дата_регистрации,Customer.Surname +'' + Customer.Name+ '' as ФИ_Заказчика, Model.Name as Название_Одежды, Size_mdl.Name_size as Размер ,Orders.Number as Колличество,Orders.Price_for_one as Цена_за_1,Orders.Price as Итого,Shop.Name as Цех,Status_order.Name_status as Статус from Orders inner join Customer on Customer.ID = Orders.Customer_id inner join  Model on Model.id = Orders.Model_id  inner join Size_mdl on Size_mdl.ID = Orders.Size_mdl inner join  Shop on Shop.Id = Orders.Shop_id inner join  Status_order on Status_order.ID = Orders.Status";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView21.DataSource = dataSet.Tables[0];
        }

        private void dataGridView21_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            string sql = "select Customer.Id,Customer.Surname as Фамилия,Customer.Name  as Имя,Customer.Patronymic as Отчество, Customer.Phone as Телефон,Customer.Email as Почта,Customer.Company as Компания from Customer";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            string sql = "select Status_Order.ID,Status_Order.Name_status  from Status_Order";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView3.DataSource = dataSet.Tables[0];
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
