using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PhotoSlideCS
{
    public static class PS8Reader
    {
        private static string PS8String(string file) {
            using (StreamReader reader = new StreamReader(file)) {
                return reader.ReadToEnd();
            }
        }
        public static PS8 Read(string ps8file){
            string ps8strnig = PS8String(ps8file);
            using (StringReader reader = new StringReader(ps8strnig)) {
                try{
                    PS8 ps8 = new PS8();
                    string[] header = reader.ReadLine().Split('|');

                    if (header[0] != "PS8"){
                        throw new PS8Exception("Invalid Photo Slide playlist format."); 
                    }
                    else{
                        if (header[1] == string.Empty){
                            throw new PS8Exception("Invalid Photo Slide playlist format. Interval not defined"); 
                        }
                        else{
                            if (Convert.ToInt32(header[1]) <= 100)
                                ps8.Speed = 1000;
                            else
                                ps8.Speed = Convert.ToInt32(header[1]);
                        }
                        while (reader.Peek() != -1){
                            string[] d = reader.ReadLine().Split('|');
                            ps8.AddPhoto(d[0], d[1], d[2]);
                        }  
                        return ps8;
                       
                    }
                }
                catch (Exception ex){
                    throw new PS8Exception("Invalid Photo Slide playlist format\n" + ex.Message); 
                }
            }
        }
    }
}
