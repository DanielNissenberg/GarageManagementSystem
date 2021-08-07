using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eEnergySource
    {
        Battery,
        FuelTank
    }

    public class EnergyType
    {
        protected float m_EnergyPercentage;
        protected eEnergySource m_typeOfEnergy;

        public EnergyType(float i_EnergyPercentage, eEnergySource i_TypeOfEnergy)
        {
            this.m_EnergyPercentage = i_EnergyPercentage;
            this.m_typeOfEnergy = i_TypeOfEnergy;
        }

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { m_EnergyPercentage = value; }
        }

        public String GetTypeOfEnergy()
        {
            if(m_typeOfEnergy.Equals(eEnergySource.FuelTank))
            {
                return "Fueltank";
            }
            else
            {
                return "Battery";
            }
        }

        public void Refuel(eFuelType i_FuelType, float i_RefuelVolume) { }
        public void Recharge(float i_HoursToAdd) { }
    }
}