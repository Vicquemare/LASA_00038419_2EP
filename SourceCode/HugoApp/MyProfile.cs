using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class MyProfile : UserControl
    {
        private Panel current = null;
        public MyProfile()
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Remove(panelAddress);
            tableLayoutPanel1.Controls.Remove(panelInfo);
            tableLayoutPanel1.Controls.Remove(panelUsers);
            current = panelInfo;
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 0, 5);
            tableLayoutPanel1.SetColumnSpan(current, 4);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = panelInfo;
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 0, 5);
            tableLayoutPanel1.SetColumnSpan(current, 4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.activeUser.Type)
            {
                tableLayoutPanel1.Controls.Remove(current);
                current = panelUsers;
                current.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(current, 0, 5);
                tableLayoutPanel1.SetColumnSpan(current, 4);
            }
            else
            {
                tableLayoutPanel1.Controls.Remove(current);
                current = panelAddress;
                current.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(current, 0, 5);
                tableLayoutPanel1.SetColumnSpan(current, 4);
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.activeUser.Name;
            textBox2.Text = Program.activeUser.Nickname;
            textBox3.Text = Program.activeUser.Password;
            if (Program.activeUser.Type)
            {
                textBox4.Text = "Administrador";
                button2.Text = "Usuarios del sistema";
            }
            else
            {
                textBox4.Text = "Cliente";
                button2.Text = "Mis Direcciones";
            }
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    DbConnection.ExecuteNonQuery($"UPDATE appuser SET password = '{textBox5.Text}' WHERE idUser = {Program.activeUser.Id.ToString()}");
                    textBox3.Text = textBox5.Text;
                    Program.activeUser.Password = textBox5.Text;
                    textBox5.Text = "";
                    
                    MessageBox.Show("Modificado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se ha producido un error");
                }   
            }
        }
    }
}