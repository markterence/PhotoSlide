using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PhotoSlideCS
{
    public static class PS8Writer
    {
        public static bool Save(PS8 content, string filename){
            string str = string.Empty;
            foreach (var item in content.Files){
                str += item.filename + "|" + item.path + "|" + item.extension +Environment.NewLine;
            }
            using (StreamWriter writer = new StreamWriter(filename)) {
                try{
                    /*
                     * Format
                     * PS8|<speed>
                     * <file_name 1>|<path 1>|<exention 1>
                     * <file_name 2>|<path 2>|<exention 2>
                     * ...
                     * ...
                     * <file_name 99>|<path 99>|<exention 99>
                    */
                    writer.Write("PS8|" + content.Speed + Environment.NewLine + str);
                }
                catch (Exception){
                    return false;
                }
            }
            return true;
        }
    }
}
