using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octan95,        // 1
        Octan96,        // 2
        Octan98,        // 3
        Soler           // 4
    }

    public class FuelTank : EnergyType
    {

        private readonly eFuelType m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxTankCapacity; 

        public FuelTank(eFuelType i_FuelType, float i_CurrentAmountOfFuel, eEnergySource i_EnergySource, float i_MaxTankCapacity, float i_EnergyPrecentage = 0) 
                        : base(i_EnergyPrecentage, i_EnergySource)
        {
            m_FuelType = i_FuelType;
            m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            m_MaxTankCapacity = i_MaxTankCapacity;
            UpdateEnergyPrecentage();
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }

        public float CurrentFuelCapacity
        {
            get { return m_CurrentAmountOfFuel; }
            set { m_CurrentAmountOfFuel = value; }
        }

        public float MaxTankCapacity
        {
            get { return m_MaxTankCapacity; }
            set { m_MaxTankCapacity = value; }
        }

        public void Refuel(eFuelType i_FuelType, float i_RefuelVolume)
        {
            if(i_FuelType.Equals(m_FuelType))
            {
                if(m_CurrentAmountOfFuel + i_RefuelVolume <= m_MaxTankCapacity)
                {
                    m_CurrentAmountOfFuel = m_CurrentAmountOfFuel + i_RefuelVolume;
                    UpdateEnergyPrecentage();
                }
                else
                {
                }
            }
            else
            {
            }
        }

        public void UpdateEnergyPrecentage()
        {
            m_EnergyPercentage = (float)Math.Round((m_CurrentAmountOfFuel / m_MaxTankCapacity) * 100.0f, 2);
        }
    }
}