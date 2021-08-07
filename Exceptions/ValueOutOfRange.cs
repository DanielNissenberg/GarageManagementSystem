using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {

        private readonly float m_MaxValue;
        private readonly float m_MinValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }
        public float MuunValue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(Exception i_Exception, float i_MinValue, float i_MaxValue)
                                        : base(String.Format("Invalid value input." +
                                                             " Please enter a value within {0} and {1}", i_MinValue, i_MaxValue), i_Exception)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}

