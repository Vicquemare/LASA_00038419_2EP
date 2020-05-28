using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class CrudUser : UserControl
    {
        public CrudUser()
        {
            InitializeComponent();
        }

        private string idUser = "0";

        private void CrudUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

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
                    bool admin = false;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        admin = false;
                    }
                    else
                    {
                        admin = true;
                    }
                    string query = $"INSERT INTO appuser(fullname, username, password, usertype) " +
                                   $"VALUES(" +
                                   $"'{textBox1.Text}'," +
                                   $"'{textBox2.Text}'," +
                                   $"'{textBox3.Text}'," +
                                   $"'{admin}')";
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

        private void LoadData()
        {
            var dt = DbConnection.executeQuery("SELECT * FROM appuser");
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                idUser = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")
                {
                    comboBox1.SelectedIndex = 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
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
                    DbConnection.ExecuteNonQuery($"DELETE FROM appuser WHERE iduser = {idUser}");

                    MessageBox.Show("Eliminado exitosamente");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox2.Text;
        }
    }
}