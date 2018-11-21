namespace EntranceApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCheckIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCheckIn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxCheckOut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.idTicketTb = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.textBoxCheckIn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonCheckIn);
            this.panel1.Location = new System.Drawing.Point(36, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 95);
            this.panel1.TabIndex = 0;
            // 
            // textBoxCheckIn
            // 
            this.textBoxCheckIn.Location = new System.Drawing.Point(179, 38);
            this.textBoxCheckIn.Name = "textBoxCheckIn";
            this.textBoxCheckIn.Size = new System.Drawing.Size(439, 26);
            this.textBoxCheckIn.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ticket ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonCheckIn
            // 
            this.buttonCheckIn.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckIn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCheckIn.Location = new System.Drawing.Point(686, 29);
            this.buttonCheckIn.Name = "buttonCheckIn";
            this.buttonCheckIn.Size = new System.Drawing.Size(127, 45);
            this.buttonCheckIn.TabIndex = 0;
            this.buttonCheckIn.Text = "Check In";
            this.buttonCheckIn.UseVisualStyleBackColor = false;
            this.buttonCheckIn.Click += new System.EventHandler(this.buttonCheckIn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.textBoxCheckOut);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonCheckOut);
            this.panel2.Location = new System.Drawing.Point(36, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 95);
            this.panel2.TabIndex = 1;
            // 
            // textBoxCheckOut
            // 
            this.textBoxCheckOut.Location = new System.Drawing.Point(179, 38);
            this.textBoxCheckOut.Name = "textBoxCheckOut";
            this.textBoxCheckOut.Size = new System.Drawing.Size(439, 26);
            this.textBoxCheckOut.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ticket ID:";
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheckOut.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCheckOut.Location = new System.Drawing.Point(686, 29);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(127, 45);
            this.buttonCheckOut.TabIndex = 0;
            this.buttonCheckOut.Text = "Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = false;
            this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
            // 
            // idTicketTb
            // 
            this.idTicketTb.Enabled = false;
            this.idTicketTb.Location = new System.Drawing.Point(215, 180);
            this.idTicketTb.Name = "idTicketTb";
            this.idTicketTb.Size = new System.Drawing.Size(439, 26);
            this.idTicketTb.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(946, 434);
            this.Controls.Add(this.idTicketTb);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCheckIn;
        private System.Windows.Forms.TextBox textBoxCheckIn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxCheckOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.TextBox idTicketTb;
    }
}

