using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class BlednyNumerTelefonuException : Exception
    {
        public BlednyNumerTelefonuException() { }
        public BlednyNumerTelefonuException(string message) : 
            base(message)
        {
        }
    }
    public class BlednyZapisException : Exception
    {
        public BlednyZapisException() { }
        public BlednyZapisException(string message) :
            base(message)
        {
        }
    }
    public class WSaliTrwaAktulanieInnySeansException : Exception
    { 
        public WSaliTrwaAktulanieInnySeansException() { }
        public WSaliTrwaAktulanieInnySeansException(string message) :
            base(message)
        {
        }
    }
    class BlednyPeselException : Exception
    {
        public BlednyPeselException() { }
        public BlednyPeselException(string message) :
            base(message)
        {
        }

    }
}
