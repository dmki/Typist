namespace LexType;

partial class frmMain
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
        label1 = new Label();
        txtCode = new TextBox();
        cmdPaste = new LinkLabel();
        label2 = new Label();
        updMaxSpeed = new NumericUpDown();
        label3 = new Label();
        chAutoHide = new CheckBox();
        chAutoExit = new CheckBox();
        updAutoExit = new NumericUpDown();
        label4 = new Label();
        cmdStart = new Button();
        linkLabel1 = new LinkLabel();
        ((System.ComponentModel.ISupportInitialize)updMaxSpeed).BeginInit();
        ((System.ComponentModel.ISupportInitialize)updAutoExit).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(303, 15);
        label1.TabIndex = 0;
        label1.Text = "Enter the ID that bot gave you (search for Give Typist ID):";
        // 
        // txtCode
        // 
        txtCode.Location = new Point(12, 27);
        txtCode.Name = "txtCode";
        txtCode.Size = new Size(298, 23);
        txtCode.TabIndex = 1;
        // 
        // cmdPaste
        // 
        cmdPaste.AutoSize = true;
        cmdPaste.Location = new Point(316, 30);
        cmdPaste.Name = "cmdPaste";
        cmdPaste.Size = new Size(35, 15);
        cmdPaste.TabIndex = 2;
        cmdPaste.TabStop = true;
        cmdPaste.Text = "Paste";
        cmdPaste.LinkClicked += cmdPaste_LinkClicked;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 67);
        label2.Name = "label2";
        label2.Size = new Size(231, 15);
        label2.TabIndex = 3;
        label2.Text = "Your max typing speed (chars per minute):";
        // 
        // updMaxSpeed
        // 
        updMaxSpeed.Location = new Point(263, 65);
        updMaxSpeed.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
        updMaxSpeed.Minimum = new decimal(new int[] { 60, 0, 0, 0 });
        updMaxSpeed.Name = "updMaxSpeed";
        updMaxSpeed.Size = new Size(88, 23);
        updMaxSpeed.TabIndex = 4;
        updMaxSpeed.Value = new decimal(new int[] { 180, 0, 0, 0 });
        // 
        // label3
        // 
        label3.Location = new Point(12, 105);
        label3.Name = "label3";
        label3.Size = new Size(339, 54);
        label3.TabIndex = 5;
        label3.Text = "Once you press the Ctrl + Alt + M combination, the last message from Ilexa will be typed into whatever editor you are in. There might be typos, and speed will vary.";
        // 
        // chAutoHide
        // 
        chAutoHide.AutoSize = true;
        chAutoHide.Location = new Point(12, 162);
        chAutoHide.Name = "chAutoHide";
        chAutoHide.Size = new Size(188, 19);
        chAutoHide.TabIndex = 6;
        chAutoHide.Text = "Hide application while it works";
        chAutoHide.UseVisualStyleBackColor = true;
        // 
        // chAutoExit
        // 
        chAutoExit.AutoSize = true;
        chAutoExit.Location = new Point(12, 187);
        chAutoExit.Name = "chAutoExit";
        chAutoExit.Size = new Size(152, 19);
        chAutoExit.TabIndex = 7;
        chAutoExit.Text = "Automatically exit after:";
        chAutoExit.UseVisualStyleBackColor = true;
        // 
        // updAutoExit
        // 
        updAutoExit.Location = new Point(170, 183);
        updAutoExit.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
        updAutoExit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        updAutoExit.Name = "updAutoExit";
        updAutoExit.Size = new Size(60, 23);
        updAutoExit.TabIndex = 8;
        updAutoExit.Value = new decimal(new int[] { 180, 0, 0, 0 });
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(236, 188);
        label4.Name = "label4";
        label4.Size = new Size(50, 15);
        label4.TabIndex = 9;
        label4.Text = "minutes";
        // 
        // cmdStart
        // 
        cmdStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        cmdStart.Location = new Point(12, 222);
        cmdStart.Name = "cmdStart";
        cmdStart.Size = new Size(339, 37);
        cmdStart.TabIndex = 10;
        cmdStart.Text = "START";
        cmdStart.UseVisualStyleBackColor = true;
        cmdStart.Click += cmdStart_Click;
        // 
        // linkLabel1
        // 
        linkLabel1.AutoSize = true;
        linkLabel1.Location = new Point(12, 262);
        linkLabel1.Name = "linkLabel1";
        linkLabel1.Size = new Size(103, 15);
        linkLabel1.TabIndex = 11;
        linkLabel1.TabStop = true;
        linkLabel1.Text = "Advanced options";
        linkLabel1.Visible = false;
        // 
        // frmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(363, 285);
        Controls.Add(linkLabel1);
        Controls.Add(cmdStart);
        Controls.Add(label4);
        Controls.Add(updAutoExit);
        Controls.Add(chAutoExit);
        Controls.Add(chAutoHide);
        Controls.Add(label3);
        Controls.Add(updMaxSpeed);
        Controls.Add(label2);
        Controls.Add(cmdPaste);
        Controls.Add(txtCode);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "frmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "iLexa Typist";
        Load += frmMain_Load;
        ((System.ComponentModel.ISupportInitialize)updMaxSpeed).EndInit();
        ((System.ComponentModel.ISupportInitialize)updAutoExit).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox txtCode;
    private LinkLabel cmdPaste;
    private Label label2;
    private NumericUpDown updMaxSpeed;
    private Label label3;
    private CheckBox chAutoHide;
    private CheckBox chAutoExit;
    private NumericUpDown updAutoExit;
    private Label label4;
    private Button cmdStart;
    private LinkLabel linkLabel1;
}
