using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<String, Vehicle> m_InShop;
        private Dictionary<String, GarageTicket> m_Costumers;
        private string m_Name;

        public Garage(string name)
        {
            this.m_Name = name;
            this.m_InShop = new Dictionary<String, Vehicle>();
            this.m_Costumers = new Dictionary<String, GarageTicket>();
        }

        public Dictionary<String, Vehicle> InShop
        {
            get { return m_InShop; }
            set { m_InShop = value; }
        }

        public Dictionary<String, GarageTicket> Costumers
        {
            get { return m_Costumers; }
            set { m_Costumers = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string CreateVehicle(Dictionary<String, String> i_UserInfo)
        {
            i_UserInfo.TryGetValue("LicenseNumber", out String theLicenseNumber);
            i_UserInfo.TryGetValue("ModelName", out String ModelName);
            i_UserInfo.TryGetValue("EnergyType", out String EnergyType);
            i_UserInfo.TryGetValue("EnergyPrecentage", out String EnergyPrecentage);
            eEnergySource energyType = (eEnergySource)Enum.Parse(typeof(eEnergySource), EnergyType);
            i_UserInfo.TryGetValue("WheelsAirPressure", out String WheelsAirPressure);
            i_UserInfo.TryGetValue("WheelsManufacturers", out String WheelsManufacturers);
            i_UserInfo.TryGetValue("MaxAirPressure", out String MaxAirPressure);
            i_UserInfo.TryGetValue("VehicleType", out String Vehicletype);
            List<Wheel> Wheels = new List<Wheel>();
            createWheelList(WheelsManufacturers, WheelsAirPressure, MaxAirPressure, Wheels);
            switch (Enum.Parse(typeof(eVehicleType), Vehicletype,true))
            {
                case (eVehicleType.Car):
                case (eVehicleType.ECar):
                    Car newCar = handleCarsCase(i_UserInfo, energyType, ModelName, theLicenseNumber, Wheels);
                    this.m_InShop.Add(newCar.LicenseNumber, newCar);
                    break;

                case (eVehicleType.Motorcycle):
                case (eVehicleType.EMotorcycle):
                    Motorcycle newMotorcycle = handleMotorcycleCase(i_UserInfo, energyType, ModelName, theLicenseNumber, Wheels);
                    this.m_InShop.Add(newMotorcycle.LicenseNumber, newMotorcycle);
                    break;

                case (eVehicleType.Truck):
                    Truck newTruck = handleTruckCase(i_UserInfo, energyType, ModelName, theLicenseNumber, Wheels);
                    this.m_InShop.Add(newTruck.LicenseNumber, newTruck);
                    break;
            }

            return "The vehicle was added to the garage.";
        }

        public static Car handleCarsCase(Dictionary<String, String> i_UserInfo, eEnergySource energyType, String ModelName, String theLicenseNumber, List<Wheel> Wheels)
        {
            EnergyType energy;
            String carType = null;
            Car newCar;
            i_UserInfo.TryGetValue("carColor", out String carColor);
            i_UserInfo.TryGetValue("numOfDoors", out String numOfDoors);
            eCarColor color = (eCarColor)Enum.Parse(typeof(eCarColor), carColor, true);
            eNumOfDoors numDoors = (eNumOfDoors)Enum.Parse(typeof(eNumOfDoors), numOfDoors);
            if (energyType == eEnergySource.Battery)
            {
                carType = "ECar";
                i_UserInfo.TryGetValue("RemainingEnergyTime", out String RemainingEnergyTime);
                i_UserInfo.TryGetValue("EnergyMaxCapacity", out String EnergyMaxCapacity);
                energy = new Battery(float.Parse(RemainingEnergyTime), float.Parse(EnergyMaxCapacity), energyType);
            }
            else
            {
                carType = "Car";
                i_UserInfo.TryGetValue("typeOfFuel", out String typeOfFuel);
                eFuelType fuelKind = (eFuelType)Enum.Parse(typeof(eFuelType), typeOfFuel);
                i_UserInfo.TryGetValue("fuelAmount", out String fuelAmount);
                i_UserInfo.TryGetValue("fuelCapacity", out String fuelCapacity);
                energy = new FuelTank(fuelKind, float.Parse(fuelAmount), energyType, float.Parse(fuelCapacity));
            }

            newCar = new Car(ModelName, theLicenseNumber, energy, Wheels, color, numDoors);
            newCar.TypeOfVehicle = carType;
            return newCar;
            
        }

        public static Motorcycle handleMotorcycleCase(Dictionary<String, String> i_UserInfo, eEnergySource energyType, String ModelName, String theLicenseNumber, List<Wheel> Wheels)
        {
            EnergyType energy;
            Motorcycle newMotorcycle;
            String motoType = null;
            i_UserInfo.TryGetValue("LicenseType", out String LicenseType);
            i_UserInfo.TryGetValue("EngineVolume", out String Volume);
            eLicenseType Type = (eLicenseType)Enum.Parse(typeof(eLicenseType), LicenseType);
            int EngineVolume = int.Parse(Volume);
            if (energyType == eEnergySource.Battery)
            {
                motoType = "EMotorcycle";
                i_UserInfo.TryGetValue("RemainingEnergyTime", out String RemainingEnergyTime);
                i_UserInfo.TryGetValue("EnergyMaxCapacity", out String EnergyMaxCapacity);
                energy = new Battery(float.Parse(RemainingEnergyTime), float.Parse(EnergyMaxCapacity), energyType);
            }
            else
            {
                motoType = "Motorcycle";
                i_UserInfo.TryGetValue("typeOfFuel", out String typeOfFuel);
                eFuelType fuelKind = (eFuelType)Enum.Parse(typeof(eFuelType), typeOfFuel);
                i_UserInfo.TryGetValue("fuelAmount", out String fuelAmount);
                i_UserInfo.TryGetValue("fuelCapacity", out String fuelCapacity);
                energy = new FuelTank(fuelKind, float.Parse(fuelAmount), energyType, float.Parse(fuelCapacity));
            }

            newMotorcycle = new Motorcycle(ModelName, theLicenseNumber, energy, Wheels, Type, EngineVolume);
            newMotorcycle.TypeOfVehicle = motoType;

            return newMotorcycle;

        }

        public static Truck handleTruckCase(Dictionary<String, String> i_UserInfo, eEnergySource energyType, String ModelName, String theLicenseNumber, List<Wheel> Wheels)
        {
            EnergyType energy;
            Truck newTruck;
            i_UserInfo.TryGetValue("DangerousMaterials", out String DangerousMaterials);
            bool dangerousMaterials = bool.Parse(DangerousMaterials);
            i_UserInfo.TryGetValue("MaxCargoWeight", out String MaxCargoWeight);
            float maxCargoWeight = float.Parse(MaxCargoWeight);
            i_UserInfo.TryGetValue("typeOfFuel", out String truckFuelType);
            eFuelType truckFuelKind = (eFuelType)Enum.Parse(typeof(eFuelType), truckFuelType);
            i_UserInfo.TryGetValue("fuelAmount", out String truckFuelAmount);
            i_UserInfo.TryGetValue("fuelCapacity", out String truckFuelCapacity);
            energy = new FuelTank(truckFuelKind, float.Parse(truckFuelAmount), energyType, float.Parse(truckFuelCapacity));
            newTruck = new Truck(ModelName, theLicenseNumber, energy, Wheels, dangerousMaterials, maxCargoWeight);
            newTruck.TypeOfVehicle = "Truck";

            return newTruck;

        }

        private List<Wheel> createWheelList(string i_WheelsManufacturers, string i_WheelsAirPressure, string i_MaxAirPressure, List<Wheel> i_Wheels)
        {
            float MaxPressure = float.Parse(i_MaxAirPressure);
            string[] WheelsManu = i_WheelsManufacturers.Split(' ');
            string[] WheelsPressure = i_WheelsAirPressure.Split(' ');

            for(int i = 0; i < WheelsManu.Length; i++)
            {
                Wheel newWhell = new Wheel(WheelsManu[i], float.Parse(WheelsPressure[i]), MaxPressure);
                i_Wheels.Append(newWhell);
            }

            return i_Wheels;
        }

        public List<String> GetLicenses(string i_Option)
        {
            eVehicleStatus option = eVehicleStatus.InRepair; 
            List<String> inShopLicensesWithOption = new List<String>();
            List<String> inShopLicenses = this.m_InShop.Keys.ToList();
            if(!i_Option.Equals("all")) 
            {
                 option = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_Option);
                Console.WriteLine(option.ToString());
            }

            foreach (String key in inShopLicenses)
            {
                if(i_Option.Equals("all"))
                {
                    this.m_Costumers.TryGetValue(key, out GarageTicket ticket);
                    inShopLicensesWithOption.Add(ticket.LicensePlate.ToString());
                }
                else
                {
                    this.Costumers.TryGetValue(key, out GarageTicket ticket);
                    if(ticket.Status == option)
                    {
                        inShopLicensesWithOption.Add(ticket.LicensePlate.ToString());
                        
                    }
                }
            }

            return inShopLicensesWithOption;
        }

        public bool ChangeVehicleStatus(string i_LicensePlate, string i_WantedStatus)
        {
            bool vehicleExists = true;

            eVehicleStatus status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_WantedStatus);
            if(!InShop.ContainsKey(i_LicensePlate))
            {
                return false;
            }
            else
            {
                Costumers.TryGetValue(i_LicensePlate, out GarageTicket customerTicket);
                customerTicket.Status = status;
            }
            return vehicleExists;

        }

        public bool InflateAllWheels(String licenseNumber)
        {
            bool licenseExists = true;

            this.m_InShop.TryGetValue(licenseNumber, out Vehicle CustomerVehicle);
            if(CustomerVehicle != null)
            {
                List<Wheel> wheels = CustomerVehicle.Wheels;
                foreach (Wheel wheel in wheels)
                {
                    wheel.InflateTyreToMax();
                }
            }
            else
            {
                licenseExists = false;
            }

            return licenseExists;
        }

        public bool RefuelVehicle(String i_licenseNumber, string amountTobeRefueled, string o_typeOfFuel = null)
        {
            bool status = true;
            InShop.TryGetValue(i_licenseNumber, out Vehicle CustomerVehicle);
            eFuelType typeOfF = (eFuelType)Enum.Parse(typeof(eFuelType), o_typeOfFuel);
            switch (CustomerVehicle.GetType().ToString())
            {
                case ("Car"):
                    Car CarToFuel = (Car)CustomerVehicle;
                    if(CustomerVehicle.EnergyType.GetTypeOfEnergy() != typeOfF.ToString())
                    {
                        status = false;
                    }
                    else
                    {
                        CarToFuel.EnergyType.Refuel(typeOfF, float.Parse(amountTobeRefueled));
                    }
                    break;
                case ("Motorcycle"):
                    Motorcycle motoToFuel = (Motorcycle)CustomerVehicle;
                    if(CustomerVehicle.EnergyType.GetTypeOfEnergy() != typeOfF.ToString())
                    {
                        status = false;

                    }
                    else
                    {
                        motoToFuel.EnergyType.Refuel(typeOfF, float.Parse(amountTobeRefueled));
                    }
                    break;
                case ("Truck"):
                    Truck truckToFuel = (Truck)CustomerVehicle;
                    if(CustomerVehicle.EnergyType.GetTypeOfEnergy() != typeOfF.ToString())
                    {
                        status = false;
                    }
                    else
                    {
                        truckToFuel.EnergyType.Refuel(typeOfF, float.Parse(amountTobeRefueled));
                    }
                    break;
            }

            return status;
        }

        public bool ForceRefuelVehicle(String i_LicenseNumber, string o_AmountTobeRefueled, string o_TypeOfFuel = null)
        {
            bool status = true;
            InShop.TryGetValue(i_LicenseNumber, out Vehicle CustomerVehicle);
            eFuelType typeOfF = (eFuelType)Enum.Parse(typeof(eFuelType), o_TypeOfFuel);
            switch (CustomerVehicle.GetType().ToString()) 
            {
                case ("Car"):
                    Car CarToFuel = (Car)CustomerVehicle;
                    CarToFuel.EnergyType.Refuel(typeOfF, float.Parse(o_AmountTobeRefueled));
                    break;
                case ("Motorcycle"):
                    Motorcycle motoToFuel = (Motorcycle)CustomerVehicle;
                    motoToFuel.EnergyType.Refuel(typeOfF, float.Parse(o_AmountTobeRefueled));
                    break;
                case ("Truck"):
                    Truck truckToFuel = (Truck)CustomerVehicle;
                    truckToFuel.EnergyType.Refuel(typeOfF, float.Parse(o_AmountTobeRefueled));
                    break;
            }

            return status;
        }

        public void RechargeVehicle(String i_LicenseNumber, string o_AmountTobeCharged)
        {
            float amountToCharge = float.Parse(o_AmountTobeCharged);
            amountToCharge = amountToCharge / 60;
            InShop.TryGetValue(i_LicenseNumber, out Vehicle CustomerVehicle);
            switch (CustomerVehicle.GetType().ToString())
            {
                case ("Car"):
                case ("Motorcycle"):
                case ("Truck"):
                    break;
                case ("EMotorcycle"):
                case ("Ecar"):
                    CustomerVehicle.EnergyType.Recharge(float.Parse(o_AmountTobeCharged));
                    break;
            }
        }

        public void CreateGarageTicket(Dictionary<String, String> io_UserInfo)
        {
            io_UserInfo.TryGetValue("CustomerName", out String CustomerName);
            io_UserInfo.TryGetValue("CustomerPhoneNumber", out String CustomerPhoneNumber);
            io_UserInfo.TryGetValue("LicenseNumber", out String LicensePlate);
            io_UserInfo.TryGetValue("CustomerStatus", out String customerStatus);
            eVehicleStatus CustomerStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), customerStatus);
            GarageTicket newCustomerTicket = new GarageTicket(CustomerName, CustomerPhoneNumber, CustomerStatus, LicensePlate);
            this.Costumers.Add(LicensePlate, newCustomerTicket);
        }



        public Boolean KnownToGarage(String i_LicenseNumber)
        {
            Boolean isKnown = false;
            if(this.InShop.ContainsKey(i_LicenseNumber))
            {
                isKnown = true;
            }

            return isKnown;
        }
    }
}