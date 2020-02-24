namespace ws2021_s09_hu_r1_95
{
    partial class FormAddFlat
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFloor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbReserved = new System.Windows.Forms.ComboBox();
            this.cbOrientation = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numRef = new System.Windows.Forms.NumericUpDown();
            this.numRooms = new System.Windows.Forms.NumericUpDown();
            this.numNetArea = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numBalcony = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNetArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalcony)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ref:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rooms:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Net Area:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Floor:";
            // 
            // cbFloor
            // 
            this.cbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFloor.FormattingEnabled = true;
            this.cbFloor.Location = new System.Drawing.Point(559, 47);
            this.cbFloor.Name = "cbFloor";
            this.cbFloor.Size = new System.Drawing.Size(121, 32);
            this.cbFloor.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Orientetion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Balcony Area:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(459, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "Reserved:";
            // 
            // cbReserved
            // 
            this.cbReserved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReserved.FormattingEnabled = true;
            this.cbReserved.Location = new System.Drawing.Point(559, 216);
            this.cbReserved.Name = "cbReserved";
            this.cbReserved.Size = new System.Drawing.Size(229, 32);
            this.cbReserved.TabIndex = 9;
            // 
            // cbOrientation
            // 
            this.cbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrientation.FormattingEnabled = true;
            this.cbOrientation.Location = new System.Drawing.Point(559, 102);
            this.cbOrientation.Name = "cbOrientation";
            this.cbOrientation.Size = new System.Drawing.Size(121, 32);
            this.cbOrientation.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(830, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 41);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(749, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 41);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numRef
            // 
            this.numRef.Location = new System.Drawing.Point(221, 50);
            this.numRef.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRef.Name = "numRef";
            this.numRef.Size = new System.Drawing.Size(196, 30);
            this.numRef.TabIndex = 18;
            // 
            // numRooms
            // 
            this.numRooms.Location = new System.Drawing.Point(221, 103);
            this.numRooms.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRooms.Name = "numRooms";
            this.numRooms.Size = new System.Drawing.Size(100, 30);
            this.numRooms.TabIndex = 19;
            // 
            // numNetArea
            // 
            this.numNetArea.Location = new System.Drawing.Point(221, 161);
            this.numNetArea.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNetArea.Name = "numNetArea";
            this.numNetArea.Size = new System.Drawing.Size(100, 30);
            this.numNetArea.TabIndex = 20;
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(221, 217);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(100, 30);
            this.numPrice.TabIndex = 21;
            // 
            // numBalcony
            // 
            this.numBalcony.Location = new System.Drawing.Point(559, 161);
            this.numBalcony.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBalcony.Name = "numBalcony";
            this.numBalcony.Size = new System.Drawing.Size(121, 30);
            this.numBalcony.TabIndex = 22;
            // 
            // FormAddFlat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 514);
            this.Controls.Add(this.numBalcony);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.numNetArea);
            this.Controls.Add(this.numRooms);
            this.Controls.Add(this.numRef);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbOrientation);
            this.Controls.Add(this.cbReserved);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbFloor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormAddFlat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Flat";
            ((System.ComponentModel.ISupportInitialize)(this.numRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNetArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalcony)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFloor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbReserved;
        private System.Windows.Forms.ComboBox cbOrientation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numRef;
        private System.Windows.Forms.NumericUpDown numRooms;
        private System.Windows.Forms.NumericUpDown numNetArea;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numBalcony;
    }
}