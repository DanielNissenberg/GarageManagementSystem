using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_ContainsDangerousMaterials;
        private float m_MaxCargoWeight;

        public Truck(String i_ModelName, String i_LicenseNumber, EnergyType i_EnergyType, List<Wheel> i_Wheels, bool i_ContainsDangerousMaterials, float i_MaxCargoWeight)
                     : base(i_ModelName, i_LicenseNumber, i_EnergyType, i_Wheels)
        {
            m_ContainsDangerousMaterials = i_ContainsDangerousMaterials;
            m_MaxCargoWeight = i_MaxCargoWeight;
        }

        public bool ContainsDangerousMaterials
        {
            get { return m_ContainsDangerousMaterials; }
            set { m_ContainsDangerousMaterials = value; }
        }

        public float MaxCargoWeight
        {
            get { return m_MaxCargoWeight; }
            set { m_MaxCargoWeight = value; }
        }

        public string GetTheType()
        {
            return eVehicleType.Truck.ToString();
        }

        public List<string> GetSpecificInfo()
        {
            List<string> info = new List<string>();
            if(m_ContainsDangerousMaterials)
            {
                info.Add(" The truck contains dangerous materials");
            }
            else
            {
                info.Add(" The truck does not contain dangerous materials");
            }
           
            info.Add(" The maximum cargo weight of the truck is " +  m_MaxCargoWeight.ToString());
            info.Add("The fuel type is soler");
            
            return info;
        }
    }
}