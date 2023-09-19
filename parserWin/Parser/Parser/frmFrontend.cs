using System.IO;
using System.Runtime.CompilerServices;

namespace Parser
{
    public partial class frmFrontend : Form
    {

        private string path = @"C:\\tmp\\parser\\front";
        private string destination = @"C:\\tmp\\parser\\front-destination";
        public List<string> files = new List<string>();

        public frmFrontend()
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
            if (string.IsNullOrEmpty(this.sleModelFolder.Text))
            {
                MessageBox.Show("Digige um nome para a pasta do modelo");
                return;
            }
            if (string.IsNullOrEmpty(this.sleTitle.Text))
            {
                MessageBox.Show("Digige um titulo para a página ex: Sistema Financeiro");
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
                string newNameDir = directory.Name.Replace("sf", sleNamespace.Text);
                string Dir = destination + @"\" + newNameDir.ToLower();
                Directory.CreateDirectory(Dir);
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }


            foreach (var file in directoryInfo.GetFiles())
            {
                string newname_file = file.Name.Replace("sf", sleNamespace.Text.ToLower());
                string destine = destination + @"\" + file.Directory.Name.Replace("sf", sleNamespace.Text) + @"\" + newname_file;
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
            dest = s.Replace("fff", this.sleNamespace.Text.ToLower())
            .Replace("-namespace-", this.sleNamespace.Text)
            .Replace("ggg", this.sleNamespace.Text.ToUpper())
            .Replace("-modelfolder-", this.sleModelFolder.Text)
            .Replace("-title-", this.sleTitle.Text)
            .Replace("-titlecap-", this.sleTitle.Text.ToUpper());

            return dest;
        }
    }


}