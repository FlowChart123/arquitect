namespace Parser
{
    partial class frmFrontend
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            sleTitle = new TextBox();
            label2 = new Label();
            sleModelFolder = new TextBox();
            label1 = new Label();
            sleNamespace = new TextBox();
            btCheck1 = new Button();
            slePasta1 = new TreeView();
            label8 = new Label();
            label9 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(860, 642);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(sleTitle);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(sleModelFolder);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(sleNamespace);
            tabPage1.Controls.Add(btCheck1);
            tabPage1.Controls.Add(slePasta1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(852, 609);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Frontend";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(370, 340);
            label7.Name = "label7";
            label7.Size = new Size(292, 20);
            label7.TabIndex = 11;
            label7.Text = "- implementar os campos no form e no list";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(370, 303);
            label6.Name = "label6";
            label6.Size = new Size(195, 20);
            label6.TabIndex = 10;
            label6.Text = "- adicionar o link no sidebar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(370, 272);
            label5.Name = "label5";
            label5.Size = new Size(180, 20);
            label5.TabIndex = 9;
            label5.Text = "- criar a model e a service";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(292, 227);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 8;
            label4.Text = "Próximos passos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(492, 27);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 7;
            label3.Text = "Título da Página:";
            // 
            // sleTitle
            // 
            sleTitle.Location = new Point(489, 56);
            sleTitle.Name = "sleTitle";
            sleTitle.Size = new Size(221, 27);
            sleTitle.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(251, 27);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 5;
            label2.Text = "Model-Folder:";
            // 
            // sleModelFolder
            // 
            sleModelFolder.Location = new Point(248, 56);
            sleModelFolder.Name = "sleModelFolder";
            sleModelFolder.Size = new Size(221, 27);
            sleModelFolder.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 27);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 3;
            label1.Text = "New Namespace:";
            // 
            // sleNamespace
            // 
            sleNamespace.Location = new Point(10, 56);
            sleNamespace.Name = "sleNamespace";
            sleNamespace.Size = new Size(221, 27);
            sleNamespace.TabIndex = 2;
            // 
            // btCheck1
            // 
            btCheck1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btCheck1.Location = new Point(10, 89);
            btCheck1.Name = "btCheck1";
            btCheck1.Size = new Size(221, 29);
            btCheck1.TabIndex = 1;
            btCheck1.Text = "Processar";
            btCheck1.UseVisualStyleBackColor = true;
            btCheck1.Click += btCheck1_Click;
            // 
            // slePasta1
            // 
            slePasta1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            slePasta1.Location = new Point(8, 124);
            slePasta1.Name = "slePasta1";
            slePasta1.Size = new Size(223, 468);
            slePasta1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(292, 124);
            label8.Name = "label8";
            label8.Size = new Size(371, 20);
            label8.TabIndex = 12;
            label8.Text = "AS PASTAS DE ORIGEM ESTÃO NO C:\\TMP\\ARQUITECT";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(292, 154);
            label9.Name = "label9";
            label9.Size = new Size(273, 20);
            label9.TabIndex = 13;
            label9.Text = "Olhar o código fonte para configuração";
            // 
            // frmFrontend
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 642);
            Controls.Add(tabControl1);
            Name = "frmFrontend";
            Text = "Gerador de Código";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btCheck1;
        private TreeView slePasta1;
        private Label label1;
        private TextBox sleNamespace;
        private Label label2;
        private TextBox sleModelFolder;
        private Label label3;
        private TextBox sleTitle;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Label label8;
    }
}