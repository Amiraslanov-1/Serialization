using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    internal class BookIsNotFound:Exception
    {
        public BookIsNotFound(string msg):base(msg)
        {

        }
    }
}
