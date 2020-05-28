using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class Main : Form
    {
        private UserControl current = null;
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(pictureBox2);
            tableLayoutPanel1.Controls.Remove(current);
            current = new MyProfile();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 0);
            tableLayoutPanel1.SetRowSpan(current, 5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(pictureBox2);
            tableLayoutPanel1.Controls.Remove(current);
            current = new OrdersUser();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 0);
            tableLayoutPanel1.SetRowSpan(current, 5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(pictureBox2);
            tableLayoutPanel1.Controls.Remove(current);
            current = new CrudBusiness();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 0);
            tableLayoutPanel1.SetRowSpan(current, 5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(pictureBox2);
            tableLayoutPanel1.Controls.Remove(current);
            current = new CrudProduct();
            current.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(current, 1, 0);
            tableLayoutPanel1.SetRowSpan(current, 5);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!Program.activeUser.Type)
            {
                button3.Visible = false;
                button4.Visible = false;
            }
        }
    }
}