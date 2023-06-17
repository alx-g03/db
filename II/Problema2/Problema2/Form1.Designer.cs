namespace Problema2
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
            addButton = new Button();
            updateButton = new Button();
            textBox0 = new TextBox();
            label0 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
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
            deleteButton.Location = new Point(750, 736);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(621, 736);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 10;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(878, 736);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(94, 29);
            updateButton.TabIndex = 11;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // textBox0
            // 
            textBox0.Location = new Point(448, 654);
            textBox0.Name = "textBox0";
            textBox0.Size = new Size(125, 27);
            textBox0.TabIndex = 22;
            // 
            // label0
            // 
            label0.AutoSize = true;
            label0.Location = new Point(470, 605);
            label0.Name = "label0";
            label0.Size = new Size(95, 20);
            label0.TabIndex = 23;
            label0.Text = "cod_melodie";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(629, 605);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 25;
            label1.Text = "titlu";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(590, 654);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(751, 605);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 27;
            label2.Text = "an_lansare";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(733, 654);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(911, 605);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 29;
            label3.Text = "durata";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(878, 654);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1043, 605);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 31;
            label4.Text = "cod_artist";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1024, 654);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1582, 853);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label0);
            Controls.Add(textBox0);
            Controls.Add(updateButton);
            Controls.Add(addButton);
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
        private Button addButton;
        private Button updateButton;
        private TextBox textBox0;
        private Label label0;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
    }
}