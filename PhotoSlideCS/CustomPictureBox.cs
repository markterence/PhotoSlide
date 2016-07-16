using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
 
namespace PhotoSlideCS
{
    public class CustomPictureBox : PictureBox
    {
        
        public struct ColorAlpha {
            public int Min;
            public int Max;
            public int Current;

            public ColorAlpha(int min, int max, int cur) {
                this.Min = min;
                this.Max = max;
                this.Current = cur;
            }
        }
        
        public struct PhotoInfo {
            public string Filename;
            public string Path;
            public float FileSize;
        }
        System.Timers.Timer timer; 
        public ColorAlpha rectAlpha;
        public ColorAlpha textAlpha;
        string t;
        bool ok, show;
        int nextOut;
        DateTime dt;

        public PhotoInfo pinfo;
        public Control control;
        public CustomPictureBox() {
            rectAlpha = new ColorAlpha(0, 120, 0);
            textAlpha = new ColorAlpha(0, 255, 0);
            timer = new System.Timers.Timer(100.0);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            Console.WriteLine(timer.Interval);

            DoubleBuffered = true;
            ResizeRedraw = true;
            this.CreateControl();
        }

        //void FixedUpdate(double dt)
        //{

        //   System.Threading.Thread.Sleep(60);
        //   if (timer.Enabled) {
        //       DrawInfoRect(dt); 
        //   }
        //}

        double time;
        void DrawInfoRect(double delta)
        {
            t = DateTime.Now.Second.ToString() + ":" + dt.Second.ToString() + "";

            t = rectAlpha.Current.ToString();
            if (show)
            {
                //if (!ok) {
                if (textAlpha.Current < textAlpha.Max && !ok)
                {
                    textAlpha.Current += 10;
                    if (textAlpha.Current >= textAlpha.Max)
                    {
                        textAlpha.Current = textAlpha.Max;
                    }
                    dt = DateTime.Now.AddSeconds(5);
                }

                if (rectAlpha.Current < rectAlpha.Max && !ok)
                {
                    rectAlpha.Current += Convert.ToInt32(60 * delta); ;//18;
                    if (rectAlpha.Current >= rectAlpha.Max)
                    {
                        rectAlpha.Current = rectAlpha.Max;
                    }
                    dt = DateTime.Now.AddSeconds(5);
                }

                //}

                if (DateTime.Now >= dt)
                {
                    ok = true;
                    if (rectAlpha.Current > rectAlpha.Min)
                    {
                        rectAlpha.Current -= 18;
                        if (rectAlpha.Current <= rectAlpha.Min)
                            rectAlpha.Current = rectAlpha.Min;
                    }
                    else if (textAlpha.Current > textAlpha.Min)
                    {
                        textAlpha.Current -= 10;
                        if (textAlpha.Current <= textAlpha.Min)
                            textAlpha.Current = textAlpha.Min;
                    }
                    else
                    {

                        show = false;
                        timer.Enabled = false;

                    }

                }
                GC.Collect();
                Invalidate();
            }
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Timer(e);
            System.Threading.Thread.Sleep(16);
        }

 
        public void ShowImageInfo(string filename, string path, float size) {
            timer.Enabled = true;
            if (timer.Enabled) {
                this.pinfo.Filename = filename;
                this.pinfo.FileSize = size;
                this.pinfo.Path = path;

                rectAlpha.Current = 0;
                textAlpha.Current = 0;
                ok = false;
                show = true;
            }
        }

        public void StartTimer() {
            timer.Enabled = !timer.Enabled;
            Console.WriteLine("Timer" + timer.Enabled);
        }
  
        protected override void OnPaint(PaintEventArgs pe)
        {
           
            base.OnPaint(pe);
            if (!DesignMode) {
                if (timer.Enabled)
                {
                    GC.Collect();
                    using (Brush br = new SolidBrush(Color.FromArgb(rectAlpha.Current, 50, 50, 50)))
                    {
                        float x, y, w, h;
                        x = 10;
                        h = 100f;
                        y = this.Height - h - 10f;
                        w = this.Width - 10f - 10f;
                        RectangleF rect = new RectangleF(x, y, w, h);

                        pe.Graphics.FillRectangle(br, x, y, w, h);

                        using (Brush br2 = new SolidBrush(Color.FromArgb(textAlpha.Current, 255, 255, 255)))
                        {
                            pe.Graphics.DrawString(t + this.pinfo.Filename, this.Parent.Font, br2, rect);
                            pe.Graphics.DrawString(this.pinfo.Path, this.Parent.Font, br2, rect.X, rect.Y + 15);

                        }
                    }
                    GC.Collect();
                }
            }

        }

        #region "M"
        void Timer(System.Timers.ElapsedEventArgs e) {
            t = e.SignalTime.Second.ToString() + ":" + dt.Second.ToString() + "";
            if (show)
            {
                //if (!ok) {
                if (textAlpha.Current < textAlpha.Max && !ok)
                {
                    textAlpha.Current += 10;
                    if (textAlpha.Current >= textAlpha.Max)
                    {
                        textAlpha.Current = textAlpha.Max;
                    }
                    dt = e.SignalTime.AddSeconds(5);
                }

                else if (rectAlpha.Current < rectAlpha.Max && !ok)
                {
                    rectAlpha.Current += 18;
                    if (rectAlpha.Current >= rectAlpha.Max)
                    {
                        rectAlpha.Current = rectAlpha.Max;
                    }
                    dt = e.SignalTime.AddSeconds(5);
                }

                //}

                if (e.SignalTime >= dt)
                {
                    ok = true;
                    if (rectAlpha.Current > rectAlpha.Min)
                    {
                        rectAlpha.Current -= 18;
                        if (rectAlpha.Current <= rectAlpha.Min)
                            rectAlpha.Current = rectAlpha.Min;
                    }
                    else if (textAlpha.Current > textAlpha.Min)
                    {
                        textAlpha.Current -= 10;
                        if (textAlpha.Current <= textAlpha.Min)
                            textAlpha.Current = textAlpha.Min;
                    }
                    else
                    {

                        show = false;
                        timer.Enabled = false;

                    }

                }
                //if (rectAlpha.Current < rectAlpha.Max && !ok){
                //    rectAlpha.Current += 8;
                //    dt = e.SignalTime.AddSeconds(5);
                //    nextOut = e.SignalTime.Second + 5;
                //}

                // if (e.SignalTime.Second >= nextOut)
                //if (e.SignalTime >= dt){
                //    ok = true;
                //    if (rectAlpha.Current > rectAlpha.Min) {
                //        rectAlpha.Current -= 8;
                //    }
                //    else { 
                //        show = false;
                //        timer.Enabled = false;
                //    } 
                //}
            }
            GC.Collect();
            Invalidate();
        }
        #endregion



 
    }
}
