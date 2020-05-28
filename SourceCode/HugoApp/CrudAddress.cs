using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class CrudAddress : UserControl
    {


        public CrudAddress()
        {
            InitializeComponent();
        }

        private string idAdress = "0";

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                idAdress = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void CrudAddress_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var dt = DbConnection.executeQuery($"SELECT * FROM address where iduser = '{Program.activeUser.Id.ToString()}'");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                try
                {
                    string query = $"INSERT INTO address(iduser, address) " +
                                   $"VALUES(" +
                                   $"'{Program.activeUser.Id.ToString()}'," +
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    DbConnection.ExecuteNonQuery($"UPDATE ADDRESS SET address = '{textBox1.Text}' WHERE idAddress = {idAdress}");

                    MessageBox.Show("Modificado exitosamente");
                    textBox1.Enabled = false;
                    button1.Enabled = false;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Seleccione el registro a eliminar");
            }
            else
            {
                try
                {
                    DbConnection.ExecuteNonQuery($"DELETE FROM address WHERE idAddress = {idAdress}");

                    MessageBox.Show("Eliminado exitosamente");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }
    }


    
}