using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968___Inventory_System
{
    public partial class PartScreen : Form
    {
        // Used to determine whether this PartScreen is used to add new infomation
        // or modify existing information
        private MainScreen mainScreen = null;
        public readonly WindowStatus status;
        private int currentID;
        int labelChangeX;

        public PartScreen(MainScreen mainScreen, WindowStatus status)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.status = status;
        }

        private void radioButtonInhouse_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInhouse.Checked)
            {
                this.labelChange.Text = "Machine ID";
                if (labelChange.Location.X != labelChangeX)
                {
                    this.labelChange.Location = new Point(labelChange.Location.X + 15, labelChange.Location.Y);
                }
            }
        }

        private void labelChange_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOutsourced.Checked)
            {
                this.labelChange.Text = "Company Name";
                this.labelChange.Location = new Point(labelChange.Location.X - 15, labelChange.Location.Y);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadSettings(int id)
        {
            var part = mainScreen.inventory.lookupPart(id);
            currentID = id;
            labelChangeX = labelChange.Location.X;
            textBoxID.Text = part.PartID.ToString();
            textBoxName.Text = part.Name;
            textBoxInventory.Text = part.InStock.ToString();
            textBoxPrice.Text = part.Price.ToString();
            textBoxMax.Text = part.Max.ToString();
            textBoxMin.Text = part.Min.ToString();


            // Determine if Inhouse or Outsourced
            if ((mainScreen.inventory.lookupPart(id)).GetType() == typeof(Outsourced))
            {
                var outsourced = (Outsourced)mainScreen.inventory.lookupPart(id);
                radioButtonOutsourced.Checked = true;
                textBoxChange.Text = outsourced.CompanyName;
            }
            else
            {
                var inhouse = (Inhouse)mainScreen.inventory.lookupPart(id);
                radioButtonInhouse.Checked = true;
                textBoxChange.Text = inhouse.MachineID.ToString();
            }

        }

        private void Part_Load(object sender, EventArgs e)
        {
            if (status == WindowStatus.MODIFY)
            {
                this.labelHeader.Text = "Modify Part";
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
            else if (isEmpty(textBoxChange))
            {
                if (radioButtonInhouse.Checked)
                {
                    MessageBox.Show("The Machine ID field cannot be empty.");
                    return true;
                }
                else if (radioButtonOutsourced.Checked)
                {
                    MessageBox.Show("The Company Name field cannot be empty.");
                    return true;
                }
            }

            return false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (areFieldsEmpty())
            {
                return;
            }

            if (radioButtonInhouse.Checked)
            {
                Inhouse inhouse = new Inhouse();

                inhouse.Name = textBoxName.Text.Trim();

                // check validity of types
                if ( !validateInventory(inhouse) )
                {
                    MessageBox.Show("The Inventory field only accepts numbers.");
                    return;
                }
                if ( !validateMin(inhouse) )
                {
                    MessageBox.Show("The Min field only accepts numbers.");
                    return;
                }
                if (!validateMax(inhouse))
                {
                    MessageBox.Show("The Max field only accepts numbers.");
                    return;
                }
                if (!validatePrice(inhouse))
                {
                    MessageBox.Show("The Price field only accepts numbers.");
                    return;
                }
                if (!validateMachineID(inhouse))
                {
                    MessageBox.Show("The Machine ID field only accepts numbers.");
                    return;
                }
                

                // check that min is less than max
                if ( inhouse.Min > inhouse.Max )
                {
                    MessageBox.Show("The Min value cannot be greater than the Max value.");
                    return;
                }

                // check that inventory is within the range of min and max
                if ( !(inhouse.Min <= inhouse.InStock) || !(inhouse.Max >= inhouse.InStock) )
                {
                    MessageBox.Show("The Inventory value must be between the Min and Max values.");
                    return;
                }

                if (status == WindowStatus.MODIFY)
                {
                    mainScreen.inventory.updatePart(currentID,inhouse);
                }
                else
                {
                    mainScreen.inventory.addPart(inhouse);
                }
            }
            else if (radioButtonOutsourced.Checked)
            {
                Outsourced outsourced = new Outsourced();

                outsourced.Name = textBoxName.Text.Trim();

                // check validity of types
                if (!validateInventory(outsourced))
                {
                    MessageBox.Show("The Inventory field only accepts numbers.");
                    return;
                }
                if (!validateMin(outsourced))
                {
                    MessageBox.Show("The Min field only accepts numbers.");
                    return;
                }
                if (!validateMax(outsourced))
                {
                    MessageBox.Show("The Max field only accepts numbers.");
                    return;
                }
                if (!validatePrice(outsourced))
                {
                    MessageBox.Show("The Price field only accepts numbers.");
                    return;
                }

                outsourced.CompanyName = textBoxChange.Text.Trim();


                // check that min is less than max
                if (outsourced.Min > outsourced.Max)
                {
                    MessageBox.Show("The Min value cannot be greater than the Max value.");
                    return;
                }

                // check that inventory is within the range of min and max
                if (!(outsourced.Min <= outsourced.InStock) || !(outsourced.Max >= outsourced.InStock))
                {
                    MessageBox.Show("The Inventory value must be between the Min and Max values.");
                    return;
                }

                if (status == WindowStatus.MODIFY)
                {

                    mainScreen.inventory.updatePart(currentID, outsourced);

                }
                else
                {
                    mainScreen.inventory.addPart(outsourced);
                }
            }

            this.Close();
        }

        private bool validateInventory(Part part)
        {
            if ( !int.TryParse(textBoxInventory.Text, out var inv) )
            {
                return false;
            }

            part.InStock = inv;
            return true;
        }

        private bool validatePrice(Part part)
        {
            if ( !decimal.TryParse(textBoxPrice.Text, out var price) )
            {
                return false;
            }

            part.Price = price;
            return true;
        }

        private bool validateMin(Part part)
        {
            if (!int.TryParse(textBoxMin.Text, out var min))
            {
                return false;
            }

            part.Min = min;
            return true;
        }

        private bool validateMax(Part part)
        {
            if (!int.TryParse(textBoxMax.Text, out var max))
            {
                return false;
            }

            part.Max = max;
            return true;
        }

        private bool validateMachineID(Inhouse inh)
        {
            if (!int.TryParse(textBoxChange.Text, out var machine))
            {
                return false;
            }

            inh.MachineID = machine;
            return true;
        }
    }
}

