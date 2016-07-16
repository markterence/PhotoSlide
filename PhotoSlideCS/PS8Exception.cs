using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoSlideCS
{
    public class PS8Exception : Exception
    {
        public PS8Exception() : base() { }

        public PS8Exception(string message) : base(message) { }
    }
}
