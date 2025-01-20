namespace DataReader.ux
{
    partial class CFormTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormTable));
            btnLoadTable = new Button();
            btnSaveTable = new Button();
            gridRecords = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)gridRecords).BeginInit();
            SuspendLayout();
            // 
            // btnLoadTable
            // 
            btnLoadTable.Font = new Font("Bahnschrift", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadTable.Image = (Image)resources.GetObject("btnLoadTable.Image");
            btnLoadTable.Location = new Point(185, 660);
            btnLoadTable.Margin = new Padding(4, 5, 4, 5);
            btnLoadTable.Name = "btnLoadTable";
            btnLoadTable.Size = new Size(183, 80);
            btnLoadTable.TabIndex = 5;
            btnLoadTable.Text = "Load";
            btnLoadTable.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnLoadTable.UseVisualStyleBackColor = true;
            btnLoadTable.Click += DoOnAnyCommand;
            // 
            // btnSaveTable
            // 
            btnSaveTable.Font = new Font("Bahnschrift", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveTable.Image = (Image)resources.GetObject("btnSaveTable.Image");
            btnSaveTable.Location = new Point(377, 660);
            btnSaveTable.Margin = new Padding(4, 5, 4, 5);
            btnSaveTable.Name = "btnSaveTable";
            btnSaveTable.Size = new Size(183, 80);
            btnSaveTable.TabIndex = 4;
            btnSaveTable.Text = "Save";
            btnSaveTable.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSaveTable.UseVisualStyleBackColor = true;
            btnSaveTable.Click += DoOnAnyCommand;
            // 
            // gridRecords
            // 
            gridRecords.BackgroundColor = Color.FromArgb(221, 230, 237);
            gridRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRecords.Location = new Point(17, 20);
            gridRecords.Margin = new Padding(4, 5, 4, 5);
            gridRecords.Name = "gridRecords";
            gridRecords.RowHeadersWidth = 62;
            gridRecords.RowTemplate.Height = 25;
            gridRecords.Size = new Size(936, 630);
            gridRecords.TabIndex = 3;
            gridRecords.CellEndEdit += DoOnEditRow;
            gridRecords.RowsAdded += DoOnAddRow;
            gridRecords.KeyDown += DoOnGridKeyDown;
            // 
            // button1
            // 
            button1.Font = new Font("Bahnschrift", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(568, 660);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(183, 80);
            button1.TabIndex = 6;
            button1.Text = "Close";
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.UseVisualStyleBackColor = true;
            button1.Click += Exit;
            // 
            // CFormTable
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 55, 77);
            ClientSize = new Size(964, 750);
            Controls.Add(button1);
            Controls.Add(btnLoadTable);
            Controls.Add(btnSaveTable);
            Controls.Add(gridRecords);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "CFormTable";
            Text = "CFormTable";
            FormClosed += DoOnFormClosed;
            ((System.ComponentModel.ISupportInitialize)gridRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadTable;
        private Button btnSaveTable;
        private DataGridView gridRecords;
        private Button button1;
    }
}