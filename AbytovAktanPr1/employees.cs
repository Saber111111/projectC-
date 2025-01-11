using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbytovAktanPr1
{
    public partial class employees : Form
    {
        private List<(string Name, string Status)> employeeList = new List<(string, string)>
        {
            ("Абытов Актан", "Выплачено")
        };

        public employees()
        {
            InitializeComponent();
        }

        private void employees_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Name", "Имя сотрудника");
            dataGridView1.Columns.Add("Status", "Статус");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            dataGridView1.Rows.Clear();

            foreach (var employee in employeeList)
            {
                dataGridView1.Rows.Add(employee.Name, employee.Status);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control controlForm = new Control(employeeList);
            controlForm.ShowDialog();
            LoadEmployeeData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salary salaryForm = new salary(employeeList);
            salaryForm.ShowDialog();
            LoadEmployeeData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
