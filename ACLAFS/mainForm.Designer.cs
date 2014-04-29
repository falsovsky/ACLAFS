namespace ACLAFS
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.directoriaTxt = new System.Windows.Forms.TextBox();
            this.procurarBtn = new System.Windows.Forms.Button();
            this.identificadorLbl = new System.Windows.Forms.Label();
            this.identificadorTxt = new System.Windows.Forms.TextBox();
            this.aclGrp = new System.Windows.Forms.GroupBox();
            this.administerChkBox = new System.Windows.Forms.CheckBox();
            this.lockChkBox = new System.Windows.Forms.CheckBox();
            this.writeChkBox = new System.Windows.Forms.CheckBox();
            this.deleteChkBox = new System.Windows.Forms.CheckBox();
            this.insertChkBox = new System.Windows.Forms.CheckBox();
            this.lookupChkBox = new System.Windows.Forms.CheckBox();
            this.readChkBox = new System.Windows.Forms.CheckBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.recursiveChkBox = new System.Windows.Forms.CheckBox();
            this.aclGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoriaTxt
            // 
            this.directoriaTxt.Location = new System.Drawing.Point(12, 35);
            this.directoriaTxt.Name = "directoriaTxt";
            this.directoriaTxt.Size = new System.Drawing.Size(188, 20);
            this.directoriaTxt.TabIndex = 2;
            this.directoriaTxt.TextChanged += new System.EventHandler(this.directoriaTxt_TextChanged);
            // 
            // procurarBtn
            // 
            this.procurarBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.procurarBtn.Enabled = false;
            this.procurarBtn.Location = new System.Drawing.Point(206, 35);
            this.procurarBtn.Name = "procurarBtn";
            this.procurarBtn.Size = new System.Drawing.Size(75, 23);
            this.procurarBtn.TabIndex = 3;
            this.procurarBtn.Text = "Browse...";
            this.procurarBtn.UseVisualStyleBackColor = true;
            this.procurarBtn.Click += new System.EventHandler(this.procurarBtn_Click);
            // 
            // identificadorLbl
            // 
            this.identificadorLbl.AutoSize = true;
            this.identificadorLbl.Location = new System.Drawing.Point(13, 9);
            this.identificadorLbl.Name = "identificadorLbl";
            this.identificadorLbl.Size = new System.Drawing.Size(50, 13);
            this.identificadorLbl.TabIndex = 2;
            this.identificadorLbl.Text = "Identifier:";
            // 
            // identificadorTxt
            // 
            this.identificadorTxt.Location = new System.Drawing.Point(87, 9);
            this.identificadorTxt.Name = "identificadorTxt";
            this.identificadorTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.identificadorTxt.Size = new System.Drawing.Size(194, 20);
            this.identificadorTxt.TabIndex = 1;
            this.identificadorTxt.WordWrap = false;
            this.identificadorTxt.TextChanged += new System.EventHandler(this.identificadorTxt_TextChanged);
            // 
            // aclGrp
            // 
            this.aclGrp.Controls.Add(this.administerChkBox);
            this.aclGrp.Controls.Add(this.lockChkBox);
            this.aclGrp.Controls.Add(this.writeChkBox);
            this.aclGrp.Controls.Add(this.deleteChkBox);
            this.aclGrp.Controls.Add(this.insertChkBox);
            this.aclGrp.Controls.Add(this.lookupChkBox);
            this.aclGrp.Controls.Add(this.readChkBox);
            this.aclGrp.Enabled = false;
            this.aclGrp.Location = new System.Drawing.Point(16, 64);
            this.aclGrp.Name = "aclGrp";
            this.aclGrp.Size = new System.Drawing.Size(266, 120);
            this.aclGrp.TabIndex = 4;
            this.aclGrp.TabStop = false;
            this.aclGrp.Text = "ACLs";
            // 
            // administerChkBox
            // 
            this.administerChkBox.AutoSize = true;
            this.administerChkBox.Location = new System.Drawing.Point(172, 65);
            this.administerChkBox.Name = "administerChkBox";
            this.administerChkBox.Size = new System.Drawing.Size(88, 17);
            this.administerChkBox.TabIndex = 10;
            this.administerChkBox.Text = "a - administer";
            this.administerChkBox.UseVisualStyleBackColor = true;
            // 
            // lockChkBox
            // 
            this.lockChkBox.AutoSize = true;
            this.lockChkBox.Location = new System.Drawing.Point(172, 42);
            this.lockChkBox.Name = "lockChkBox";
            this.lockChkBox.Size = new System.Drawing.Size(61, 17);
            this.lockChkBox.TabIndex = 9;
            this.lockChkBox.Text = "k - lock";
            this.lockChkBox.UseVisualStyleBackColor = true;
            // 
            // writeChkBox
            // 
            this.writeChkBox.AutoSize = true;
            this.writeChkBox.Location = new System.Drawing.Point(172, 19);
            this.writeChkBox.Name = "writeChkBox";
            this.writeChkBox.Size = new System.Drawing.Size(65, 17);
            this.writeChkBox.TabIndex = 8;
            this.writeChkBox.Text = "w - write";
            this.writeChkBox.UseVisualStyleBackColor = true;
            // 
            // deleteChkBox
            // 
            this.deleteChkBox.AutoSize = true;
            this.deleteChkBox.Location = new System.Drawing.Point(6, 91);
            this.deleteChkBox.Name = "deleteChkBox";
            this.deleteChkBox.Size = new System.Drawing.Size(70, 17);
            this.deleteChkBox.TabIndex = 7;
            this.deleteChkBox.Text = "d - delete";
            this.deleteChkBox.UseVisualStyleBackColor = true;
            // 
            // insertChkBox
            // 
            this.insertChkBox.AutoSize = true;
            this.insertChkBox.Location = new System.Drawing.Point(6, 67);
            this.insertChkBox.Name = "insertChkBox";
            this.insertChkBox.Size = new System.Drawing.Size(62, 17);
            this.insertChkBox.TabIndex = 6;
            this.insertChkBox.Text = "i - insert";
            this.insertChkBox.UseVisualStyleBackColor = true;
            // 
            // lookupChkBox
            // 
            this.lookupChkBox.AutoSize = true;
            this.lookupChkBox.Location = new System.Drawing.Point(6, 43);
            this.lookupChkBox.Name = "lookupChkBox";
            this.lookupChkBox.Size = new System.Drawing.Size(69, 17);
            this.lookupChkBox.TabIndex = 5;
            this.lookupChkBox.Text = "l - lookup";
            this.lookupChkBox.UseVisualStyleBackColor = true;
            // 
            // readChkBox
            // 
            this.readChkBox.AutoSize = true;
            this.readChkBox.Location = new System.Drawing.Point(6, 19);
            this.readChkBox.Name = "readChkBox";
            this.readChkBox.Size = new System.Drawing.Size(59, 17);
            this.readChkBox.TabIndex = 4;
            this.readChkBox.Text = "r - read";
            this.readChkBox.UseVisualStyleBackColor = true;
            // 
            // applyBtn
            // 
            this.applyBtn.Enabled = false;
            this.applyBtn.Location = new System.Drawing.Point(205, 191);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 12;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // recursiveChkBox
            // 
            this.recursiveChkBox.AutoSize = true;
            this.recursiveChkBox.Enabled = false;
            this.recursiveChkBox.Location = new System.Drawing.Point(119, 193);
            this.recursiveChkBox.Name = "recursiveChkBox";
            this.recursiveChkBox.Size = new System.Drawing.Size(69, 17);
            this.recursiveChkBox.TabIndex = 11;
            this.recursiveChkBox.Text = "recursive";
            this.recursiveChkBox.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 222);
            this.Controls.Add(this.recursiveChkBox);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.aclGrp);
            this.Controls.Add(this.identificadorTxt);
            this.Controls.Add(this.identificadorLbl);
            this.Controls.Add(this.procurarBtn);
            this.Controls.Add(this.directoriaTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ACL AFS";
            this.aclGrp.ResumeLayout(false);
            this.aclGrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox directoriaTxt;
        private System.Windows.Forms.Button procurarBtn;
        private System.Windows.Forms.Label identificadorLbl;
        private System.Windows.Forms.TextBox identificadorTxt;
        private System.Windows.Forms.GroupBox aclGrp;
        public System.Windows.Forms.CheckBox insertChkBox;
        public System.Windows.Forms.CheckBox lookupChkBox;
        public System.Windows.Forms.CheckBox readChkBox;
        public System.Windows.Forms.CheckBox administerChkBox;
        public System.Windows.Forms.CheckBox lockChkBox;
        public System.Windows.Forms.CheckBox writeChkBox;
        public System.Windows.Forms.CheckBox deleteChkBox;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.CheckBox recursiveChkBox;
    }
}

