using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    public class ZeroException : Exception
    {
        public ZeroException(string m) : base(m) { }
    }

    public class NegativeRootException : Exception
    {
        public NegativeRootException(string m) : base(m) { }
    }

    public class InvalidOperation : Exception
    {
        public InvalidOperation(string m) : base(m) { }
    }
}
