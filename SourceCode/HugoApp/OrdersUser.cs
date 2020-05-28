using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class OrdersUser : UserControl
    {
        public OrdersUser()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void OrdersUser_Load(object sender, EventArgs e)
        {
            if (Program.activeUser.Type)
            {
                tabControl2.TabPages.Remove(tabPage4);
                button7.Visible = false;
            }

            LoadData();

        }

        private void LoadData()
        {
            string query = "";
            if (Program.activeUser.Type)
            {
                query = "SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser";
            }
            else
            {
                query =
                    $"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser AND au.idUser = {Program.activeUser.Id.ToString()}";
            }
            var dt = DbConnection.executeQuery(query);
            dataGridView2.DataSource = dt;

            if (!Program.activeUser.Type)
            {
                var dt2 = DbConnection.executeQuery("SELECT p.idProduct, p.name, b.name as empresa FROM PRODUCT p, business b WHERE b.idbusiness = p.idbusiness");
                dataGridView3.DataSource = dt2;
                var dt3 = DbConnection.executeQuery($"SELECT * FROM address where iduser = '{Program.activeUser.Id.ToString()}'");
                dataGridView4.DataSource = dt3;
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                button8.Enabled = true;
            }
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                button8.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!(dataGridView3.SelectedRows.Count > 0 && dataGridView3.SelectedRows.Count > 0))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                try
                {
                    string query = $"INSERT INTO apporder(createdate, idproduct, idaddress) " +
                                   $"VALUES(" +
                                   "CURRENT_DATE, " +
                                   $"'{dataGridView3.SelectedRows[0].Cells[0].Value.ToString()}'," +
                                   $"'{dataGridView4.SelectedRows[0].Cells[0].Value.ToString()}')";
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

        private void button7_Click(object sender, EventArgs e)
        {
            
            
                try
                {
                    DbConnection.ExecuteNonQuery($"DELETE FROM apporder WHERE idorder = {dataGridView2.SelectedRows[0].Cells[0].Value.ToString()}");

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