namespace Parser
{
    partial class frmBackend
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
            label1 = new Label();
            sleNamespace = new TextBox();
            btCheck1 = new Button();
            slePasta1 = new TreeView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 8);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 7;
            label1.Text = "New Namespace:";
            // 
            // sleNamespace
            // 
            sleNamespace.Location = new Point(14, 37);
            sleNamespace.Name = "sleNamespace";
            sleNamespace.Size = new Size(221, 27);
            sleNamespace.TabIndex = 6;
            // 
            // btCheck1
            // 
            btCheck1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btCheck1.Location = new Point(14, 75);
            btCheck1.Name = "btCheck1";
            btCheck1.Size = new Size(221, 29);
            btCheck1.TabIndex = 5;
            btCheck1.Text = "Processar";
            btCheck1.UseVisualStyleBackColor = true;
            btCheck1.Click += btCheck1_Click_1;
            // 
            // slePasta1
            // 
            slePasta1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            slePasta1.Location = new Point(12, 110);
            slePasta1.Name = "slePasta1";
            slePasta1.Size = new Size(223, 468);
            slePasta1.TabIndex = 4;
            // 
            // frmBackend
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 632);
            Controls.Add(label1);
            Controls.Add(sleNamespace);
            Controls.Add(btCheck1);
            Controls.Add(slePasta1);
            Name = "frmBackend";
            Text = "Gerador das classes backend";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox sleNamespace;
        private Button btCheck1;
        private TreeView slePasta1;
    }
}