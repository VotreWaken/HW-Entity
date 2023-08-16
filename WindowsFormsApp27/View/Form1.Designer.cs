namespace WindowsFormsApp27
{
    partial class Form1
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
            this.AuthorLB = new System.Windows.Forms.ListBox();
            this.BookLB = new System.Windows.Forms.ListBox();
            this.RequestCB = new System.Windows.Forms.ComboBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.SurnameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.IdTB = new System.Windows.Forms.TextBox();
            this.FindBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AuthorLB
            // 
            this.AuthorLB.FormattingEnabled = true;
            this.AuthorLB.Location = new System.Drawing.Point(371, 37);
            this.AuthorLB.Name = "AuthorLB";
            this.AuthorLB.Size = new System.Drawing.Size(331, 95);
            this.AuthorLB.TabIndex = 0;
            // 
            // BookLB
            // 
            this.BookLB.FormattingEnabled = true;
            this.BookLB.Location = new System.Drawing.Point(371, 181);
            this.BookLB.Name = "BookLB";
            this.BookLB.Size = new System.Drawing.Size(331, 108);
            this.BookLB.TabIndex = 1;
            // 
            // RequestCB
            // 
            this.RequestCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RequestCB.FormattingEnabled = true;
            this.RequestCB.Location = new System.Drawing.Point(37, 37);
            this.RequestCB.Name = "RequestCB";
            this.RequestCB.Size = new System.Drawing.Size(296, 21);
            this.RequestCB.TabIndex = 2;
            this.RequestCB.SelectedIndexChanged += new System.EventHandler(this.RequestCB_SelectedIndexChanged);
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(37, 143);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(139, 20);
            this.NameTB.TabIndex = 3;
            // 
            // SurnameTB
            // 
            this.SurnameTB.Location = new System.Drawing.Point(34, 194);
            this.SurnameTB.Name = "SurnameTB";
            this.SurnameTB.Size = new System.Drawing.Size(142, 20);
            this.SurnameTB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Surname:";
            // 
            // CreateBtn
            // 
            this.CreateBtn.Enabled = false;
            this.CreateBtn.Location = new System.Drawing.Point(34, 238);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(66, 23);
            this.CreateBtn.TabIndex = 7;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Id:";
            // 
            // IdTB
            // 
            this.IdTB.Location = new System.Drawing.Point(37, 93);
            this.IdTB.Name = "IdTB";
            this.IdTB.Size = new System.Drawing.Size(139, 20);
            this.IdTB.TabIndex = 8;
            // 
            // FindBtn
            // 
            this.FindBtn.Enabled = false;
            this.FindBtn.Location = new System.Drawing.Point(106, 238);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(70, 23);
            this.FindBtn.TabIndex = 10;
            this.FindBtn.Text = "Find";
            this.FindBtn.UseVisualStyleBackColor = true;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Enabled = false;
            this.UpdateBtn.Location = new System.Drawing.Point(182, 238);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(70, 23);
            this.UpdateBtn.TabIndex = 11;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 353);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.FindBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IdTB);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SurnameTB);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.RequestCB);
            this.Controls.Add(this.BookLB);
            this.Controls.Add(this.AuthorLB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AuthorLB;
        private System.Windows.Forms.ListBox BookLB;
        private System.Windows.Forms.ComboBox RequestCB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox SurnameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IdTB;
        private System.Windows.Forms.Button FindBtn;
        private System.Windows.Forms.Button UpdateBtn;
    }
}

