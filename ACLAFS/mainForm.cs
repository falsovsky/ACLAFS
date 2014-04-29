using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

            if (identificadorTxt.Text.Length > 0)
            {
                procurarBtn.Enabled = true;
            }

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
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            a.ApplyAcl(getAclString(), recursiveChkBox.Checked);
            UpdateCheckboxes();
        }


    }
}
