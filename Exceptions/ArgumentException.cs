using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.Exceptions
{
    public class ArgumentException : Exception
    {
        private string m_WrongFuelType;
        private string m_RightFuelType;
        public ArgumentException(Exception i_Exception,
                                 string i_WrongFuelType,
                                 string i_RightFuelType)
                                 : base(string.Format("This vehicle uses {0}, it should not be refueled with {1}." +
                                                      " Please reconsider the fuel type.", i_RightFuelType, i_WrongFuelType), i_Exception)
        {
            m_WrongFuelType = i_WrongFuelType;
            m_RightFuelType = i_RightFuelType;
        }

        public string WrongFuel
        {
            get { return m_WrongFuelType; }
        }

        public string Fuel
        {
            get { return m_RightFuelType; }
        }
    }
}
