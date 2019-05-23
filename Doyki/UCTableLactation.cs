﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doyki
{
    public partial class UCTableLactation : UserControl
    {
        public UCTableLactation()
        {
            InitializeComponent();
            this.lactationTableAdapter.Fill(this.uchot_udoevDataSet2.Lactation);
        }

        private void LactationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lactationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.uchot_udoevDataSet2);
        }

        private void SearchStripButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lactationDataGridView.RowCount; i++)
            {
                lactationDataGridView.Rows[i].Selected = false;
                for (int j = 0; j < lactationDataGridView.ColumnCount; j++)
                    if (lactationDataGridView.Rows[i].Cells[j].Value != null)
                        if (lactationDataGridView.Rows[i].Cells[j].Value.ToString().Contains(searchStripTextBox.Text))
                        {
                            lactationDataGridView.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = (MainForm)this.Parent;
            main.tableLayoutPanel1.Show();
        }

    }
}
