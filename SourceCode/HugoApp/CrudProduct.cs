using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class CrudProduct : UserControl
    {
        public CrudProduct()
        {
            InitializeComponent();
        }

        private string idProduct = "0";
        private string idBusiness = "0";
        private void CrudProduct_Load(object sender, EventArgs e)
        {
            string query = "SELECT name from business";
            var businessCombo = new List<string>();
            var business = DbConnection.executeQuery(query);

            foreach (DataRow dr in business.Rows)
            {
                businessCombo.Add(dr[0].ToString());
            }
            comboBox1.DataSource = businessCombo;
            LoadData();
        }

        private void LoadData()
        {
            string query = $"SELECT idbusiness from business where name = '{comboBox1.Text.ToString()}'";
            var dr = DbConnection.executeQuery(query);
            idBusiness = dr.Rows[0][0].ToString();
            var dt = DbConnection.executeQuery($"SELECT p.idProduct, p.name FROM PRODUCT p WHERE idbusiness = {idBusiness} ");
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            { 
                idProduct = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" )
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                try
                {
                    LoadData();
                    string query = $"INSERT INTO product(name, idbusiness) " +
                                   $"VALUES(" +
                                   $"'{textBox1.Text}'," +
                                   $"{idBusiness})";
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
                comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Seleccione el registro a eliminar");
            }
            else
            {
                try
                {
                    DbConnection.ExecuteNonQuery($"DELETE FROM Product WHERE idproduct = {idProduct}");

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