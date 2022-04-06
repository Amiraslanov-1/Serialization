using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    internal class ResultIsNullException:Exception
    {
        public ResultIsNullException(string msg):base(msg)
        {

        }
    }
}
