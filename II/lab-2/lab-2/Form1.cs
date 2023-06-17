using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace lab_2
{
    public partial class Form1 : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        static string parentName = ConfigurationManager.AppSettings["ParentTableName"];
        static string childName = ConfigurationManager.AppSettings["ChildTableName"];
        static int childNumberOfColumns = int.Parse(ConfigurationManager.AppSettings["ChildNumberOfColumns"]);
        static string insertQuery = ConfigurationManager.AppSettings["ChildInsertQuery"];
        static string deleteQuery = ConfigurationManager.AppSettings["ChildDeleteQuery"];
        static string updateQuery = ConfigurationManager.AppSettings["ChildUpdateQuery"];

        static string childArr = ConfigurationManager.AppSettings["ChildArr"];

        static string childColumnNames = ConfigurationManager.AppSettings["ChildColumnNames"];
        static string childColumnTypes = ConfigurationManager.AppSettings["ChildColumnTypes"];
        static string childToParentId = ConfigurationManager.AppSettings["ChildToParentId"];

        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        BindingSource bindingSourceParent = new BindingSource();
        BindingSource bindingSourceChild = new BindingSource();
        DataSet dataSetParent = new DataSet();
        DataSet dataSetChild = new DataSet();

        TextBox[] textBoxes = new TextBox[childNumberOfColumns];
        Label[] labels = new Label[childNumberOfColumns];

        public Form1()
        {
            InitializeComponent();

            string[] columnNames = childColumnNames.Split(',');

            for (int i = 0; i < childNumberOfColumns; i++)
            {
                labels[i] = new Label();
                textBoxes[i] = new TextBox();

                labels[i].Text = columnNames[i];
                labels[i].Location = new Point(i * 140 + 150, 20);

                textBoxes[i].Clear();
                textBoxes[i].Location = new Point(i * 140 + 150, 50);
            }

            for (int i = 0; i < childNumberOfColumns; i++)
            {
                this.Controls.Add(labels[i]);
                this.Controls.Add(textBoxes[i]);
            }

            dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM " + parentName, connection);
            dataSetParent.Clear();
            dataAdapter.Fill(dataSetParent);
            dataGridViewParent.DataSource = dataSetParent.Tables[0];
            bindingSourceParent.DataSource = dataSetParent.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridViewParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int i = 0;
                string id = dataGridViewParent.Rows[e.RowIndex].Cells[0].Value.ToString();
                bool result = int.TryParse(id, out i);
                if (result)
                {
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM " + childName + " where " + childName + "." + childToParentId + " = " + id + "; ", connection);
                    dataSetChild.Clear();
                    dataAdapter.Fill(dataSetChild);
                    dataGridViewChild.DataSource = dataSetChild.Tables[0];
                    bindingSourceChild.DataSource = dataSetChild.Tables[0];
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewChild.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a child row");
                return;
            }
            else if (dataGridViewChild.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select only one child row");
                return;
            }

            string[] args = childArr.Split(',');

            try
            {
                dataAdapter.DeleteCommand = new SqlCommand(deleteQuery, connection);
                dataAdapter.DeleteCommand.Parameters.Add(args[0], SqlDbType.Int).Value = dataSetChild.Tables[0].Rows[dataGridViewChild.CurrentCell.RowIndex][0];

                connection.Open();
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                connection.Close();
                dataSetChild.Clear();
                dataAdapter.Fill(dataSetChild);
                MessageBox.Show("Row deleted successfully");
                clearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                connection.Close();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            dataAdapter.InsertCommand = new SqlCommand(insertQuery, connection);

            string[] args = childArr.Split(',');
            string[] types = childColumnTypes.Split(',');

            try
            {
                for (int i = 0; i < childNumberOfColumns; i++)
                {
                    switch (types[i])
                    {
                        case "varchar":
                            dataAdapter.InsertCommand.Parameters.Add(args[i], SqlDbType.VarChar).Value = textBoxes[i].Text;
                            break;
                        case "int":
                            dataAdapter.InsertCommand.Parameters.Add(args[i], SqlDbType.Int).Value = int.Parse(textBoxes[i].Text);
                            break;
                        case "real":
                            dataAdapter.InsertCommand.Parameters.Add(args[i], SqlDbType.Real).Value = float.Parse(textBoxes[i].Text);
                            break;
                        case "date":
                            dataAdapter.InsertCommand.Parameters.Add(args[i], SqlDbType.Date).Value = textBoxes[i];
                            break;
                        default:
                            MessageBox.Show("Error " + args[i] + " " + types[i]);
                            break;
                    }
                }

                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                dataSetChild.Clear();
                dataAdapter.Fill(dataSetChild);
                MessageBox.Show("Row added successfully");
                clearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                connection.Close();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewChild.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a child row");
                return;
            }
            else if (dataGridViewChild.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select only one child row");
                return;
            }

            int numberOfRows;
            string[] args = childArr.Split(',');
            string[] types = childColumnTypes.Split(',');

            dataAdapter.UpdateCommand = new SqlCommand(updateQuery, connection);
            dataAdapter.UpdateCommand.Parameters.Add(args[0], SqlDbType.Int).Value = dataSetChild.Tables[0].Rows[dataGridViewChild.CurrentCell.RowIndex][0];

            

            try
            {
                for (int i = 1; i < childNumberOfColumns; i++)
                {
                    switch (types[i])
                    {
                        case "varchar":
                            dataAdapter.UpdateCommand.Parameters.Add(args[i], SqlDbType.VarChar).Value = textBoxes[i].Text;
                            break;
                        case "int":
                            dataAdapter.UpdateCommand.Parameters.Add(args[i], SqlDbType.Int).Value = int.Parse(textBoxes[i].Text);
                            break;
                        case "real":
                            dataAdapter.UpdateCommand.Parameters.Add(args[i], SqlDbType.Real).Value = float.Parse(textBoxes[i].Text);
                            break;
                        case "date":
                            dataAdapter.InsertCommand.Parameters.Add(args[i], SqlDbType.Date).Value = textBoxes[i];
                            break;
                        default:
                            MessageBox.Show("Error " + args[i] + " " + types[i]);
                            break;
                    }
                }

                connection.Open();
                numberOfRows = dataAdapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
                dataSetChild.Clear();
                dataAdapter.Fill(dataSetChild);

                if (numberOfRows >= 1)
                {
                    MessageBox.Show("Row updated successfully");
                    clearTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                connection.Close();
            }
        }

        private void dataGridViewChild_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewChild.Rows[e.RowIndex];
                for (int i = 0; i < childNumberOfColumns; i++)
                {
                    textBoxes[i].Text = selectedRow.Cells[i].Value.ToString();
                }
            }
        }

        private void clearTextBoxes()
        {
            for (int i = 0; i < childNumberOfColumns; i++)
            {
                textBoxes[i].Clear();
            }
        }
    }
}
