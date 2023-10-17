namespace life
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.setDensity = new System.Windows.Forms.Button();
            this.KMoveTextBox = new System.Windows.Forms.TextBox();
            this.KMoveBut = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.NeedToBornBox = new System.Windows.Forms.CheckedListBox();
            this.NeedToLiveBox = new System.Windows.Forms.CheckedListBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.densityBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.darkBut = new System.Windows.Forms.Button();
            this.random = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.playBut = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.setDensity);
            this.splitContainer1.Panel1.Controls.Add(this.KMoveTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.KMoveBut);
            this.splitContainer1.Panel1.Controls.Add(this.button6);
            this.splitContainer1.Panel1.Controls.Add(this.NeedToBornBox);
            this.splitContainer1.Panel1.Controls.Add(this.NeedToLiveBox);
            this.splitContainer1.Panel1.Controls.Add(this.ageLabel);
            this.splitContainer1.Panel1.Controls.Add(this.yLabel);
            this.splitContainer1.Panel1.Controls.Add(this.xLabel);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.densityBox);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.darkBut);
            this.splitContainer1.Panel1.Controls.Add(this.random);
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.sizeBox3);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.widthBox);
            this.splitContainer1.Panel1.Controls.Add(this.heightBox);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.playBut);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox);
            // 
            // setDensity
            // 
            resources.ApplyResources(this.setDensity, "setDensity");
            this.setDensity.Name = "setDensity";
            this.setDensity.UseVisualStyleBackColor = true;
            this.setDensity.Click += new System.EventHandler(this.SetDensity);
            // 
            // KMoveTextBox
            // 
            resources.ApplyResources(this.KMoveTextBox, "KMoveTextBox");
            this.KMoveTextBox.Name = "KMoveTextBox";
            // 
            // KMoveBut
            // 
            resources.ApplyResources(this.KMoveBut, "KMoveBut");
            this.KMoveBut.Name = "KMoveBut";
            this.KMoveBut.UseVisualStyleBackColor = true;
            this.KMoveBut.Click += new System.EventHandler(this.GoKMove);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ChangeRules);
            // 
            // NeedToBornBox
            // 
            this.NeedToBornBox.FormattingEnabled = true;
            this.NeedToBornBox.Items.AddRange(new object[] {
            resources.GetString("NeedToBornBox.Items"),
            resources.GetString("NeedToBornBox.Items1"),
            resources.GetString("NeedToBornBox.Items2"),
            resources.GetString("NeedToBornBox.Items3"),
            resources.GetString("NeedToBornBox.Items4"),
            resources.GetString("NeedToBornBox.Items5"),
            resources.GetString("NeedToBornBox.Items6"),
            resources.GetString("NeedToBornBox.Items7"),
            resources.GetString("NeedToBornBox.Items8")});
            resources.ApplyResources(this.NeedToBornBox, "NeedToBornBox");
            this.NeedToBornBox.Name = "NeedToBornBox";
            // 
            // NeedToLiveBox
            // 
            this.NeedToLiveBox.FormattingEnabled = true;
            this.NeedToLiveBox.Items.AddRange(new object[] {
            resources.GetString("NeedToLiveBox.Items"),
            resources.GetString("NeedToLiveBox.Items1"),
            resources.GetString("NeedToLiveBox.Items2"),
            resources.GetString("NeedToLiveBox.Items3"),
            resources.GetString("NeedToLiveBox.Items4"),
            resources.GetString("NeedToLiveBox.Items5"),
            resources.GetString("NeedToLiveBox.Items6"),
            resources.GetString("NeedToLiveBox.Items7"),
            resources.GetString("NeedToLiveBox.Items8")});
            resources.ApplyResources(this.NeedToLiveBox, "NeedToLiveBox");
            this.NeedToLiveBox.Name = "NeedToLiveBox";
            // 
            // ageLabel
            // 
            resources.ApplyResources(this.ageLabel, "ageLabel");
            this.ageLabel.Name = "ageLabel";
            // 
            // yLabel
            // 
            resources.ApplyResources(this.yLabel, "yLabel");
            this.yLabel.Name = "yLabel";
            // 
            // xLabel
            // 
            resources.ApplyResources(this.xLabel, "xLabel");
            this.xLabel.Name = "xLabel";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // densityBox
            // 
            resources.ApplyResources(this.densityBox, "densityBox");
            this.densityBox.Name = "densityBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearOnClick);
            // 
            // darkBut
            // 
            resources.ApplyResources(this.darkBut, "darkBut");
            this.darkBut.Name = "darkBut";
            this.darkBut.UseVisualStyleBackColor = true;
            this.darkBut.Click += new System.EventHandler(this.ChangeTheme);
            // 
            // random
            // 
            resources.ApplyResources(this.random, "random");
            this.random.Name = "random";
            this.random.UseVisualStyleBackColor = true;
            this.random.Click += new System.EventHandler(this.RandomOnClick);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OpenOnClick);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SaveOnClick);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Name = "label1";
            // 
            // sizeBox3
            // 
            resources.ApplyResources(this.sizeBox3, "sizeBox3");
            this.sizeBox3.Name = "sizeBox3";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SetOnClick);
            // 
            // widthBox
            // 
            resources.ApplyResources(this.widthBox, "widthBox");
            this.widthBox.Name = "widthBox";
            // 
            // heightBox
            // 
            resources.ApplyResources(this.heightBox, "heightBox");
            this.heightBox.Name = "heightBox";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Next);
            // 
            // playBut
            // 
            resources.ApplyResources(this.playBut, "playBut");
            this.playBut.Name = "playBut";
            this.playBut.UseVisualStyleBackColor = true;
            this.playBut.Click += new System.EventHandler(this.PlayOnClick);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowInformation);
            // 
            // time
            // 
            this.time.Enabled = true;
            this.time.Interval = 20;
            this.time.Tick += new System.EventHandler(this.Next);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button playBut;
        private System.Windows.Forms.TextBox widthBox;
        public System.Windows.Forms.Timer time;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sizeBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button random;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button darkBut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox densityBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox NeedToLiveBox;
        private System.Windows.Forms.CheckedListBox NeedToBornBox;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox KMoveTextBox;
        private System.Windows.Forms.Button KMoveBut;
        private System.Windows.Forms.Button setDensity;
    }
}

