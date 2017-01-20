using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        private readonly Presenter presenter;

        public Form1(Presenter presenter)
        {
            this.presenter = presenter;
            InitializeComponent();
        }

        public void SetStatusBox(String[] values)
        {
            statusBox.Items.Add("");
            statusBox.Items.AddRange(values);
        }

        public String GetStatusBoxValue() 
        {
            return this.statusBox.Text;
        }

        public void SetDepsBox(String[] values)
        {
            depsBox.Items.Add("");
            depsBox.Items.AddRange(values);
        }

        public String GetDepsBoxValue()
        {
            return this.depsBox.Text;
        }

        public void SetPostsBox(String[] values)
        {
            postsBox.Items.Add("");
            postsBox.Items.AddRange(values);
        }

        public String GetPostsBoxValue()
        {
            return this.postsBox.Text;
        }

        public String GetSecondNameBoxValue()
        {
            return this.secondNameBox.Text;
        }

        public void SetPersonsDataGrid(DataSet values)
        {
            PersonsDataGrid.DataSource = values.Tables[0];
        }

        public DateTime GetStartDate()
        {
            return dateTimePickerStart.Value;
        }

        public DateTime GetEndDate()
        {
            return dateTimePickerEnd.Value;
        }

        public bool RadioButtonEmployIsChecked()
        {
            return radioButtonEmploy.Checked;
        }

        public void SetStatisticDataGrid(DataSet values)
        {
            StatisticDataGrid.DataSource = values.Tables[0];
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            presenter.UpdatePersonDataGrid();
        }

        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            presenter.UpdateStatisticDataGrid();
        }

        public void Exit()
        {
            this.Exit();
        }
    }
}
