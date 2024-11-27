using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên TextBox
                textBox1.Text = row.Cells[0].Value?.ToString();
                textBox2.Text = row.Cells[1].Value?.ToString();
                textBox3.Text = row.Cells[2].Value?.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem TextBox có dữ liệu không
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill in all fields before adding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo instance của Form2
            Form2 form2 = new Form2();

            // Gửi dữ liệu đến Form2
            form2.SendData?.Invoke(textBox1.Text, textBox2.Text, textBox3.Text);

            // Xử lý sự kiện khi Form2 xác nhận dữ liệu
            form2.DataApproved += (id, name, phone) =>
            {
                dgvStudents.Rows.Add(id, name, phone);
            };

           
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvStudents.CurrentRow;

                // Cập nhật dữ liệu của dòng được chọn từ TextBox
                selectedRow.Cells[0].Value = textBox1.Text; // ID
                selectedRow.Cells[1].Value = textBox2.Text; // Name
                selectedRow.Cells[2].Value = textBox3.Text; // Phone

                MessageBox.Show("Student information updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa nội dung trong TextBox sau khi sửa
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                dgvStudents.Rows.Remove(dgvStudents.CurrentRow);
                MessageBox.Show("Student deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem TextBox có dữ liệu không
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill in all fields before sending data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo một instance của Form2
            Form2 form2 = new Form2();

            // Gửi dữ liệu qua delegate
            form2.SendData?.Invoke(textBox1.Text, textBox2.Text, textBox3.Text);

            // Hiển thị Form2
            form2.Show();
        }
    }
}
