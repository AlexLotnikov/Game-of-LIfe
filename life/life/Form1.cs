using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace life
{


    public partial class Form1 : Form
    {
        decimal density = 0.5m;
        int size = 40;
        int xdef = 10, ydef = 10;
        int xs, ys;
        bool HasTable=false, playing = false, dark = false;
        List<int> NeedToLive = new List<int>() { 2, 3 };
        List<int> NeedToBorn = new List<int>() { 3 };
        World world;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            time.Stop();
            NeedToLiveBox.SetItemChecked(2, true);
            NeedToLiveBox.SetItemChecked(3, true);
            NeedToBornBox.SetItemChecked(3, true);

            if (!Directory.Exists("../../data"))
            {
                Directory.CreateDirectory("../../data");
            }
            foreach (string filepath in Directory.GetFiles("../../data"))
            {
                SetByPath(filepath);
                if(HasTable)
                {
                    break;
                }
                
                
            }

            if (!HasTable)
            {
                SetFeild(xdef, ydef, size);
            }

            FormClosing += new FormClosingEventHandler(Form1Closing);


        }
       
        private void Form1Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
             "Сохранить мир?",
             "Завершение программы",
             MessageBoxButtons.YesNoCancel,
             MessageBoxIcon.Warning
            );
            if (dialog == DialogResult.Yes)
            {
                SaveOnClick(sender, e);
                e.Cancel = false;
            }
            else if(dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
           
        }
        String GetFile()
        {
            List<string> lines = new List<string>();
            var filePath = string.Empty;
            string line;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "../../data";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();


                    return filePath;
                }
            }
            return filePath;
        }

        String GetSaveFile()
        {
            List<string> lines = new List<string>();
            var filePath = string.Empty;
            string line;

            using (SaveFileDialog openFileDialog = new SaveFileDialog())
            {
                openFileDialog.InitialDirectory = "../../data";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|Image Files (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = false;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();


                    return filePath;
                }
            }
            return filePath;
        }
        void UpdateCheckListBox()
        {

            for (int i= 0; i < 9; i++)
            {
                NeedToLiveBox.SetItemChecked(i, false);
            }
            foreach (int i in NeedToLive)
            {
                NeedToLiveBox.SetItemChecked(i, true);
            }

            for (int i = 0; i < 9; i++)
            {
                NeedToBornBox.SetItemChecked(i, false);
            }
            foreach (int i in NeedToBorn)
            {
                NeedToBornBox.SetItemChecked(i, true);
            }
            
        }

        public void SetFeild(int x = 10, int y = 10, int size = 40)
        {
            DeleteField();
            CreateField(x, y, size);
            HasTable = true;
        }
        public void DeleteField()
        {
            if (HasTable)
            {
                world.Clear();
            }

        }
        public void CreateField(int cheight, int cwidth, int csize)
        {
            if (cheight * csize * cwidth * csize <= 536870911)
            {
                world = new World(cheight, cwidth, NeedToLive, NeedToBorn, dark);
                size = csize;
                pictureBox.Image = new Bitmap(world.Height * size, world.Width * size);
                graphics = Graphics.FromImage(pictureBox.Image);
                world.UpdateAll(graphics, size);
                pictureBox.Refresh();
            }
            else
            {
                MessageBox.Show("Invalid settings");
            }
        }
        public void Next(object sender, EventArgs e)
        {
            world.LookForward();
            world.GoForward();
            world.UpdateAll(graphics, size);
            pictureBox.Refresh();
        }
        public void Test(object sender, EventArgs e)
        {
            MessageBox.Show("test");
            graphics = Graphics.FromImage(pictureBox.Image);
            graphics.FillRectangle(Brushes.Azure, 0, 0, 100, 100);
            pictureBox.Refresh();
        }
        public void Clear()
        {
            world.Clear();
            world.StrongRepaintAll(graphics, size);
            pictureBox.Refresh();
        }
        public void DeleteOnClick(object sender, EventArgs e)
        {
            DeleteField();
        }
        void SetByList(List<String> lines, int sz)
        {
            size = sz;
            int y = lines.Count;
            int x = lines[0].Length;
            SetFeild(x, y, size);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (lines[j][i] == '0')
                    {
                        world.alive[i, j] = false;
                    }
                    else
                    {
                        world.alive[i, j] = true;
                    }
                }
            }
            world.UpdateAll(graphics, size);

            pictureBox.Refresh();
        }
        public void RandomOnClick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < world.Height; i++)
            {
                for (int j = 0; j < world.Width; j++)
                {
                    world.alive[i, j] = (decimal)rnd.Next(0, 1000000000) / 1000000000 < density;
                }
            }
            world.UpdateAll(graphics, size);
            pictureBox.Refresh();
        }
        public void SetOnClick(object sender, EventArgs e)
        {
            int xc, yc, sc;
            if (HasTable)
            {
                xc = world.Height;
                yc = world.Width;
                sc = size;
            }
            else
            {
                xc = xdef;
                yc = ydef;
                sc = size;
            }
            bool xf = false, yf = false, zf = false;
            xf = Int32.TryParse(heightBox.Text, out xc);
            yf = Int32.TryParse(widthBox.Text, out yc);
            zf = Int32.TryParse(sizeBox3.Text, out sc);
            if ((!xf || xc == world.Height) && (!yf || yc == world.Width))
            {
                if (size != sc)
                {
                    if (world.Height * size * world.Width * size <= 536870911)
                    {
                        size = sc;
                        pictureBox.Image = new Bitmap(world.Height * size, world.Width * size);
                        graphics = Graphics.FromImage(pictureBox.Image);
                        world.StrongRepaintAll(graphics, size);
                        pictureBox.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Invalid settings");
                    }
                }
            }
            else
            {
                SetFeild(xc, yc, sc);
            }
        }

        public void ClearOnClick(object sender, EventArgs e)
        {
            Clear();
        }


        public void PlayOnClick(object sender, EventArgs e)
        {
            playing = !playing;
            if (playing)
            {
                time.Start();
                playBut.Text = "Stop";
            }
            else
            {
                time.Stop();
                playBut.Text = "PLay";
            }
        }

        public void SaveOnClick(object sender, EventArgs e)
        {
            
           
            string path = GetSaveFile();
            if (path == String.Empty) return;
            if (path.EndsWith(".jpg"))
            {
                pictureBox.Image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.WriteLine($"{size}");
                    string sntlr= "";
                    foreach (int k in NeedToLive)
                    {
                        sntlr += $"{k} ";
                    }
                    writer.WriteLine(sntlr);

                    string sntbr = "";
                    foreach (int k in NeedToBorn)
                    {
                        sntbr += $"{k} ";
                    }
                    writer.WriteLine(sntbr);
                    for (int j = 0; j < world.Width; j++)
                    {
                        //string str = "";
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < world.Height; i++)
                        {
                            // str += world.alive[i, j] ? "1" : "0";
                            sb.Append(world.alive[i, j] ? "1" : "0");
                        }
                        writer.WriteLine(sb);
                    }
                }
            }
        }

        public void MouseClick(object sender, MouseEventArgs e)
        {
            if (HasTable)
            {
                world.Change(e.X / size, e.Y / size, graphics, size);
                pictureBox.Refresh();
            }
        }


        public void ChangeTheme(object Sender, EventArgs e)
        {
            dark = !dark;
            if (dark)
            {
                world.SetDark();
                this.BackColor = Color.Black;
                foreach(Control c in splitContainer1.Panel1.Controls)
                {
                        c.ForeColor = Color.White;
                        c.BackColor = Color.Black;
                }
            }
            else
            {
                world.SetBright();
                this.BackColor = Color.White;
                foreach (Control c in splitContainer1.Panel1.Controls)
                {
                    c.ForeColor = Color.Black;
                    c.BackColor = Color.White;
                }
            }
            world.StrongRepaintAll(graphics, size);
            pictureBox.Refresh();

        }
        public List<String> SubList(List<String> orig, int begin)
        {
            List<String> list = new List<String>();
            for(int i = begin; i < orig.Count; i++)
            {
                list.Add(orig[i]);
            }
            return list;
        }
        void SetByPath(string filepath, bool ShowErrors=true)
        {
            List<String> lines = new List<String>();
            String line;
            //MessageBox.Show(filepath);
            if (filepath.EndsWith(".jpg"))
            {
                //MessageBox.Show("JPG");
                Bitmap bm = new Bitmap(filepath);
                //MessageBox.Show($"{bm.Height} {bm.Width}" + Environment.NewLine+  $"{world.Height} {world.Width}");
                if(!HasTable)
                {
                    SetFeild(bm.Width, bm.Height, 1);
                }
                world.SetByImage(bm);
                world.UpdateAll(graphics, size);
                pictureBox.Refresh();
            }
            else
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        lines.Add(line);
                        line = reader.ReadLine();
                    }
                }

                string strsz, ntlr, ntbr;
                int rub;
                //size ntlr ntbr 
                if (lines.Count < 4)
                {
                    if (ShowErrors) MessageBox.Show("File Invalid 001");
                    return;
                }
                
                strsz = lines[0];
                ntlr = lines[1];
                ntbr = lines[2];

                if (!ntlr.Split(' ').Where(s => s != "").All(s => Int32.TryParse(s, out rub)))
                {
                    if (ShowErrors) MessageBox.Show("File Invalid 003");
                    return;
                }
                NeedToLive = ntlr.Split(' ').Where(s => s != "").Select(s => Int32.Parse(s)).ToList();
                
                
                if (!ntbr.Split(' ').Where(s => s != "").All(s => Int32.TryParse(s, out rub)))
                {
                    if (ShowErrors)
                        MessageBox.Show("File Invalid 005");
                    return;
                }
                NeedToBorn = ntbr.Split(' ').Where(s => s != "").Select(s => Int32.Parse(s)).ToList();

                lines = SubList(lines, 4);
                if (lines.All(l => l.Length == lines[0].Length) && lines.SelectMany(l => l.ToList()).All(c => c == '1' || c == '0') && lines.Count > 0)
                {
                    if (Int32.TryParse(strsz, out size))
                    {
                        SetByList(lines, size);
                        UpdateCheckListBox();
                    }
                }
                else
                {
                    if (ShowErrors)
                        MessageBox.Show("File Invalid 006");
                }
            }
        }

        public void OpenOnClick(object sender, EventArgs e)
        {
            String filepath = GetFile();
            if (filepath == String.Empty) return;
            SetByPath(filepath, true);
           
        }

        public void ShowInformation(object sender, MouseEventArgs e)
        {
            int x = e.X / size;
            int y = e.Y / size;
            xLabel.Text = x.ToString();
            yLabel.Text = y.ToString();
            if (HasTable)
            {
                if (x < world.Height && y < world.Width) ageLabel.Text = world.age[x, y].ToString();
            }
        }
        public void ChangeRules(object sender, EventArgs e)
        {
            NeedToLive.Clear();
            for (int i = 0; i < NeedToLiveBox.CheckedItems.Count; i++)
            {
                NeedToLive.Add(Int32.Parse(NeedToLiveBox.CheckedItems[i].ToString()));
            }
            NeedToBorn.Clear();
            for (int i = 0; i < NeedToBornBox.CheckedItems.Count; i++)
            {
                NeedToBorn.Add(Int32.Parse(NeedToBornBox.CheckedItems[i].ToString()));
            }
        }

        public void GoKMove(object sender, EventArgs e)
        {
            int k = 1;
            Int32.TryParse(KMoveTextBox.Text, out k);
            for(int i=0; i<k; i++)
            {
                world.LookForward();
                world.GoForward();
            }
            world.UpdateAll(graphics, size);
            pictureBox.Refresh();
        }
        public void SetDensity(object sender, EventArgs e)
        {
            Decimal.TryParse(densityBox.Text, out density);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down) splitContainer1.Panel2.. = new Point(splitContainer1.Panel2.AutoScrollPosition.X, splitContainer1.Panel2.AutoScrollPosition.Y+3);
        }
    }
}
