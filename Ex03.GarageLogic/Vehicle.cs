using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    
    public abstract class Vehicle
    {
        protected String m_ModelName;
        protected String m_LicenseNumber;
        protected EnergyType m_EnergyType;
        protected List<Wheel> m_Wheels;
        private GarageTicket m_OwnerTicket;
        private String m_TypeOfVehicle;

        public Vehicle(String i_ModelName, String i_LicenseNumber, EnergyType i_EnergyType, List<Wheel> i_Wheels)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyType = i_EnergyType;
            m_Wheels = i_Wheels;
        }

        public GarageTicket OwnerTicket
        {
            get { return m_OwnerTicket; }
            set { m_OwnerTicket = value; }
        }

        public string TypeOfVehicle
        {
            get { return m_TypeOfVehicle; }
            set { m_TypeOfVehicle = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public EnergyType EnergyType
        {
            get { return m_EnergyType; }
            set { m_EnergyType = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }
        
        public List<String> GetInfo()
        {
            List<String> info = new List<string>();
            info.Add("The license number is " + LicenseNumber);
            info.Add("The ModelName number is " + ModelName);
            m_OwnerTicket.GetInfo(info);
            foreach (Wheel wheel in m_Wheels)
            {
                int i = 1;
                info.Add(string.Format("Wheel number {0} Manafacture is {1} and it's air pressure is {2}", i, wheel.Manufacturer, wheel.CurrentAirPressure));
                i++;
            }

            info.Add(" energy precentage is " + this.m_EnergyType.EnergyPercentage.ToString() + "%");
            info.Add(" This car uses a " + this.m_EnergyType.GetTypeOfEnergy());
            if(this.EnergyType.GetTypeOfEnergy().Equals("Battery"))
            {
                Battery ourBattery = (Battery)this.EnergyType;
                info.Add("the battery max operating time is " + ourBattery.MaxOperatingTime.ToString());
                info.Add("the battery remaining operating time is " + ourBattery.RemainingOperatingTime.ToString());
            }
            else
            {
                FuelTank ourTank = (FuelTank)this.EnergyType;
                info.Add("the battery remaining operating time is " + ourTank.CurrentFuelCapacity.ToString());
                info.Add("the tank max operating time is " + ourTank.MaxTankCapacity.ToString());
            }

            return info;
        }
    }
}