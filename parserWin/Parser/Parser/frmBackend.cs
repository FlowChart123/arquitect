using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class frmBackend : Form
    {

        private string path = @"C:\\tmp\\parser\\back";
        private string destination = @"C:\\tmp\\parser\\back-destination";
        public List<string> files = new List<string>();

        public frmBackend()
        {
            InitializeComponent();
        }

        private void btCheck1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.sleNamespace.Text))
            {
                MessageBox.Show("Digige um nome para o novo namespace");
                return;
            }
         
            this.files.Clear();
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            else
            {
                MessageBox.Show("A pasta de destina não está vazia");
                return;
            }

            this.ListDirectory(this.slePasta1, path);
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                string originalDir = directory.Name;
                string newNameDir = directory.Name.Replace("Categoria", sleNamespace.Text);
                string Dir = destination + @"\" + newNameDir.ToLower();
                Directory.CreateDirectory(Dir);
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }


            foreach (var file in directoryInfo.GetFiles())
            {
                string newname_file = file.Name.Replace("Categoria", sleNamespace.Text.ToLower());
                string destine = destination + @"\" + file.Directory.Name.Replace("Categoria", sleNamespace.Text) + @"\" + newname_file;
                //File.Copy(file.FullName, destine);
                //ao invés de apenas copiar, salvar a string parseada
                processaTags(file.FullName, destine);
                directoryNode.Nodes.Add(new TreeNode(file.Name));

            }

            return directoryNode;
        }


        private void processaTags(string origemFileName, string destinationFileName)
        {
            string a = System.IO.File.ReadAllText(origemFileName);
            string b = replacer(a);
            System.IO.File.WriteAllText(destinationFileName, b);
        }
        private string replacer(string s)
        {
            string dest = "";
            dest = s.Replace("Categoria", this.sleNamespace.Text.ToLower());

            return dest;
        }

        private void btCheck1_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.sleNamespace.Text))
            {
                MessageBox.Show("Digige um nome para o novo namespace");
                return;
            }
            
            this.files.Clear();
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            else
            {
                MessageBox.Show("A pasta de destina não está vazia");
                return;
            }

            this.ListDirectory(this.slePasta1, path);
        }
    }
}
