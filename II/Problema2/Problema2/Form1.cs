using Microsoft.Data.SqlClient;
using System.Data;

namespace Problema2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=DESKTOP-QS6OMJJ\SQLEXPRESS;Database=Problema2;Integrated Security=true;TrustServerCertificate=true;";
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
                    parentAdapter.SelectCommand = new SqlCommand("SELECT * FROM Artisti;", connection);
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Melodii;", connection);
                    parentAdapter.Fill(ds, "Artisti");
                    childAdapter.Fill(ds, "Melodii");
                    parentBS.DataSource = ds.Tables["Artisti"];
                    dataGridViewParent.DataSource = parentBS;
                    DataColumn parentColumn = ds.Tables["Artisti"].Columns["cod_artist"];
                    DataColumn childColumn = ds.Tables["Melodii"].Columns["cod_artist"];
                    DataRelation relation = new DataRelation("FK__Melodii__Artisti", parentColumn, childColumn);
                    ds.Relations.Add(relation);
                    childBS.DataSource = parentBS;
                    childBS.DataMember = "FK__Melodii__Artisti";
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
                    int cod_melodie = (int)dataGridViewChild.CurrentRow.Cells["cod_melodie"].Value;
                    string query = "DELETE FROM Melodii WHERE cod_melodie = @cod_melodie;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cod_melodie", cod_melodie);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Melodii;", connection);
                    if (ds.Tables.Contains("Melodii"))
                        ds.Tables["Melodii"].Clear();
                    childAdapter.Fill(ds, "Melodii");
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
                    string titlu = textBox1.Text;
                    int an_lansare = 0;
                    Int32.TryParse(textBox2.Text, out an_lansare);
                    TimeSpan durata = TimeSpan.Parse(textBox3.Text);
                    int cod_artist = (int)dataGridViewParent.CurrentRow.Cells["cod_artist"].Value;
                    string query = "INSERT INTO Melodii (titlu, an_lansare, durata, cod_artist) " +
                        "VALUES (@titlu, @an_lansare, @durata, @cod_artist);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@titlu", titlu);
                    command.Parameters.AddWithValue("@an_lansare", an_lansare);
                    command.Parameters.AddWithValue("@durata", durata);
                    command.Parameters.AddWithValue("@cod_artist", cod_artist);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Melodii;", connection);
                    if (ds.Tables.Contains("Melodii"))
                        ds.Tables["Melodii"].Clear();
                    childAdapter.Fill(ds, "Melodii");
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
                    int cod_melodie = 0;
                    Int32.TryParse(textBox0.Text, out cod_melodie);
                    string titlu = textBox1.Text;
                    int an_lansare = 0;
                    Int32.TryParse(textBox2.Text, out an_lansare);
                    TimeSpan durata = TimeSpan.Parse(textBox3.Text);
                    int cod_artist = 0;
                    Int32.TryParse(textBox4.Text, out cod_artist);
                    string query = "UPDATE Melodii " +
                        "SET titlu = @titlu, an_lansare = @an_lansare, durata = @durata, cod_artist = @cod_artist " +
                        "WHERE cod_melodie = @cod_melodie;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cod_melodie", cod_melodie);
                    command.Parameters.AddWithValue("@titlu", titlu);
                    command.Parameters.AddWithValue("@an_lansare", an_lansare);
                    command.Parameters.AddWithValue("@durata", durata);
                    command.Parameters.AddWithValue("@cod_artist", cod_artist);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Melodii;", connection);
                    if (ds.Tables.Contains("Melodii"))
                        ds.Tables["Melodii"].Clear();
                    childAdapter.Fill(ds, "Melodii");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
