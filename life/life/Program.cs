using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace life
{
    
    public class World
    {
        int h;
        int w;
        
        public bool[,] alive;
        public bool[,] alive_next;
        public bool[,] painted_alive;
        public int[,] age;

        public List<int> NeedToLive;
        public List<int> NeedToBorn;

        Brush AliveColor = Brushes.Black;
        Brush DeadColor = Brushes.White;
        int board = 3;
        public World(int ch, int cw,  List<int> cNeedToLive, List<int> cNeedToBorn, bool cdark = false)
        {
            h = ch;
            w = cw;

            alive = new bool[h,w];
            alive_next = new bool[h , w];
            painted_alive = new bool[h , w];
            age = new int[h, w];
            if(cdark)
            {
                this.SetDark();
            }
            else
            {
                this.SetBright();
            }
            /*
            NeedToLive = new List<int>();
            foreach (int n in cNeedToLive) NeedToLive.Add(n);
            NeedToBorn = new List<int>();
            foreach (int n in cNeedToBorn) NeedToBorn.Add(n);
            */
            NeedToLive = cNeedToLive;
            NeedToBorn = cNeedToBorn;
         
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    alive[i, j] = false;
                    alive_next[i, j] = false;
                    painted_alive[i, j] = true;
                    age[i, j] = 0;
                }
            }
            

        }
        public int Height
        {
            get { return h; }
           
        }
        public int Width
        {
            get { return w; }
            
        }
        Size sz
        {
            get { return new Size(h, w); }
           
        }

        public void LookForward()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    int num = 0;
                    for (int s1 = -1; s1 <= 1; s1++)
                    {
                        for (int s2 = -1; s2 <= 1; s2++)
                        {
                            if (s1 != 0 || s2 != 0)
                            {
                                if (alive[(h + i + s1) % h, (w + j + s2) % w]) num++;
                            }
                        }
                    }
                    
                    LookForward(i, j, num);
                }
            }
        }
        public void LookForward(int i, int j,int num)
        {
            if (alive[i, j])
            {
                alive_next[i, j] = NeedToLive.Contains(num);
            }
            else
            {
                alive_next[i, j] = NeedToBorn.Contains(num);
            }
        }
        public void SetBright()
        {
            AliveColor = Brushes.Black;
            DeadColor = Brushes.White;
        }
        public void SetDark()
        {
            AliveColor = Brushes.White;
            DeadColor = Brushes.Black;
        }
        public void GoForward()
        {
            for(int i=0; i<h; i++)
            {
                for(int j=0; j<w; j++)
                {
                    GoForward(i, j);
                }
            }
        }
        public void GoForward(int i, int j)
        {
            alive[i, j] = alive_next[i, j];
            if(alive[i, j])
            {
                age[i, j]++;
            }
            else
            {
                age[i, j] = 0;
            }

        }
        public void Next()
        {
            LookForward();
            GoForward();
        }
        
        public void Change(int i, int j, Graphics g, int size)
        {
            if (i <= h && j <= w)
            {
                alive[i, j] = !alive[i, j];
                if (!alive[i, j]) age[i, j] = 0;
                update(i, j, g, size);
            }
        }
        public void Clear()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (alive[i, j])
                    {
                        alive[i, j] = false;
                        age[i, j] = 0;
                    }
                }
            }
        }
        public void update(int i, int j, Graphics g, int size)
        {
                if (alive[i, j] && !painted_alive[i, j])
                {
                    paintAlive(i, j, size, g);
                }
                else if (!alive[i, j] && painted_alive[i ,j])
                {
                    paintDead(i, j, size, g);
                }
        }

        public void UpdateAll(Graphics g, int size)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (alive[i, j] && !painted_alive[i, j])
                    {
                        paintAlive(i, j, size, g);
                    }
                    else if (!alive[i, j] && painted_alive[i, j])
                    {
                        paintDead(i, j, size, g);
                    }

                }
            }
        } 
        public void StrongRepaintAll(Graphics g, int size)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    StrongRepaint(i, j, size, g);
                }
            }
        }
        void StrongRepaint(int i, int j, int size, Graphics g)
        {
            if (!alive[i, j])
            {
                g.FillRectangle(DeadColor, (i) * size, (j) * size, size, size);
                painted_alive[i, j] = false;
            }
            else
            {
                g.FillRectangle(AliveColor, (i) * size, (j) * size, size, size);
                painted_alive[i, j] = true;
            }
        }
        
        void paintDead(int i, int j, int size, Graphics g)
        {
            //if (painted_alive[i, j])
            //{
                g.FillRectangle(DeadColor, (i) * size, (j) * size, size, size);
                painted_alive[i, j] = false;
            //}
              
        }
           

        
        void paintAlive(int i, int j, int size, Graphics g)
        {
            //if (!painted_alive[i, j])
            //{
                g.FillRectangle(AliveColor, (i) * size, (j) * size, size, size);
                painted_alive[i, j] = true;
            //}
              
        }
        public void SetByImage(Bitmap orig)
        {
            int H = orig.Width;
            int W = orig.Height;
            for (int i = 0; i < Math.Min(h, H); i++)
            {
                for (int j = 0; j < Math.Min(w, W); j++)
                {
                    int ch = (H) / Height;
                    int cw = (W) / Width;
                    ch = ch == 0 ? 1 : ch;
                    cw = cw == 0 ? 1 : cw;

                    float ans = 0;
                    for (int x = 0; x < ch; x++)
                    {
                        for (int y = 0; y < cw; y++)
                        {
                            ans += orig.GetPixel(i * ch + x, j * cw + y).GetBrightness();
                        }
                    }
                    ans = ans / (ch * cw);
                    bool col = ans <= 0.5;
                    ch = (Height) / H;
                    cw = (Width) / W;
                    ch = ch == 0 ? 1 : ch;
                    cw = cw == 0 ? 1 : cw;
                    for (int x = 0; x < ch; x++)
                    {
                        for (int y = 0; y < cw; y++)
                        {
                            if (i * (ch) + x < h && j * (cw) + y < w) alive[i * (ch) + x, j * (cw) + y] = col;
                        }
                    }

                }
            }
        }
       

        
       
    }
       
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
           
            
        }
    }
}
