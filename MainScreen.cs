// Author: Jarret Crittendon
// Project for WGU course C968
// 2023 Nov 19


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968___Inventory_System
{
    public partial class MainScreen : Form
    {
        public Inventory inventory;

        public MainScreen()
        {
            InitializeComponent();
            inventory = new Inventory();   
        }

        private void initialData()
        {
            Inhouse part1 = new Inhouse("CPU", 3.99m, 15, 5, 20, 455);
            Inhouse part2 = new Inhouse("RAM", 15.67m, 2, 1, 10, 600);
            Outsourced part3 = new Outsourced("Super I/O", 12.09m, 32, 10, 40, "TT Technologies");
            Outsourced part4 = new Outsourced("Antenna", 6.79m, 15, 1, 60, "TOMY");
            inventory.addPart(part1);
            inventory.addPart(part2);
            inventory.addPart(part3);
            inventory.addPart(part4);

            Product p1 = new Product("Radio", 0.99m, 34, 1, 999);
            Product p2 = new Product("Mobile Phone", 1.50m, 98, 1, 999);
            Product p3 = new Product("Thin Client", 2.35m, 72, 1, 999);
            Product p4 = new Product("Tablet", 0.02m, 123, 1, 999);
            inventory.addProduct(p1); inventory.addProduct(p2);
            inventory.addProduct(p3); inventory.addProduct(p4);
        }

        private void buttonPartDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPart.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewPart.SelectedRows[0];

                var target = (Part)selectedRow.DataBoundItem;
                string message = string.Format("Are you sure you want to delete {0}?", target.Name);
                DialogResult result = MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        inventory.deletePart(target);
                        break;

                    case DialogResult.No:
                        break;
                }
            }
        }

        private void tableSetting()
        {
            // dataGridViewPart table setup
            dataGridViewPart.AutoGenerateColumns = false;
            dataGridViewPart.ColumnCount = 6;

            dataGridViewPart.Columns[0].Name = "Part ID";
            dataGridViewPart.Columns[1].Name = "Name";
            dataGridViewPart.Columns[2].Name = "Inventory";
            dataGridViewPart.Columns[3].Name = "Price";
            dataGridViewPart.Columns[4].Name = "Min";
            dataGridViewPart.Columns[5].Name = "Max";

            dataGridViewPart.Columns["Part ID"].DataPropertyName = "PartID";
            dataGridViewPart.Columns["Name"].DataPropertyName = "Name";
            dataGridViewPart.Columns["Inventory"].DataPropertyName = "InStock";
            dataGridViewPart.Columns["Price"].DataPropertyName = "Price";
            dataGridViewPart.Columns["Min"].DataPropertyName = "Min";
            dataGridViewPart.Columns["Max"].DataPropertyName = "Max";

            // dataGridViewProduct table setup
            dataGridViewProduct.AutoGenerateColumns = false;
            dataGridViewProduct.ColumnCount = 6;

            dataGridViewProduct.Columns[0].Name = "Product ID";
            dataGridViewProduct.Columns[1].Name = "Name";
            dataGridViewProduct.Columns[2].Name = "Inventory";
            dataGridViewProduct.Columns[3].Name = "Price";
            dataGridViewProduct.Columns[4].Name = "Min";
            dataGridViewProduct.Columns[5].Name = "Max";

            dataGridViewProduct.Columns["Product ID"].DataPropertyName = "ProductID";
            dataGridViewProduct.Columns["Name"].DataPropertyName = "Name";
            dataGridViewProduct.Columns["Inventory"].DataPropertyName = "InStock";
            dataGridViewProduct.Columns["Price"].DataPropertyName = "Price";
            dataGridViewProduct.Columns["Min"].DataPropertyName = "Min";
            dataGridViewProduct.Columns["Max"].DataPropertyName = "Max";


            dataGridViewPart.DataSource = inventory.AllParts;
            dataGridViewProduct.DataSource = inventory.Products;

            dataGridViewPart.Columns["Part ID"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewProduct.Columns["Product ID"].SortMode = DataGridViewColumnSortMode.Automatic;

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            initialData();

            tableSetting();
        }

        private void buttonPartAdd_Click(object sender, EventArgs e)
        {
            PartScreen add = new PartScreen(this, WindowStatus.ADD);

            // use ShowDialog() method to access the Part window while disabling access to parent window
            add.ShowDialog();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPartModify_Click(object sender, EventArgs e)
        {
            if (dataGridViewPart.SelectedRows.Count > 1)
            {
                MessageBox.Show("Only one selected row can be used with the Modify button.");
                return;
            }
            else if (dataGridViewPart.SelectedRows.Count < 1)
            {
                MessageBox.Show("No row is selected for modification.");
                return;
            }

            if (dataGridViewPart.Rows.Count > 0)
            {
                PartScreen modify = new PartScreen(this, WindowStatus.MODIFY);

                var selectedRow = dataGridViewPart.SelectedRows[0];
                if (selectedRow != null)
                {
                    var current = (Part)selectedRow.DataBoundItem;
                    modify.loadSettings(current.PartID);
                    modify.ShowDialog();
                    return;
                }
                else
                {
                    MessageBox.Show("No row is selected for modification.");
                    return;
                }
            }
        }

        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
            ProductScreen add = new ProductScreen(this, WindowStatus.ADD);
            add.ShowDialog();
        }

        private void buttonPartSearch_Click(object sender, EventArgs e)
        {
            dataGridViewPart.ClearSelection();
            var text = textBoxPartSearch.Text;
            foreach (DataGridViewRow row in dataGridViewPart.Rows)
            {
                var item = (Part)row.DataBoundItem;
                var name = item.Name.ToLower();
                if (item != null)
                {
                    if (name.Contains(text.ToLower()))
                    {
                        row.Selected = true;
                    }
                }
                
            }
        }

        private void buttonProductModify_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 1)
            {
                MessageBox.Show("Only one selected row can be used with the Modify button.");
                return;
            } else if (dataGridViewProduct.SelectedRows.Count < 1) {
                MessageBox.Show("No row is selected for modification.");
                return;
            }

            if (dataGridViewProduct.Rows.Count > 0)
            {
                ProductScreen modify = new ProductScreen(this, WindowStatus.MODIFY);

                var selectedRow = dataGridViewProduct.SelectedRows[0];
                if (selectedRow != null)
                {
                    var current = (Product)selectedRow.DataBoundItem;
                    modify.loadSettings(current.ProductID);
                    modify.ShowDialog();
                    return;
                }
                else
                {
                    MessageBox.Show("No row is selected for modification.");
                    return;
                }
            }

        }

        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewProduct.SelectedRows[0];

                var target = (Product)selectedRow.DataBoundItem;
                if (target.AssociatedParts.Count != 0)
                {
                    MessageBox.Show("Products with associated parts cannot be deleted.");
                    return;
                }

                string message = string.Format("Are you sure you want to delete {0}?", target.Name);
                DialogResult result = MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
                switch(result)
                {
                   case DialogResult.Yes:
                        inventory.removeProduct(target.ProductID);
                        break;

                    case DialogResult.No:
                        break;
                }
            }
        }

        private void buttonProductSearch_Click(object sender, EventArgs e)
        {
            dataGridViewProduct.ClearSelection();
            var text = textBoxProductSearch.Text;
            foreach (DataGridViewRow row in dataGridViewProduct.Rows)
            {
                var item = (Product)row.DataBoundItem;
                var name = item.Name.ToLower();
                if (item != null)
                {
                    if (name.Contains(text.ToLower()))
                    {
                        row.Selected = true;
                    }
                }
            }
        }
    }
}
