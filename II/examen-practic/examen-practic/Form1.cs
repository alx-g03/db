using Microsoft.Data.SqlClient;
using System.Data;

namespace examen_practic
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=DESKTOP-QS6OMJJ\SQLEXPRESS;Database=S8;Integrated Security=true;TrustServerCertificate=true;";
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
                    parentAdapter.SelectCommand = new SqlCommand("SELECT * FROM Muzee;", connection);
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Tablouri;", connection);
                    parentAdapter.Fill(ds, "Muzee");
                    childAdapter.Fill(ds, "Tablouri");
                    parentBS.DataSource = ds.Tables["Muzee"];
                    dataGridViewParent.DataSource = parentBS;
                    DataColumn parentColumn = ds.Tables["Muzee"].Columns["Mid"];
                    DataColumn childColumn = ds.Tables["Tablouri"].Columns["Mid"];
                    DataRelation relation = new DataRelation("FK__Tablouri__Muzee", parentColumn, childColumn);
                    ds.Relations.Add(relation);
                    childBS.DataSource = parentBS;
                    childBS.DataMember = "FK__Tablouri__Muzee";
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
                    int Tid = (int)dataGridViewChild.CurrentRow.Cells["Tid"].Value;
                    string query = "DELETE FROM Tablouri WHERE Tid = @Tid;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tid", Tid);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Tablouri;", connection);
                    if (ds.Tables.Contains("Tablouri"))
                        ds.Tables["Tablouri"].Clear();
                    childAdapter.Fill(ds, "Tablouri");
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
                    string Denumire = textBox1.Text;
                    int AnPictura = 0;
                    Int32.TryParse(textBox2.Text, out AnPictura);
                    string Dimensiune = textBox3.Text;
                    int Pid = 0;
                    Int32.TryParse(textBox4.Text, out Pid);
                    int Mid = (int)dataGridViewParent.CurrentRow.Cells["Mid"].Value;
                    string query = "INSERT INTO Tablouri (Denumire, AnPictura, Dimensiune, Pid, Mid) " +
                        "VALUES (@Denumire, @AnPictura, @Dimensiune, @Pid, @Mid);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Denumire", Denumire);
                    command.Parameters.AddWithValue("@AnPictura", AnPictura);
                    command.Parameters.AddWithValue("@Dimensiune", Dimensiune);
                    command.Parameters.AddWithValue("@Pid", Pid);
                    command.Parameters.AddWithValue("@Mid", Mid);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Tablouri;", connection);
                    if (ds.Tables.Contains("Tablouri"))
                        ds.Tables["Tablouri"].Clear();
                    childAdapter.Fill(ds, "Tablouri");
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
                    int Tid = 0;
                    Int32.TryParse(textBox0.Text, out Tid);
                    string Denumire = textBox1.Text;
                    int AnPictura = 0;
                    Int32.TryParse(textBox2.Text, out AnPictura);
                    string Dimensiune = textBox3.Text;
                    int Pid = 0;
                    Int32.TryParse(textBox4.Text, out Pid);
                    int Mid = 0;
                    Int32.TryParse(textBox5.Text, out Mid);
                    string query = "UPDATE Tablouri " +
                        "SET Denumire = @Denumire, AnPictura = @AnPictura, Dimensiune = @Dimensiune, Pid = @Pid, Mid = @Mid " +
                        "WHERE Tid = @Tid;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tid", Tid);
                    command.Parameters.AddWithValue("@Denumire", Denumire);
                    command.Parameters.AddWithValue("@AnPictura", AnPictura);
                    command.Parameters.AddWithValue("@Dimensiune", Dimensiune);
                    command.Parameters.AddWithValue("@Pid", Pid);
                    command.Parameters.AddWithValue("@Mid", Mid);
                    command.ExecuteNonQuery();
                    childAdapter.SelectCommand = new SqlCommand("SELECT * FROM Tablouri;", connection);
                    if (ds.Tables.Contains("Tablouri"))
                        ds.Tables["Tablouri"].Clear();
                    childAdapter.Fill(ds, "Tablouri");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
