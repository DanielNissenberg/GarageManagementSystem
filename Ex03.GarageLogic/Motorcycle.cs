using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A,      // 1
        A1,     // 2
        A2,     // 3
        B       // 4
    }

    public class Motorcycle : Vehicle 
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(String i_ModelName, String i_LicenseNumber, EnergyType i_EnergyType, List<Wheel> i_Wheels, eLicenseType i_LicenseType, int i_EngineVolume)
                          : base(i_ModelName, i_LicenseNumber, i_EnergyType, i_Wheels)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineCapacity
        {
            get { return m_EngineVolume; }
        }

        public string GetTheType()
        {
            if((m_EnergyType.GetType().ToString()).Equals("FuelTank"))
            {
                return eVehicleType.Motorcycle.ToString();
            }
            else
            {
                return eVehicleType.EMotorcycle.ToString();
            }
        }

        public List<string> GetSpecificInfo()
        {
            List<string> info = new List<string>();
            info.Add(" The motorcycle license type is " + m_LicenseType.ToString());
            info.Add(" The motorcycle license type is " + m_EngineVolume.ToString());
            if(m_EnergyType.GetTypeOfEnergy().Equals("Fueltank"))
            {
                info.Add("The fuel type is octan98");
            }

            return info;
        }
    }
}