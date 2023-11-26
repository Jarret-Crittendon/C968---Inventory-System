namespace C968___Inventory_System
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPartSearch = new System.Windows.Forms.TextBox();
            this.textBoxProductSearch = new System.Windows.Forms.TextBox();
            this.buttonPartSearch = new System.Windows.Forms.Button();
            this.buttonProductSearch = new System.Windows.Forms.Button();
            this.buttonPartDelete = new System.Windows.Forms.Button();
            this.buttonPartModify = new System.Windows.Forms.Button();
            this.buttonPartAdd = new System.Windows.Forms.Button();
            this.buttonProductDelete = new System.Windows.Forms.Button();
            this.buttonProductModify = new System.Windows.Forms.Button();
            this.buttonProductAdd = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewPart = new System.Windows.Forms.DataGridView();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory Management System";
            // 
            // textBoxPartSearch
            // 
            this.textBoxPartSearch.Location = new System.Drawing.Point(349, 48);
            this.textBoxPartSearch.Name = "textBoxPartSearch";
            this.textBoxPartSearch.Size = new System.Drawing.Size(150, 20);
            this.textBoxPartSearch.TabIndex = 3;
            // 
            // textBoxProductSearch
            // 
            this.textBoxProductSearch.Location = new System.Drawing.Point(842, 48);
            this.textBoxProductSearch.Name = "textBoxProductSearch";
            this.textBoxProductSearch.Size = new System.Drawing.Size(150, 20);
            this.textBoxProductSearch.TabIndex = 4;
            // 
            // buttonPartSearch
            // 
            this.buttonPartSearch.Location = new System.Drawing.Point(253, 48);
            this.buttonPartSearch.Name = "buttonPartSearch";
            this.buttonPartSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonPartSearch.TabIndex = 5;
            this.buttonPartSearch.Text = "Search";
            this.buttonPartSearch.UseVisualStyleBackColor = true;
            this.buttonPartSearch.Click += new System.EventHandler(this.buttonPartSearch_Click);
            // 
            // buttonProductSearch
            // 
            this.buttonProductSearch.Location = new System.Drawing.Point(746, 48);
            this.buttonProductSearch.Name = "buttonProductSearch";
            this.buttonProductSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonProductSearch.TabIndex = 6;
            this.buttonProductSearch.Text = "Search";
            this.buttonProductSearch.UseVisualStyleBackColor = true;
            this.buttonProductSearch.Click += new System.EventHandler(this.buttonProductSearch_Click);
            // 
            // buttonPartDelete
            // 
            this.buttonPartDelete.Location = new System.Drawing.Point(424, 334);
            this.buttonPartDelete.Name = "buttonPartDelete";
            this.buttonPartDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonPartDelete.TabIndex = 7;
            this.buttonPartDelete.Text = "Delete";
            this.buttonPartDelete.UseVisualStyleBackColor = true;
            this.buttonPartDelete.Click += new System.EventHandler(this.buttonPartDelete_Click);
            // 
            // buttonPartModify
            // 
            this.buttonPartModify.Location = new System.Drawing.Point(343, 334);
            this.buttonPartModify.Name = "buttonPartModify";
            this.buttonPartModify.Size = new System.Drawing.Size(75, 23);
            this.buttonPartModify.TabIndex = 8;
            this.buttonPartModify.Text = "Modify";
            this.buttonPartModify.UseVisualStyleBackColor = true;
            this.buttonPartModify.Click += new System.EventHandler(this.buttonPartModify_Click);
            // 
            // buttonPartAdd
            // 
            this.buttonPartAdd.Location = new System.Drawing.Point(262, 334);
            this.buttonPartAdd.Name = "buttonPartAdd";
            this.buttonPartAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonPartAdd.TabIndex = 9;
            this.buttonPartAdd.Text = "Add";
            this.buttonPartAdd.UseVisualStyleBackColor = true;
            this.buttonPartAdd.Click += new System.EventHandler(this.buttonPartAdd_Click);
            // 
            // buttonProductDelete
            // 
            this.buttonProductDelete.Location = new System.Drawing.Point(916, 334);
            this.buttonProductDelete.Name = "buttonProductDelete";
            this.buttonProductDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonProductDelete.TabIndex = 10;
            this.buttonProductDelete.Text = "Delete";
            this.buttonProductDelete.UseVisualStyleBackColor = true;
            this.buttonProductDelete.Click += new System.EventHandler(this.buttonProductDelete_Click);
            // 
            // buttonProductModify
            // 
            this.buttonProductModify.Location = new System.Drawing.Point(835, 334);
            this.buttonProductModify.Name = "buttonProductModify";
            this.buttonProductModify.Size = new System.Drawing.Size(75, 23);
            this.buttonProductModify.TabIndex = 11;
            this.buttonProductModify.Text = "Modify";
            this.buttonProductModify.UseVisualStyleBackColor = true;
            this.buttonProductModify.Click += new System.EventHandler(this.buttonProductModify_Click);
            // 
            // buttonProductAdd
            // 
            this.buttonProductAdd.Location = new System.Drawing.Point(754, 334);
            this.buttonProductAdd.Name = "buttonProductAdd";
            this.buttonProductAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonProductAdd.TabIndex = 12;
            this.buttonProductAdd.Text = "Add";
            this.buttonProductAdd.UseVisualStyleBackColor = true;
            this.buttonProductAdd.Click += new System.EventHandler(this.buttonProductAdd_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(928, 390);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(63, 45);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Parts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(512, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Products";
            // 
            // dataGridViewPart
            // 
            this.dataGridViewPart.AllowUserToAddRows = false;
            this.dataGridViewPart.AllowUserToDeleteRows = false;
            this.dataGridViewPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPart.Location = new System.Drawing.Point(24, 77);
            this.dataGridViewPart.Name = "dataGridViewPart";
            this.dataGridViewPart.ReadOnly = true;
            this.dataGridViewPart.RowHeadersVisible = false;
            this.dataGridViewPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPart.Size = new System.Drawing.Size(475, 251);
            this.dataGridViewPart.TabIndex = 16;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.AllowUserToAddRows = false;
            this.dataGridViewProduct.AllowUserToDeleteRows = false;
            this.dataGridViewProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(516, 77);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowHeadersVisible = false;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.Size = new System.Drawing.Size(475, 251);
            this.dataGridViewProduct.TabIndex = 17;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 461);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.dataGridViewPart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonProductAdd);
            this.Controls.Add(this.buttonProductModify);
            this.Controls.Add(this.buttonProductDelete);
            this.Controls.Add(this.buttonPartAdd);
            this.Controls.Add(this.buttonPartModify);
            this.Controls.Add(this.buttonPartDelete);
            this.Controls.Add(this.buttonProductSearch);
            this.Controls.Add(this.buttonPartSearch);
            this.Controls.Add(this.textBoxProductSearch);
            this.Controls.Add(this.textBoxPartSearch);
            this.Controls.Add(this.label1);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPartSearch;
        private System.Windows.Forms.TextBox textBoxProductSearch;
        private System.Windows.Forms.Button buttonPartSearch;
        private System.Windows.Forms.Button buttonProductSearch;
        private System.Windows.Forms.Button buttonPartDelete;
        private System.Windows.Forms.Button buttonPartModify;
        private System.Windows.Forms.Button buttonPartAdd;
        private System.Windows.Forms.Button buttonProductDelete;
        private System.Windows.Forms.Button buttonProductModify;
        private System.Windows.Forms.Button buttonProductAdd;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewPart;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
    }
}

