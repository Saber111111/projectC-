using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbytovAktanPr1
{
    public partial class salary : Form
    {
        private List<(string Name, string Status)> employeeList;

        public salary(List<(string, string)> employees)
        {
            InitializeComponent();
            employeeList = employees;
        }

        private void salary_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            listBox1.Items.Clear();
            foreach (var employee in employeeList)
            {
                listBox1.Items.Add(employee.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника для начисления зарплаты.");
                return;
            }

            string selectedEmployee = listBox1.SelectedItem.ToString();
            var employeeToUpdate = employeeList.Find(emp => emp.Name == selectedEmployee);
            string salaryAmount = textBox1.Text;

            if (string.IsNullOrWhiteSpace(salaryAmount) || !decimal.TryParse(salaryAmount, out _))
            {
                MessageBox.Show("Введите правильную сумму зарплаты.");
                return;
            }

            int index = employeeList.FindIndex(emp => emp.Name == selectedEmployee);
            employeeList[index] = (employeeToUpdate.Name, "Выплачено");

            MessageBox.Show($"Зарплата в размере {salaryAmount} была начислена сотруднику {selectedEmployee}.");
            LoadEmployeeData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
