using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Battery : EnergyType
    {
        private float m_RemainingOperatingTime;
        private float m_MaxOperatingTime;
        public Battery(float i_RemainingOperatingTime, float i_MaxOperatingTime, eEnergySource i_EnergySource, float i_EnergyPercentage = 0) 
                       : base(i_EnergyPercentage, i_EnergySource)
        {
            m_RemainingOperatingTime = i_RemainingOperatingTime;
            m_MaxOperatingTime = i_MaxOperatingTime;
            UpdateEnergyPrecentage();
        }

        public void Recharge(float i_HoursToAdd)
        {
            if(m_RemainingOperatingTime + i_HoursToAdd <= m_MaxOperatingTime)
            {
                m_RemainingOperatingTime = m_RemainingOperatingTime + i_HoursToAdd;
                UpdateEnergyPrecentage();
            }
        }

        public void UpdateEnergyPrecentage()
        {
            m_EnergyPercentage = (float)Math.Round((m_RemainingOperatingTime / m_MaxOperatingTime) * 100.0f, 2);
        }

        public float RemainingOperatingTime
        {
            get { return m_RemainingOperatingTime; }
            set { m_RemainingOperatingTime = value; }
        }

        public float MaxOperatingTime
        {
            get { return m_MaxOperatingTime; }
            set { m_MaxOperatingTime = value; }
        }
    }
}