using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace C968___Inventory_System
{
    public partial class ProductScreen : Form
    {
        private BindingList<Part> AssociatedPartList { get; set; } = new BindingList<Part>();
        private MainScreen mainScreen;
        private readonly WindowStatus status;
        private int currentID;

        public ProductScreen(MainScreen mainScreen, WindowStatus status)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.status = status;
        }

        private void tableSetting()
        {
            // dataGridViewCandidate table setup
            dataGridViewCandidate.AutoGenerateColumns = false;
            dataGridViewCandidate.ColumnCount = 6;

            dataGridViewCandidate.Columns[0].Name = "Part ID";
            dataGridViewCandidate.Columns[1].Name = "Name";
            dataGridViewCandidate.Columns[2].Name = "Inventory";
            dataGridViewCandidate.Columns[3].Name = "Price";
            dataGridViewCandidate.Columns[4].Name = "Min";
            dataGridViewCandidate.Columns[5].Name = "Max";

            dataGridViewCandidate.Columns["Part ID"].DataPropertyName = "PartID";
            dataGridViewCandidate.Columns["Name"].DataPropertyName = "Name";
            dataGridViewCandidate.Columns["Inventory"].DataPropertyName = "InStock";
            dataGridViewCandidate.Columns["Price"].DataPropertyName = "Price";
            dataGridViewCandidate.Columns["Min"].DataPropertyName = "Min";
            dataGridViewCandidate.Columns["Max"].DataPropertyName = "Max";

            // dataGridViewAssociated table setup
            dataGridViewAssociated.AutoGenerateColumns = false;
            dataGridViewAssociated.ColumnCount = 6;

            dataGridViewAssociated.Columns[0].Name = "Part ID";
            dataGridViewAssociated.Columns[1].Name = "Name";
            dataGridViewAssociated.Columns[2].Name = "Inventory";
            dataGridViewAssociated.Columns[3].Name = "Price";
            dataGridViewAssociated.Columns[4].Name = "Min";
            dataGridViewAssociated.Columns[5].Name = "Max";

            dataGridViewAssociated.Columns["Part ID"].DataPropertyName = "PartID";
            dataGridViewAssociated.Columns["Name"].DataPropertyName = "Name";
            dataGridViewAssociated.Columns["Inventory"].DataPropertyName = "InStock";
            dataGridViewAssociated.Columns["Price"].DataPropertyName = "Price";
            dataGridViewAssociated.Columns["Min"].DataPropertyName = "Min";
            dataGridViewAssociated.Columns["Max"].DataPropertyName = "Max";


            dataGridViewCandidate.DataSource = mainScreen.inventory.AllParts;
            dataGridViewAssociated.DataSource = this.AssociatedPartList;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewAssociated.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewAssociated.SelectedRows[0];

                var target = (Part)selectedRow.DataBoundItem;

                string message = string.Format("Are you sure you want to delete {0}?", target.Name);
                DialogResult result = MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        AssociatedPartList.Remove(target);
                        break;

                    case DialogResult.No:
                        break;
                }
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            this.tableSetting();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadSettings(int id)
        {
            this.labelHeader.Text = "Modify Product";
            this.currentID = id;
            var product = mainScreen.inventory.lookupProduct(id);
            currentID = id;
            textBoxID.Text = product.ProductID.ToString();
            textBoxName.Text = product.Name;
            textBoxInventory.Text = product.InStock.ToString();
            textBoxPrice.Text = product.Price.ToString();
            textBoxMax.Text = product.Max.ToString();
            textBoxMin.Text = product.Min.ToString();

            foreach (var item in product.AssociatedParts)
            {
                this.AssociatedPartList.Add(item);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (areFieldsEmpty())
            {
                return;
            }

            Product product = new Product();

            product.Name = this.textBoxName.Text.Trim();

            // check validity of types
            if (!validateInventory(product))
            {
                MessageBox.Show("The Inventory field only accepts numbers.");
                return;
            }
            if (!validateMin(product))
            {
                MessageBox.Show("The Min field only accepts numbers.");
                return;
            }
            if (!validateMax(product))
            {
                MessageBox.Show("The Max field only accepts numbers.");
                return;
            }
            if (!validatePrice(product))
            {
                MessageBox.Show("The Price field only accepts numbers.");
                return;
            }

            // check that min is less than max
            if (product.Min > product.Max)
            {
                MessageBox.Show("The Min value cannot be greater than the Max value.");
                return;
            }

            // check that inventory is within the range of min and max
            if (!(product.Min <= product.InStock) || !(product.Max >= product.InStock))
            {
                MessageBox.Show("The Inventory value must be between the Min and Max values.");
                return;
            }


            foreach (var item in this.AssociatedPartList)
            {
                product.addAssociatedPart(item);
            }
            
            
            if (status == WindowStatus.MODIFY)
            {
                mainScreen.inventory.updateProduct(currentID, product);
            }
            else
            {
                mainScreen.inventory.addProduct(product);
            }

            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (dataGridViewCandidate.SelectedRows.Count > 1)
            {
                MessageBox.Show("Only one selected row can be used with the Add button.");
                return;
            }
            else if (dataGridViewCandidate.SelectedRows.Count < 1)
            {
                MessageBox.Show("No row is selected for adding to associated parts.");
                return;
            }

            var selectedRow = dataGridViewCandidate.SelectedRows[0];
            if (selectedRow != null)
            {
                // Store the object current selected
                var current = (Part)selectedRow.DataBoundItem;
                this.AssociatedPartList.Add(current);
            }
            else
            {
                MessageBox.Show("No row is selected for modification.");
            }      
        }

        private bool isEmpty(TextBox textBox)
        {
            return (textBox.Text == "");
        }

        private bool areFieldsEmpty()
        {
            if (isEmpty(textBoxName))
            {
                MessageBox.Show("The Name field cannot be empty.");
                return true;
            }
            else if (isEmpty(textBoxInventory))
            {
                MessageBox.Show("The Inventory field cannot be empty.");
                return true;
            }
            else if (isEmpty(textBoxMin))
            {
                MessageBox.Show("The Min field cannot be empty.");
                return true;
            }
            else if (isEmpty(textBoxMax))
            {
                MessageBox.Show("The Max field cannot be empty.");
                return true;
            }
            else if (isEmpty(textBoxPrice))
            {
                MessageBox.Show("The Price field cannot be empty.");
                return true;
            }

            return false;
        }

        private bool validateInventory(Product product)
        {
            if (!int.TryParse(textBoxInventory.Text, out var inv))
            {
                return false;
            }

            product.InStock = inv;
            return true;
        }

        private bool validatePrice(Product product)
        {
            if (!decimal.TryParse(textBoxPrice.Text, out var price))
            {
                return false;
            }

            product.Price = price;
            return true;
        }

        private bool validateMin(Product product)
        {
            if (!int.TryParse(textBoxMin.Text, out var min))
            {
                return false;
            }

            product.Min = min;
            return true;
        }

        private bool validateMax(Product product)
        {
            if (!int.TryParse(textBoxMax.Text, out var max))
            {
                return false;
            }

            product.Max = max;
            return true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewCandidate.ClearSelection();
            var text = textBoxSearch.Text;
            foreach (DataGridViewRow row in dataGridViewCandidate.Rows)
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
    }
}
