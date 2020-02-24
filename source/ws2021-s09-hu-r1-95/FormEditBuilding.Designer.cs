namespace ws2021_s09_hu_r1_95
{
    partial class FormEditBuilding
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbNameBuilding = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAddressBuilding = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numNoF = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numNoF)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(133, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name:";
            // 
            // tbNameBuilding
            // 
            this.tbNameBuilding.Location = new System.Drawing.Point(211, 38);
            this.tbNameBuilding.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNameBuilding.Name = "tbNameBuilding";
            this.tbNameBuilding.Size = new System.Drawing.Size(653, 30);
            this.tbNameBuilding.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(112, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Address:";
            // 
            // tbAddressBuilding
            // 
            this.tbAddressBuilding.Location = new System.Drawing.Point(211, 85);
            this.tbAddressBuilding.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAddressBuilding.Name = "tbAddressBuilding";
            this.tbAddressBuilding.Size = new System.Drawing.Size(653, 30);
            this.tbAddressBuilding.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(36, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number of Floors:";
            // 
            // numNoF
            // 
            this.numNoF.Location = new System.Drawing.Point(211, 133);
            this.numNoF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numNoF.Name = "numNoF";
            this.numNoF.Size = new System.Drawing.Size(92, 30);
            this.numNoF.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(706, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(788, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 32);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormEditBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 514);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numNoF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAddressBuilding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNameBuilding);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormEditBuilding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEditBuilding";
            ((System.ComponentModel.ISupportInitialize)(this.numNoF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNameBuilding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAddressBuilding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numNoF;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}