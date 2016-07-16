using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoSlideCS
{
    [Serializable]
    public class PS8
    {
 
        public struct PS8Format {
            
            public String filename;
            public String path;
            public String extension;

            public PS8Format(string filename, string filepath, string ext) {
                this.filename = filename;
                this.path = filepath;
                this.extension = ext;
            }
        }

        private List<PS8Format> files = new List<PS8Format>();
        private int _speed = 1200;

        #region "Serialize this Properties"
        public int Speed {
            get { return _speed; }
            set { _speed = value; }
        }

        public List<PS8Format> Files {
            get { return files; }
        }
        #endregion
        public void AddPhoto(string filename) {
            files.Add(new PS8Format(filename, string.Empty, string.Empty));
        }
        public void AddPhoto(string filename, string path) {
            files.Add(new PS8Format(filename, path, string.Empty));
        }

        public void AddPhoto(string filename, string path, string ext)
        {
            files.Add(new PS8Format(filename, path, ext));
        }

        public void RemovePhoto() { 
        
        }
    }
}
