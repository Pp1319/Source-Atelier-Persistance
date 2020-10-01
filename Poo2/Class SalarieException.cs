using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Poo3
{
    [Serializable]
    public class SalarieException : ApplicationException
    {
        private string _idMessage = string.Empty;
        public string IdMessage { get => _idMessage; set => _idMessage = value; }
        public SalarieException()
            : base()
        { }

        public SalarieException(string idMessage, string message)
        :base(message)
        { _idMessage = IdMessage; }
        public SalarieException(string idMessage, string message, Exception inner)
       : base(message, inner)
        { _idMessage = IdMessage; }

        protected SalarieException (SerializationInfo info, StreamingContext context)
        : base(info, context)
        { }
    }
}
