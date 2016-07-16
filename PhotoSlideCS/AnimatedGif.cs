using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;

public class AnimatedGif
{
    private List<AnimatedGifFrame> mImages = new List<AnimatedGifFrame>();
 
    public AnimatedGif(string path)
    {
        Image img = Image.FromFile(path);
        int frames = img.GetFrameCount(FrameDimension.Time);
        if (frames <= 1) throw new ArgumentException("Image not animated");
        byte[] times = img.GetPropertyItem(0x5100).Value;
        int frame = 0;
        for (; ; )
        {
            int dur = BitConverter.ToInt32(times, 4 * frame);
            //mImages.Add(new AnimatedGifFrame(new Bitmap(img), dur));
            mImages.Add(new AnimatedGifFrame(dur));
            if (++frame >= frames) break;
            img.SelectActiveFrame(FrameDimension.Time, frame);
        }
        img.Dispose();
    }
    public List<AnimatedGifFrame> Images { get { return mImages; } }
}


public class AnimatedGifFrame
{
    private int mDuration;
    //private Image mImage;
 
    //internal AnimatedGifFrame(Image img, int duration)
    //{
    //    mImage = img; mDuration = duration;
    //}
    internal AnimatedGifFrame(int duration)
    {
        mDuration = duration;
    }
    //public Image Image { get { return mImage; } }
    public int Duration { get { return mDuration; } }
}