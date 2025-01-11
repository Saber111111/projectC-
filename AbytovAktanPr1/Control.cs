using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbytovAktanPr1
{
    public partial class Control : Form
    {
        private List<(string Name, string Status)> employeeList;

        public Control(List<(string, string)> employees)
        {
            InitializeComponent();
            employeeList = employees;
        }

        private void Control_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs args)
        {
            string name = textBox1.Text;
            string status = textBox2.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Проверка на наличие дубликатов в списке
            if (employeeList.Exists(emp => emp.Name == name))
            {
                MessageBox.Show("Этот сотрудник уже существует.");
                return;
            }

            employeeList.Add((name, status));
            LoadEmployeeData();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs args)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
                return;
            }

            string selectedEmployee = listBox1.SelectedItem.ToString();

            // Используем безопасное удаление
            var employeeToRemove = employeeList.Find(emp => emp.Name == selectedEmployee);
            if (employeeToRemove != default)
            {
                employeeList.Remove(employeeToRemove);
                LoadEmployeeData();
            }
            else
            {
                MessageBox.Show("Не удалось найти выбранного сотрудника.");
            }
        }

        private void button3_Click(object sender, EventArgs args)
        {
            this.Close();
        }
    }
}