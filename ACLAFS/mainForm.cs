using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACLAFS
{
    public partial class mainForm : Form
    {
        acl a;

        public mainForm()
        {
            InitializeComponent();
            a = new acl();
        }
        
        private void procurarBtn_Click(object sender, EventArgs e)
        {
            aclGrp.Enabled = false;
            a.identifier = identificadorTxt.Text;

            if (a.ChooseDirectory())
            {
                directoriaTxt.Text = a.directory;
                if (a.directory != null)
                {
                    UpdateCheckboxes();
                }
            }
        }

        private void UpdateCheckboxes()
        {
            if (a.ParseFSOutput())
            {
                aclGrp.Enabled = true;
                applyBtn.Enabled = true;
                recursiveChkBox.Enabled = true;

                readChkBox.Checked = Convert.ToBoolean(a.acls["r"]);
                lookupChkBox.Checked = Convert.ToBoolean(a.acls["l"]);
                insertChkBox.Checked = Convert.ToBoolean(a.acls["i"]);
                deleteChkBox.Checked = Convert.ToBoolean(a.acls["d"]);
                writeChkBox.Checked = Convert.ToBoolean(a.acls["w"]);
                lockChkBox.Checked = Convert.ToBoolean(a.acls["k"]);
                administerChkBox.Checked = Convert.ToBoolean(a.acls["a"]);
            }
        }

        private String getAclString()
        {
            String output = "";

            if (readChkBox.Checked) { output += "r"; }
            if (lookupChkBox.Checked) { output += "l"; }
            if (insertChkBox.Checked) { output += "i"; }
            if (deleteChkBox.Checked) { output += "d"; }
            if (writeChkBox.Checked) { output += "w"; }
            if (lockChkBox.Checked) { output += "k"; }
            if (administerChkBox.Checked) { output += "a"; }

            // Se não tiver nenhuma ACL definida a ACL é none
            if (output == "")
            {
                output = "none";
            }

            return output;
        }

        private void identificadorTxt_TextChanged(object sender, EventArgs e)
        {
            procurarBtn.Enabled = false;
            if (identificadorTxt.Text.Length > 0) {
                procurarBtn.Enabled = true;
                a.identifier = identificadorTxt.Text;

                if ((identificadorTxt.Text != "") && (directoriaTxt.Text.EndsWith("\\") == false) && Directory.Exists(directoriaTxt.Text) && IsNetworkPath(directoriaTxt.Text))
                {
                    a.identifier = identificadorTxt.Text;
                    a.directory = directoriaTxt.Text;
                    aclGrp.Enabled = true;

                    UpdateCheckboxes();
                }
                else
                {
                    aclGrp.Enabled = false;
                    applyBtn.Enabled = false;
                    recursiveChkBox.Enabled = false;
                }
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            a.identifier = identificadorTxt.Text;
            a.directory = directoriaTxt.Text;
            a.ApplyAcl(getAclString(), recursiveChkBox.Checked);
            UpdateCheckboxes();
        }

        private void directoriaTxt_TextChanged(object sender, EventArgs e)
        {
            if ((identificadorTxt.Text != "") && (directoriaTxt.Text.EndsWith("\\") == false) && Directory.Exists(directoriaTxt.Text) && IsNetworkPath(directoriaTxt.Text))
            {
                a.identifier = identificadorTxt.Text;
                a.directory = directoriaTxt.Text;
                aclGrp.Enabled = true;

                UpdateCheckboxes();
            }
            else
            {
                aclGrp.Enabled = false;
                applyBtn.Enabled = false;
                recursiveChkBox.Enabled = false;
            }
        }

        public static bool IsNetworkPath(string path)
        {
            if (path == "\\") return false;

            if (!path.StartsWith(@"/") && !path.StartsWith(@"\"))
            {
                string rootPath = System.IO.Path.GetPathRoot(path); // get drive's letter
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(rootPath); // get info about the drive
                return driveInfo.DriveType == DriveType.Network; // return true if a network drive
            }

            return true; // is a UNC path
        }

    }
}
