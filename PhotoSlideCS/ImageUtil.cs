using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PhotoSlideCS
{
    public static class ImageUtil
    {
        public static Image[] GetFrames(Image originalImg)
        {
        
            int numberOfFrames = originalImg.GetFrameCount(FrameDimension.Time);

            Image[] frames = new Image[numberOfFrames];
 
            for (int i = 0; i < numberOfFrames; i++)
            {

                originalImg.SelectActiveFrame(FrameDimension.Time, i);

                frames[i] = ((Image)originalImg.Clone());

            } 
            return frames;
        }

        public static int GetDuration(Image img) {
            int c = img.GetFrameCount(FrameDimension.Time);
            img.Dispose();
            return c;
        }
        public static double GetFrameSpeed(Image img) {
             
           // int frames = img.GetFrameCount(FrameDimension.Time);
            PropertyItem item = img.GetPropertyItem(0x5100); // FrameDelay in libgdiplus
            
            // Time is in 1/100th of a second
            double dur = (double)((double)(item.Value[0] + item.Value[1] * 256) * 10);
           // System.Diagnostics.Debug.WriteLine("FrameDelay: "+ dur);

            return dur;
        }
    }
}
