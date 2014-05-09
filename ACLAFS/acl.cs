using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACLAFS
{
    class acl
    {
        public Dictionary<string, int> acls = new Dictionary<string, int>();
        public String identifier = "";
        public String directory = "";
        public List<String> directories;

        public acl()
        {
            this.acls.Add("r", 0);
            this.acls.Add("l", 0);
            this.acls.Add("i", 0);
            this.acls.Add("d", 0);
            this.acls.Add("w", 0);
            this.acls.Add("k", 0);
            this.acls.Add("a", 0);

            this.directories = new List<String>();
        }

        public Boolean ParseFSOutput() {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "fs.exe";
            p.StartInfo.Arguments = "listacl \"" + this.directory + "\"";
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            string outputError = p.StandardError.ReadToEnd();

            p.WaitForExit();

            if (p.ExitCode != 0)
            {
                MessageBox.Show("Are you sure this folder is an AFS folder?\n\n" +
                    outputError,
                    "Error reading folder ACL",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.acls["r"] = 0;
            this.acls["l"] = 0;
            this.acls["i"] = 0;
            this.acls["d"] = 0;
            this.acls["w"] = 0;
            this.acls["k"] = 0;
            this.acls["a"] = 0;

            // Partir o output por varias linhas
            var lines = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string s in lines)
            {
                // Achei ACL para este identificador
                if (s.Trim().StartsWith(this.identifier + " ")) {
                    String r = s.Trim().Substring(this.identifier.Length);
                    
                    //Parsar as acls
                    if (r.IndexOf("r") != -1) { this.acls["r"] = 1; } else { this.acls["r"] = 0; }
                    if (r.IndexOf("l") != -1) { this.acls["l"] = 1; } else { this.acls["l"] = 0; }
                    if (r.IndexOf("i") != -1) { this.acls["i"] = 1; } else { this.acls["i"] = 0; }
                    if (r.IndexOf("d") != -1) { this.acls["d"] = 1; } else { this.acls["d"] = 0; }
                    if (r.IndexOf("w") != -1) { this.acls["w"] = 1; } else { this.acls["w"] = 0; }
                    if (r.IndexOf("k") != -1) { this.acls["k"] = 1; } else { this.acls["k"] = 0; }
                    if (r.IndexOf("a") != -1) { this.acls["a"] = 1; } else { this.acls["a"] = 0; }
                }
            }

            return true;
        }

        public void ApplyAcl(String acl, Boolean recursive = false)
        {
            if (recursive == true)
            {
                this.directories.Clear();
                getRecursiveDirectories(this.directory);
                foreach (String s in this.directories)
                {
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.FileName = "fs.exe";
                    p.StartInfo.Arguments = "setacl -dir \"" + s + "\" -acl " + this.identifier + " " + acl;
                    p.Start();
                    string output = p.StandardError.ReadToEnd();
                    p.WaitForExit();

                    if (p.ExitCode != 0)
                    {
                        MessageBox.Show("Identifier: \"" + this.identifier + "\"\n" +
                            "Directory: \"" + s + "\"\n" + 
                            "ACL: \"" + acl + "\"\n\n" +
                            output,
                            "Error applying ACL",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            else
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.FileName = "fs.exe";
                p.StartInfo.Arguments = "setacl -dir \"" + this.directory + "\" -acl " + this.identifier + " " + acl;
                p.Start();
                string output = p.StandardError.ReadToEnd();
                p.WaitForExit();

                if (p.ExitCode != 0)
                {
                    MessageBox.Show("Identifier: \"" + this.identifier + "\"\n" +
                        "Directory: \"" + output + "\"\n" +
                        "ACL: \"" + acl + "\"\n\n" +
                        output,
                        "Error applying ACL",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void getRecursiveDirectories(String dir) 
        {
            try
            {
                this.directories.Add(dir);

                foreach (string d in Directory.GetDirectories(dir))
                {
                    getRecursiveDirectories(d);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Boolean ChooseDirectory()
        {
            try
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Choose folder to apply ACL";
                    dialog.ShowNewFolderButton = false;
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;

                    if (this.directory != "")
                    {
                        dialog.SelectedPath = this.directory;
                    }
                    /*
                    else
                    {
                        dialog.SelectedPath = @"Y:\user\p\pe\pedro.oliveira\public\zbr2";
                    }
                    */

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.directory = dialog.SelectedPath;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Opening folder failed because " + exc.Message + " , please try again later.");
                return false;
            }
        }

    }
}
