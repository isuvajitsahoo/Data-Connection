using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseConnection
{
    /// <summary>
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : Page
    {
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        string dbConnectionString = @"Data Source=ndamssql\sqlilearn; user id=sqluser; password=sqluser;initial catalog=training_19sep18_pune;";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(dbConnectionString);
            try
            {
                con.Open();
                

                SqlCommand sqlcom = new SqlCommand("insert into SuvajitEmployee ([Employee ID], [First Name], [Last Name], [Email ID]) values(@EID,@FN,@LN,@EMAIL)", con);

                sqlcom.Parameters.AddWithValue("@EID", txtid.Text);
                sqlcom.Parameters.AddWithValue("@FN", txtFN.Text);
                sqlcom.Parameters.AddWithValue("@LN", txtLN.Text);
                sqlcom.Parameters.AddWithValue("@EMAIL", txtemail.Text);
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("SAVED!!!");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con1 = new SqlConnection(@"Data Source=ndamssql\sqlilearn; user id=sqluser; password=sqluser;initial catalog=training_19sep18_pune;"))
            {
                con1.Open();
                DataTable dtEmployee = new DataTable();
                SqlDataAdapter sad = new SqlDataAdapter("Select * from SuvajitEmployee", con1);
                sad.Fill(dtEmployee);
                con1.Close();
                MessageBox.Show(dtEmployee.Rows.Count.ToString());
                //foreach (DataRow singleRow in dtEmployee.Rows)
                //{
                //    MessageBox.Show(singleRow["employeeid"].ToString() + singleRow["name"].ToString());
                //}
                try {
                    data.ItemsSource = dtEmployee.DefaultView;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                }
        }
    }
}
