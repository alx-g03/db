using Microsoft.Data.SqlClient;
using System.Data;

namespace Problema1
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=DESKTOP-QS6OMJJ\SQLEXPRESS;Database=Problema1;Integrated Security=true;TrustServerCertificate=true;";
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
                    parentAdapter.SelectCommand = new SqlCommand("SELECT * FROM Cofetarii;", connection);
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Briose;", connection);
                    parentAdapter.Fill(ds, "Cofetarii");
                    childAdapter.Fill(ds, "Briose");
                    parentBS.DataSource = ds.Tables["Cofetarii"];
                    dataGridViewParent.DataSource = parentBS;
                    DataColumn parentColumn = ds.Tables["Cofetarii"].Columns["cod_cofetarie"];
                    DataColumn childColumn = ds.Tables["Briose"].Columns["cod_cofetarie"];
                    DataRelation relation = new DataRelation("FK__Briose__Cofetarii", parentColumn, childColumn);
                    ds.Relations.Add(relation);
                    childBS.DataSource = parentBS;
                    childBS.DataMember = "FK__Briose__Cofetarii";
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
                    int cod_briosa = (int)dataGridViewChild.CurrentRow.Cells["cod_briosa"].Value;
                    string query = "DELETE FROM Briose WHERE cod_briosa = @cod_briosa;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cod_briosa", cod_briosa);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Briose;", connection);
                    if (ds.Tables.Contains("Briose"))
                        ds.Tables["Briose"].Clear();
                    childAdapter.Fill(ds, "Briose");
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
                    string nume_briosa = textBox1.Text;
                    string descriere = textBox2.Text;
                    float pret = 0F;
                    float.TryParse(textBox3.Text, out pret);
                    int cod_cofetarie = (int)dataGridViewParent.CurrentRow.Cells["cod_cofetarie"].Value;
                    string query = "INSERT INTO Briose (nume_briosa, descriere, pret, cod_cofetarie) " +
                        "VALUES (@nume_briosa, @descriere, @pret, @cod_cofetarie);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nume_briosa", nume_briosa);
                    command.Parameters.AddWithValue("@descriere", descriere);
                    command.Parameters.AddWithValue("@pret", pret);
                    command.Parameters.AddWithValue("@cod_cofetarie", cod_cofetarie);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Briose;", connection);
                    if (ds.Tables.Contains("Briose"))
                        ds.Tables["Briose"].Clear();
                    childAdapter.Fill(ds, "Briose");
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
                    int cod_briosa = 0;
                    Int32.TryParse(textBox0.Text, out cod_briosa);
                    string nume_briosa = textBox1.Text;
                    string descriere = textBox2.Text;
                    float pret = 0F;
                    float.TryParse(textBox3.Text, out pret);
                    int cod_cofetarie = 0;
                    Int32.TryParse(textBox4.Text, out cod_cofetarie);
                    string query = "UPDATE Briose " +
                        "SET nume_briosa = @nume_briosa, descriere = @descriere, pret = @pret, cod_cofetarie = @cod_cofetarie " +
                        "WHERE cod_briosa = @cod_briosa;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cod_briosa", cod_briosa);
                    command.Parameters.AddWithValue("@nume_briosa", nume_briosa);
                    command.Parameters.AddWithValue("@descriere", descriere);
                    command.Parameters.AddWithValue("@pret", pret);
                    command.Parameters.AddWithValue("@cod_cofetarie", cod_cofetarie);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Briose;", connection);
                    if (ds.Tables.Contains("Briose"))
                        ds.Tables["Briose"].Clear();
                    childAdapter.Fill(ds, "Briose");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
