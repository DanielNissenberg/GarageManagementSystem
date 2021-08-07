using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public static void HandleRun()
        {
            Garage r_Garage = new Garage("Junkyard");
            InitiationMessage();
            GarageMenu();
            string userChoice = Console.ReadLine();
            HandleUserChoice(r_Garage , userChoice);
            NewRun(r_Garage);
            Console.ReadLine();
        }

        public static void NewRun(Garage i_Garage)
        {
            Boolean anotherAction = GetInfo.NewActionMenu();
            while(anotherAction)
            {
                Console.Clear();
                GarageMenu();
                string userChoice = Console.ReadLine();
                HandleUserChoice(i_Garage, userChoice);
                anotherAction = GetInfo.NewActionMenu();
            }
        }

        public static void InitiationMessage()
        {
            Console.WriteLine("Welcome to your garage management system:");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("           _             _                        _      ");
            Console.WriteLine("          | |           | |                      | |     ");
            Console.WriteLine("          | |_   _ _ ___| | ___   _  __ _ _ __ __| |     ");
            Console.WriteLine("       _  | | | | | '_  | |/ / | | |/ _` | '__/ _` |     ");
            Console.WriteLine("      | |_| | |_| | | | |   <| |_| | (_| | | | (_| |     ");
            Console.WriteLine("      l_____|___,_|_| |_|_| \\_\\__, |\\__,_|_|  \\__,_| ");
            Console.WriteLine("                              __/ /                      ");
            Console.WriteLine("                             /___/                       ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void GarageMenu()
        {
            Console.WriteLine("Please choose one of our Junkyard's options, you can:");
            Console.WriteLine("1. Insert a new vehicle into the garage.");
            Console.WriteLine("2. See the license numbers of all the vehicles currently in the garage.");
            Console.WriteLine("3. Change the status of any vehicle in the garage.");
            Console.WriteLine("4. Inflate the tyres of any vehicle in the garage.");
            Console.WriteLine("5. Refuel any fuel-based vehicle in the garage.");
            Console.WriteLine("6. Charge any electric-based vehicle in the garage.");
            Console.WriteLine("7. See the information card of any vehicle in the garage.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Please insert the task number you would like to perform, and then press 'Enter'.");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        public static void HandleUserChoice(Garage io_Garage, String i_UserChoice)
        {
            Console.Clear();
            while(!GetInfo.IntInputValidator(i_UserChoice, 1,7))
            {
                GarageMenu();
                i_UserChoice = Console.ReadLine();
            }

            int numOfChoice = int.Parse(i_UserChoice);
            Console.Clear();
            switch (numOfChoice)
            {
                case (1):
                    VehicleInsert(io_Garage);
                    break;
                case (2):
                    GetAllLicenses(io_Garage);
                    break;
                case (3):
                    ChangeVehicleStatus(io_Garage);
                    break;
                case (4):
                    InflateWheels(io_Garage);
                    break;
                case (5):
                    Refuel(io_Garage);
                    break;
                case (6):
                    Recharge(io_Garage);
                    break;
                case (7):
                    GetInformation(io_Garage);
                    break;
            }
        }

        private static void VehicleInsert(Garage io_Garage)
        {
            Dictionary<String, String> userInfo = new Dictionary<string, string>();
            Console.WriteLine("Please enter the license number.");
            string licenseNumber = Console.ReadLine();
            userInfo.Add("LicenseNumber", licenseNumber);
            if(io_Garage.KnownToGarage(licenseNumber))
            {
                GarageTicket insertedVehicleTicket;
                io_Garage.Costumers.TryGetValue(licenseNumber, out insertedVehicleTicket);
                Console.WriteLine("The car is already in the garage. I have changed its status to 'InRepair'");
                insertedVehicleTicket.Status = eVehicleStatus.InRepair;
            }
            else
            {
                GetInfo.GetCustomerInfo(userInfo);
                GetInfo.GetVehicleInfo(userInfo);
                userInfo.TryGetValue("VehicleType", out String vehicleType);
                eVehicleType newType = (eVehicleType)Enum.Parse(typeof(eVehicleType), vehicleType);
                switch (newType)
                {
                    case (eVehicleType.Car):
                    case (eVehicleType.ECar):
                        GetInfo.GetCarInfo(userInfo);
                        break;
                    case (eVehicleType.Motorcycle):
                    case (eVehicleType.EMotorcycle):
                        GetInfo.GetMotorcycleInfo(userInfo);
                        break;
                    case (eVehicleType.Truck):
                        GetInfo.GetTruckInfo(userInfo);
                        break;
                }

                io_Garage.CreateGarageTicket(userInfo);
                Console.WriteLine(io_Garage.CreateVehicle(userInfo));
                io_Garage.InShop.TryGetValue(licenseNumber, out Vehicle createdVehicle);
                io_Garage.Costumers.TryGetValue(licenseNumber, out GarageTicket createdTicket);
                createdVehicle.OwnerTicket = createdTicket;
            }
        }

        public static void GetAllLicenses(Garage io_Garage)
        {
            String option = GetInfo.AllLicensesMenu();
            List<String> licenses = io_Garage.GetLicenses(option);
            if(licenses.Count != 0)
            {
                Console.WriteLine("The vehicles corresponding to the chosen option " + option + " are the following:\n");
                foreach (String license in licenses)
                {
                    Console.WriteLine(license);
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles in the garage at the moment.");
            }
        }

        public static void ChangeVehicleStatus(Garage io_Garage)
        {
            Console.WriteLine("Please enter the relevent vehicle's license number.");
            String licensePlate = Console.ReadLine();
            string wantedStatus = GetInfo.StatusTypeMenu();
            if(!io_Garage.ChangeVehicleStatus(licensePlate, wantedStatus)){
                WrongLicensePlate(io_Garage);
            }
            else
            {
                Console.WriteLine("The vehicle status has been changed according to your request.");
            }
        }

        public static void InflateWheels(Garage io_Garage)
        {
            Console.WriteLine("Please enter the vehicle's license plate ");
            string wantedNumber = Console.ReadLine();
            if((io_Garage.InflateAllWheels(wantedNumber))== false)
            {
                WrongLicensePlate(io_Garage);
            }

            Console.WriteLine("The vehicle's tyres have been inflated to the recommended air pressure ");
        }

        public static void Refuel(Garage io_Garage)
        {
            Console.WriteLine("Please enter the relevent vehicle's license number.");
            String licensePlate = Console.ReadLine();
            bool exists = io_Garage.KnownToGarage(licensePlate);
            if(!exists)
            {
                WrongLicensePlate(io_Garage);
                return;
            }

            io_Garage.InShop.TryGetValue(licensePlate, out Vehicle vehicleToBeRefueled);
            if(vehicleToBeRefueled.EnergyType.GetTypeOfEnergy().Equals("Battery"))
            {
                Console.WriteLine("An E-vehicle cannot be refueled.");
                
                return;
            }

            string fuelType = GetInfo.FuelTypeMenu();
            Console.WriteLine("Please enter the amount of litres you want to refuel.");
            string amoutToRefuel = Console.ReadLine();
            bool processOutput = io_Garage.RefuelVehicle(licensePlate, amoutToRefuel, fuelType);
            if(!processOutput)
            {
                Console.WriteLine("You have entered the wrong fuel type, are you sure you want to fuel the vehicle with this kind of fuel?");
                String userChoice = Console.ReadLine();
                if(userChoice.Equals("y") || userChoice.Equals("Y"))
                {
                    io_Garage.ForceRefuelVehicle(licensePlate, amoutToRefuel, fuelType);
                    Console.WriteLine("The vehicle has been refueled.");
                }
                else
                {
                    Console.WriteLine("The vehicle has not been refueled.");
                }
            }
            else
            {
                Console.WriteLine("The vehicle has not been refueled.");
            }
        }

        public static void Recharge(Garage io_Garage)
        {
            Console.WriteLine("Please enter the relevent vehicle's license number.");
            String licensePlate = Console.ReadLine();
            bool exists = io_Garage.KnownToGarage(licensePlate);
            if(!exists)
            {
                WrongLicensePlate(io_Garage);
                
                return;
            }

            io_Garage.InShop.TryGetValue(licensePlate, out Vehicle vehicleToBeRefueled);
            if(vehicleToBeRefueled.EnergyType.GetTypeOfEnergy().Equals("Fueltank"))
            {
                Console.WriteLine("Fuel based vehicle cannot be recharged.");

                return;
            }

            Console.WriteLine("Please enter the amount of minutes you want to recharge, " +
                              "anything that passes the battery's maximum capacity will charge the battery to it's maximum.");
            string amountToRecharge = Console.ReadLine();
            GetInfo.IntInputValidator(amountToRecharge, 0, 192);
            io_Garage.RechargeVehicle(licensePlate, amountToRecharge);
            Console.WriteLine("The vehicle was not recharged.");
        }

        public static void GetInformation(Garage io_Garage)
        {
            Console.WriteLine("Please enter the license number of the vehicle you want to check.");
            String licenseToCheck = Console.ReadLine();
            if(!io_Garage.KnownToGarage(licenseToCheck))
            {
                WrongLicensePlate(io_Garage);
            }

            io_Garage.InShop.TryGetValue(licenseToCheck, out Vehicle toBeChecked);
            List<String> infoList = toBeChecked.GetInfo();
            foreach(string piece in infoList)
            {
                Console.WriteLine(piece);
            }

            switch(toBeChecked.TypeOfVehicle)
            {
                case ("Car"):
                case ("ECar"):
                    Car carToCheck = (Car)toBeChecked;
                    List<String> inform = carToCheck.GetSpecificInfo();
                    foreach (string piece in inform)
                    {
                        Console.WriteLine(piece);
                    }
                    break;
                case ("Motorcycle"):
                case ("EMotorcycle"):
                    Motorcycle MotoToCheck = (Motorcycle)toBeChecked;
                    inform = MotoToCheck.GetSpecificInfo();
                    foreach (string piece in inform)
                    {
                        Console.WriteLine(piece);
                    }
                    break;
                case ("Truck"):
                    Truck TruckToCheck = (Truck)toBeChecked;
                    inform = TruckToCheck.GetSpecificInfo();
                    foreach (string piece in inform)
                    {
                        Console.WriteLine(piece);
                    }
                    break;
            }
        }

        public static void WrongLicensePlate(Garage o_Garage)
        {
            Console.WriteLine("You have entered a license number which does not correspond to any vehicle in our garage, please try again.");
            NewRun(o_Garage);
        }
    }
}