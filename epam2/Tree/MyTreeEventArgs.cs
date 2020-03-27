using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class MyTreeEventArgs<T> : EventArgs
    {
        public T Element { get; }

        public MyTreeEventArgs() { }

        public MyTreeEventArgs(T Element)
        {
            this.Element = Element;
        }
    }
}
