using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eCarColor
    {
        Red,        // 1
        Silver,     // 2
        White,      // 3
        Black       // 4
    }

    public enum eNumOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        public Car(String i_ModelName, String i_LicenseNumber, EnergyType i_EnergyType,
                   List<Wheel> i_Wheels, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
                   : base(i_ModelName, i_LicenseNumber, i_EnergyType, i_Wheels)
        {
            Color = i_CarColor;
            Doors = i_NumOfDoors;
        }

        public eCarColor Color
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumOfDoors Doors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public new String LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public String GetTheType()
        {
            if((m_EnergyType.GetType().ToString()).Equals("FuelTank"))
            {
                return eVehicleType.Car.ToString();
            }
            else
            {
                return eVehicleType.ECar.ToString();
            }
        }

        public List<string> GetSpecificInfo()
        {
            List<string> info = new List<string>();
            info.Add(" The car color is " + m_CarColor.ToString());
            info.Add(" The car has " + m_NumOfDoors.ToString() + " doors.");
            if(m_EnergyType.GetTypeOfEnergy().Equals("Fueltank"))
            {
                info.Add("The fuel type is octan95");
            }

        return info;
        }
    }
}
