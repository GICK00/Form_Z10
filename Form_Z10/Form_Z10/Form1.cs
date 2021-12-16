using System;
using System.IO;
using System.Windows.Forms;

namespace Form_Z10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonCreateFolder_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            string path = "C:\\temp";
            if (Directory.Exists(path) == true)
                Directory.Delete(path, true);

            DirectoryInfo dir = new DirectoryInfo(path);
            dir.CreateSubdirectory("K1");
            dir.CreateSubdirectory("K2");

            CreateFile(path);

            File.AppendAllText(path + "\\K2\\t3.txt", File.ReadAllText(path + "\\K1\\t1.txt"));
            File.AppendAllText(path + "\\K2\\t3.txt", File.ReadAllText(path + "\\K1\\t2.txt"));

            FileInfo(path);
            textBoxResult.Text += "\r\n";

            File.Move(path + "\\K1\\t2.txt", path + "\\K2\\t2.txt");
            File.Copy(path + "\\K1\\t1.txt", path + "\\K2\\t1.txt");

            Directory.Move(path + "\\K2", path + "\\ALL");
            Directory.Delete(path + "\\K1", true);

            FileInfo(path);
        }
        private void buttonOpen_Click(object sender, EventArgs e)
        { 
            if (Directory.Exists("C:\\temp") == false)
                textBoxResult.Text = "Создайте папку!";
            else
                System.Diagnostics.Process.Start("C:\\temp");
        }
        static void CreateFile(string path)
        {
            StreamWriter t1 = new StreamWriter(new FileStream(path + "\\K1\\t1.txt", FileMode.Create));
            t1.WriteLine("Утин Дмитрий Сергеевич, 2003 года рождения, место жительства г.Радужный");
            StreamWriter t2 = new StreamWriter(new FileStream(path + "\\K1\\t2.txt", FileMode.Create));
            t2.WriteLine("Утина Юлия Ивановна, 1983 года рождения, место жительства г.Радужный");
            StreamWriter t3 = new StreamWriter(new FileStream(path + "\\K2\\t3.txt", FileMode.Create));
            t1.Close();
            t2.Close();
            t3.Close();
        }
        public void FileInfo(string path)
        {
            string[] files;
            textBoxResult.Text += "\rПодкаталоги в " + path;
            string[] dirs = Directory.GetDirectories(path);
            foreach (string s in dirs)
            {
                textBoxResult.Text += "\r\n" + s;
            }
            textBoxResult.Text += "\r\n";

            if (Directory.Exists(path + "\\K1") == true)
            {
                textBoxResult.Text += "\r\nФайлы в " + path + "\\K1";
                files = Directory.GetFiles(path + "\\K1");
                foreach (string s in files)
                {
                    textBoxResult.Text += "\r\n" + s;
                }
                textBoxResult.Text += "\r\n";
            }

            if (Directory.Exists(path + "\\K2") == true)
            {
                textBoxResult.Text += "\r\nФайлы в " + path + "\\K2";
                files = Directory.GetFiles(path + "\\K2");
                foreach (string s in files)
                {
                    textBoxResult.Text += "\r\n" + s;
                }
                textBoxResult.Text += "\r\n";
            }

            if (Directory.Exists(path + "\\ALL") == true)
            {
                textBoxResult.Text += "\r\nФайлы в " + path + "\\ALL";
                files = Directory.GetFiles(path + "\\ALl");
                foreach (string s in files)
                {
                    textBoxResult.Text += "\r\n" + s;
                }
                textBoxResult.Text += "\r\n";
            }
        }
    }
}