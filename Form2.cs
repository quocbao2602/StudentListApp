using System;
using System.Windows.Forms;

namespace StudentListApp
{
    public partial class Form2 : Form
    {
        public delegate void SendDataDelegate(string id, string name, string phone);
        public delegate void DataApprovalDelegate(string id, string name, string phone);

        public SendDataDelegate SendData;
        public event DataApprovalDelegate DataApproved;

        public Form2()
        {
            InitializeComponent();
            SendData = ReceiveData;
        }

     
        private void ReceiveData(string id, string name, string phone)
        {
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = phone;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DataApproved?.Invoke(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("Data approved successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show("Data rejected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close(); 
        }
    }
}
