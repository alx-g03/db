using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace lab_1
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=DESKTOP-QS6OMJJ\SQLEXPRESS;Database=CarService;Integrated Security=true;TrustServerCertificate=true;";
        DataSet ds = new DataSet();
        SqlDataAdapter parentAdapter = new SqlDataAdapter();
        SqlDataAdapter childAdapter = new SqlDataAdapter();
        BindingSource parentBS = new BindingSource();
        BindingSource childBS = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    parentAdapter.SelectCommand = new SqlCommand("SELECT * FROM Invoice;", connection);
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Payment;", connection);
                    parentAdapter.Fill(ds, "Invoice");
                    childAdapter.Fill(ds, "Payment");
                    parentBS.DataSource = ds.Tables["Invoice"];
                    dataGridViewParent.DataSource = parentBS;
                    DataColumn[] parentColumns = new DataColumn[] {
                        ds.Tables["Invoice"].Columns["customerID"],
                        ds.Tables["Invoice"].Columns["VIN"]
                    };
                    DataColumn[] childColumns = new DataColumn[] {
                        ds.Tables["Payment"].Columns["customerID"],
                        ds.Tables["Payment"].Columns["VIN"]
                    };
                    DataRelation relation = new DataRelation("FK__Payment__Invoice", parentColumns, childColumns);
                    ds.Relations.Add(relation);
                    childBS.DataSource = parentBS;
                    childBS.DataMember = "FK__Payment__Invoice";
                    dataGridViewChild.DataSource = childBS;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int paymentID = (int)dataGridViewChild.CurrentRow.Cells["paymentID"].Value;
                    string query = "DELETE FROM Payment WHERE paymentID = @paymentID;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@paymentID", paymentID);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Payment;", connection);
                    if (ds.Tables.Contains("Payment"))
                        ds.Tables["Payment"].Clear();
                    childAdapter.Fill(ds, "Payment");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string paymentIDstring = addPaymentIDtextBox.Text;
                    int paymentID = Convert.ToInt32(paymentIDstring);
                    int customerID = (int)dataGridViewParent.CurrentRow.Cells["customerID"].Value;
                    int VIN = (int)dataGridViewParent.CurrentRow.Cells["VIN"].Value;
                    string amountString = addAmountTextBox.Text;
                    decimal amount = Convert.ToDecimal(amountString);
                    string paymentDateString = addPaymentDateTextBox.Text;
                    DateTime paymentDate = DateTime.Parse(paymentDateString);
                    string query = "INSERT INTO Payment (paymentID, customerID, VIN, amount, paymentDate) " +
                        "VALUES (@paymentID, @customerID, @VIN, @amount, @paymentDate);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@paymentID", paymentID);
                    command.Parameters.AddWithValue("@customerID", customerID);
                    command.Parameters.AddWithValue("@VIN", VIN);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@paymentDate", paymentDate);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Payment;", connection);
                    if (ds.Tables.Contains("Payment"))
                        ds.Tables["Payment"].Clear();
                    childAdapter.Fill(ds, "Payment");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int paymentID = (int)dataGridViewChild.CurrentRow.Cells["paymentID"].Value;
                    string customerIDstring = updateCustomerIDtextBox.Text;
                    int customerID = Convert.ToInt32(customerIDstring);
                    string VINstring = updateVINtextBox.Text;
                    int VIN = Convert.ToInt32(VINstring);
                    string amountString = updateAmountTextBox.Text;
                    decimal amount = Convert.ToDecimal(amountString);
                    string paymentDateString = updatePaymentDateTextBox.Text;
                    DateTime paymentDate = DateTime.Parse(paymentDateString);
                    string query = "UPDATE Payment " +
                        "SET customerID = @customerID, VIN = @VIN, amount = @amount, paymentDate = @paymentDate " +
                        "WHERE paymentID = @paymentID;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@paymentID", paymentID);
                    command.Parameters.AddWithValue("@customerID", customerID);
                    command.Parameters.AddWithValue("@VIN", VIN);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@paymentDate", paymentDate);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Payment;", connection);
                    if (ds.Tables.Contains("Payment"))
                        ds.Tables["Payment"].Clear();
                    childAdapter.Fill(ds, "Payment");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            addPaymentIDtextBox.Clear();
            addAmountTextBox.Clear();
            addPaymentDateTextBox.Clear();
            updateCustomerIDtextBox.Clear();
            updateVINtextBox.Clear();
            updateAmountTextBox.Clear();
            updatePaymentDateTextBox.Clear();
        }
    }
}
