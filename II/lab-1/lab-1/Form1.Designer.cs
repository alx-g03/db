namespace lab_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewParent = new DataGridView();
            dataGridViewChild = new DataGridView();
            deleteButton = new Button();
            updateCustomerIDtextBox = new TextBox();
            updateVINtextBox = new TextBox();
            updateAmountTextBox = new TextBox();
            updatePaymentDateTextBox = new TextBox();
            addPaymentIDtextBox = new TextBox();
            addAmountTextBox = new TextBox();
            addPaymentDateTextBox = new TextBox();
            addButton = new Button();
            updateButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            clearButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChild).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewParent
            // 
            dataGridViewParent.BackgroundColor = SystemColors.Window;
            dataGridViewParent.BorderStyle = BorderStyle.None;
            dataGridViewParent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewParent.Location = new Point(12, 100);
            dataGridViewParent.Name = "dataGridViewParent";
            dataGridViewParent.RowHeadersWidth = 51;
            dataGridViewParent.RowTemplate.Height = 29;
            dataGridViewParent.Size = new Size(760, 456);
            dataGridViewParent.TabIndex = 0;
            // 
            // dataGridViewChild
            // 
            dataGridViewChild.BackgroundColor = SystemColors.Window;
            dataGridViewChild.BorderStyle = BorderStyle.None;
            dataGridViewChild.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChild.Location = new Point(810, 100);
            dataGridViewChild.Name = "dataGridViewChild";
            dataGridViewChild.RowHeadersWidth = 51;
            dataGridViewChild.RowTemplate.Height = 29;
            dataGridViewChild.Size = new Size(760, 456);
            dataGridViewChild.TabIndex = 1;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(825, 729);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // updateCustomerIDtextBox
            // 
            updateCustomerIDtextBox.Location = new Point(810, 661);
            updateCustomerIDtextBox.Name = "updateCustomerIDtextBox";
            updateCustomerIDtextBox.Size = new Size(125, 27);
            updateCustomerIDtextBox.TabIndex = 3;
            // 
            // updateVINtextBox
            // 
            updateVINtextBox.Location = new Point(941, 661);
            updateVINtextBox.Name = "updateVINtextBox";
            updateVINtextBox.Size = new Size(125, 27);
            updateVINtextBox.TabIndex = 4;
            // 
            // updateAmountTextBox
            // 
            updateAmountTextBox.Location = new Point(1072, 661);
            updateAmountTextBox.Name = "updateAmountTextBox";
            updateAmountTextBox.Size = new Size(125, 27);
            updateAmountTextBox.TabIndex = 5;
            // 
            // updatePaymentDateTextBox
            // 
            updatePaymentDateTextBox.Location = new Point(1203, 661);
            updatePaymentDateTextBox.Name = "updatePaymentDateTextBox";
            updatePaymentDateTextBox.Size = new Size(125, 27);
            updatePaymentDateTextBox.TabIndex = 6;
            // 
            // addPaymentIDtextBox
            // 
            addPaymentIDtextBox.Location = new Point(12, 661);
            addPaymentIDtextBox.Name = "addPaymentIDtextBox";
            addPaymentIDtextBox.Size = new Size(125, 27);
            addPaymentIDtextBox.TabIndex = 7;
            // 
            // addAmountTextBox
            // 
            addAmountTextBox.Location = new Point(143, 661);
            addAmountTextBox.Name = "addAmountTextBox";
            addAmountTextBox.Size = new Size(125, 27);
            addAmountTextBox.TabIndex = 8;
            // 
            // addPaymentDateTextBox
            // 
            addPaymentDateTextBox.Location = new Point(274, 661);
            addPaymentDateTextBox.Name = "addPaymentDateTextBox";
            addPaymentDateTextBox.Size = new Size(125, 27);
            addPaymentDateTextBox.TabIndex = 9;
            // 
            // addButton
            // 
            addButton.Location = new Point(24, 729);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 10;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(953, 729);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(94, 29);
            updateButton.TabIndex = 11;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 612);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 12;
            label1.Text = "paymentID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 612);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 13;
            label2.Text = "amount";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(287, 612);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 14;
            label3.Text = "paymentDate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(825, 612);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 15;
            label4.Text = "customerID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(989, 612);
            label5.Name = "label5";
            label5.Size = new Size(33, 20);
            label5.TabIndex = 16;
            label5.Text = "VIN";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1099, 612);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 17;
            label6.Text = "amount";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1215, 612);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 18;
            label7.Text = "paymentDate";
            // 
            // clearButton
            // 
            clearButton.Location = new Point(153, 729);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(94, 29);
            clearButton.TabIndex = 19;
            clearButton.Text = "Clear text";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1582, 853);
            Controls.Add(clearButton);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(updateButton);
            Controls.Add(addButton);
            Controls.Add(addPaymentDateTextBox);
            Controls.Add(addAmountTextBox);
            Controls.Add(addPaymentIDtextBox);
            Controls.Add(updatePaymentDateTextBox);
            Controls.Add(updateAmountTextBox);
            Controls.Add(updateVINtextBox);
            Controls.Add(updateCustomerIDtextBox);
            Controls.Add(deleteButton);
            Controls.Add(dataGridViewChild);
            Controls.Add(dataGridViewParent);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewParent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChild).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewParent;
        private DataGridView dataGridViewChild;
        private Button deleteButton;
        private TextBox updateCustomerIDtextBox;
        private TextBox updateVINtextBox;
        private TextBox updateAmountTextBox;
        private TextBox updatePaymentDateTextBox;
        private TextBox addPaymentIDtextBox;
        private TextBox addAmountTextBox;
        private TextBox addPaymentDateTextBox;
        private Button addButton;
        private Button updateButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button clearButton;
    }
}