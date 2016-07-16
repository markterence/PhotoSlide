/*
 * Not Used
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PhotoSlideCS
{
    public class GifPlayer
    {
        private Image gifImage;
        private FrameDimension dimension;
        private int frameCount;
        private int currentFrame = -1;
        private bool reverse;
        private int step = 1;

        private bool _isPlaying = false;

        public GifPlayer(string path)
        {
            gifImage = Image.FromFile(path);
            //initialize
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            //gets the GUID
            //total frames in the animation
            frameCount = gifImage.GetFrameCount(dimension);
            System.Diagnostics.Debug.WriteLine("GifPlayer.FrameCount: " + frameCount);
        }

        public bool ReverseAtEnd {
            //whether the gif should play backwards when it reaches the end
            get { return reverse; }
            set { reverse = value; }
        }

        public bool isPlaying {
            get { return _isPlaying; }
            set { _isPlaying = value; }
        }

        public Image GetNextFrame()
        { 
            currentFrame += step;
            //_isPlaying = true;
            //if the animation reaches a boundary...
            if (currentFrame >= frameCount || currentFrame < 1) {
                
                if (reverse) {
                    step *= -1;
                    //...reverse the count
                    //apply it
                    currentFrame += step;
                }
                else {
                    currentFrame = 0;
                     
                    //...or start over
                }
            }
           
            return GetFrame(currentFrame);
        }

        public Image PlayOneShot() {
            
            //_isPlaying = true;
            //if the animation reaches a boundary...
            System.Diagnostics.Debug.WriteLine("Frame Count" + frameCount);
            if (currentFrame <= frameCount)
            {
                currentFrame += step;
                _isPlaying = true;
            }
            else {
                _isPlaying = false;
                System.Diagnostics.Debug.WriteLine("Reached end frame: " + currentFrame);
             
            }
            return GetFrame(currentFrame);
        }

        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index);
            //find the frame
            return (Image)gifImage.Clone();
            //return a copy of it
        }
    }
}
