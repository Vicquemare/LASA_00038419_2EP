using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class CrudBusiness : UserControl
    {
        public CrudBusiness()
        {
            InitializeComponent();
        }

        private string idBusiness = "0";

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                try
                {
                    string query = $"INSERT INTO BUSINESS(name, description) " +
                                   $"VALUES(" +
                                   $"'{textBox1.Text}'," +
                                   $"'{textBox2.Text}')";
                    DbConnection.ExecuteNonQuery(query);
                    

                    MessageBox.Show("Agregado exitosamente");
                    LoadData();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals(""))
            {
                MessageBox.Show("Seleccione el registro a eliminar");
            }
            else
            {
                try
                {
                    DbConnection.ExecuteNonQuery($"DELETE FROM BUSINESS WHERE idBusiness = {idBusiness}");

                    MessageBox.Show("Eliminado exitosamente");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                idBusiness = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var dt = DbConnection.executeQuery("SELECT * FROM business");
            dataGridView1.DataSource = dt;
        }

        private void CrudBusiness_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}