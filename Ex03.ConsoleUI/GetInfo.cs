using System;
using System.Collections.Generic;
using FormatException = System.FormatException;

namespace Ex03.ConsoleUI
{
    public class GetInfo
    {


        public static void GetVehicleInfo(Dictionary<String, String> i_UserInfo)
        {
            Console.WriteLine("What is the vehicle type?");
            VehicleTypeMenu();
            String typeChoice = Console.ReadLine();
            switch(int.Parse(typeChoice))
            {
                case(1):
                    carCase(i_UserInfo);
                    break;

                case(2):
                    ECarCase(i_UserInfo);
                    break;

                case(3):
                    MotorcycleCase(i_UserInfo);
                    break;
                case(4):
                    EMotorcycleCase(i_UserInfo);
                    break;
                case(5):
                    TruckCase(i_UserInfo);
                    break;
            }

            Console.WriteLine("What is the vehicle's model? \n");
            i_UserInfo.Add("ModelName", Console.ReadLine());
            Console.Clear();
            GetManufactorers(i_UserInfo);
            GetWheelsPressure(i_UserInfo);
        }

        public static void carCase(Dictionary<String, String> i_UserInfo)
        {
            String amountOfFuel;

            i_UserInfo.Add("VehicleType", "Car");
            i_UserInfo.Add("MaxAirPressure", "32");
            i_UserInfo.Add("EnergyType", "FuelTank");
            i_UserInfo.Add("typeOfFuel", "Octan98");
            Console.WriteLine("How much fuel is left in the tank? (please enter the amount of fuel in Liters)");
            amountOfFuel = Console.ReadLine();
            while (!FloatInputValidatorz(amountOfFuel, 0, 45))
            {
                Console.WriteLine("How much fuel is left in the tank? (please enter the amount of fuel in Liters)");
                amountOfFuel = Console.ReadLine();
            }
            i_UserInfo.Add("fuelAmount", amountOfFuel);
            i_UserInfo.Add("fuelCapacity", "45");

        }

        public static void ECarCase(Dictionary<String, String> i_UserInfo)
        {
            string amountOfElectricity;

            i_UserInfo.Add("VehicleType", "ECar");
            i_UserInfo.Add("MaxAirPressure", "32");
            i_UserInfo.Add("EnergyType", "Battery");
            Console.WriteLine("How much operating time is left in the battery? (hours)");
            amountOfElectricity = Console.ReadLine();
            while (!FloatInputValidatorz(amountOfElectricity, 0, 3.2f))
            {
                Console.WriteLine("How much operating time is left in the battery? (hours)");
                amountOfElectricity = Console.ReadLine();
            }

            i_UserInfo.Add("RemainingEnergyTime", amountOfElectricity);
            i_UserInfo.Add("EnergyMaxCapacity", "3.2");

        }

        public static void MotorcycleCase(Dictionary<String, String> i_UserInfo)
        {
            String amountOfFuel;

            i_UserInfo.Add("VehicleType", "Motorcycle");
            i_UserInfo.Add("MaxAirPressure", "30");
            i_UserInfo.Add("EnergyType", "FuelTank");
            i_UserInfo.Add("typeOfFuel", "Octan95");
            Console.WriteLine("How much fuel is left in the tank? (please enter the amount of fuel in Liters)");
            amountOfFuel = Console.ReadLine();
            while (!FloatInputValidatorz(amountOfFuel, 0, 45))
            {
                Console.WriteLine("How much fuel is left in the tank? (please enter the amount of fuel in Liters)");
                amountOfFuel = Console.ReadLine();
            }

            i_UserInfo.Add("fuelAmount", amountOfFuel);
            i_UserInfo.Add("fuelCapacity", "6");

        }

        public static void EMotorcycleCase(Dictionary<String, String> i_UserInfo)
        {
            string amountOfElectricity;

            i_UserInfo.Add("VehicleType", "EMotorcycle");
            i_UserInfo.Add("MaxAirPressure", "30");
            i_UserInfo.Add("EnergyType", "Battery");
            Console.WriteLine("How much operating time is left in the battery? (hours)");
            amountOfElectricity = Console.ReadLine();
            while (FloatInputValidatorz(amountOfElectricity, 0, 3.2f))
            {
                Console.WriteLine("How much operating time is left in the battery? (hours)");
                amountOfElectricity = Console.ReadLine();
            }

            i_UserInfo.Add("RemainingEnergyTime", amountOfElectricity);
            Console.WriteLine("What is the battery's total operating time capacity?");
            i_UserInfo.Add("EnergyMaxCapacity", "1.8");

        }

        public static void TruckCase(Dictionary<String, String> i_UserInfo)
        {
            string amountOfFuel;

            i_UserInfo.Add("VehicleType", "Truck");
            i_UserInfo.Add("MaxAirPressure", "26");
            i_UserInfo.Add("EnergyType", "FuelTank");
            i_UserInfo.Add("typeOfFuel", "Soler");
            Console.WriteLine("How much fuel is left in the tank? (please enter the amount of fuel in Liters)");
            amountOfFuel = Console.ReadLine();
            while (!FloatInputValidatorz(amountOfFuel, 0, 120))
            {
                Console.WriteLine("How much fuel is left in the tank? (please enter the amount of fuel in Liters)");
                amountOfFuel = Console.ReadLine();
            }

            i_UserInfo.Add("fuelAmount", amountOfFuel);
            i_UserInfo.Add("fuelCapacity", "120");

        }
        public static int GetNumOfWheels(String i_CarType)
        {

            int numOfWheels = 0;
            switch(i_CarType)
            {
                case("Car"):
                case("ECar"):
                    numOfWheels = 4;
                    break;
                case("Motorcycle"):
                case("EMotorcycle"):
                    numOfWheels = 2;
                    break;
                case("Truck"):
                    numOfWheels = 16;
                    break;
            }

            return numOfWheels;
        }

        public static void GetManufactorers(Dictionary<String, String> i_UserInfo)
        {
            i_UserInfo.TryGetValue("VehicleType", out String kindOfVehicle);
            int numOfWheels = GetNumOfWheels(kindOfVehicle);
            Console.WriteLine(Environment.NewLine + "Please insert your vehicle's wheels manufacturers." +
                              Environment.NewLine +"Please enter the names of the manafacturers of each of your vehicle's wheels in the following order," +
                              Environment.NewLine + "we go from the front to the rear and from left to right." +
                              "So for example for a car (4 wheels) we would go:" + Environment.NewLine + "FrontLeftWheelManufactur FrontRightWheelManufactur RearLeftWheelManufactur RearRightWheelManufactur");
            String Manufactorers = Console.ReadLine();
            int length = Manufactorers.Length;
            while(Manufactorers.EndsWith(" "))
            {
                Manufactorers = Manufactorers.Substring(0, Manufactorers.Length - 1);
            }

            while(!StringLengthInputValidator(Manufactorers, numOfWheels))
            {
                Console.WriteLine("Please enter the manufacturers names of each one of the vehicles wheels.");
                Manufactorers = Console.ReadLine();
            }

            i_UserInfo.Add("WheelsManufacturers", Manufactorers);
        }

        public static void GetWheelsPressure(Dictionary<String, String> i_UserInfo)
        {
            i_UserInfo.TryGetValue("VehicleType", out String kindOfVehicle);
            int numOfWheels = GetNumOfWheels(kindOfVehicle);
            Console.WriteLine("Following the same method as for the manafacturing, please fill in the vehicle's wheels air pressure in psi.");
            String Wheels = Console.ReadLine();
            int length = Wheels.Length;
            while(Wheels.EndsWith(" "))
            {
                Wheels = Wheels.Substring(0, Wheels.Length - 1);
            }

            while(!StringLengthInputValidator(Wheels, numOfWheels))
            {
                Console.WriteLine("Please enter the manufacturers names of each one of your wheels.");
                Wheels = Console.ReadLine();
            }
            i_UserInfo.Add("WheelsAirPressure", Wheels);
        }

        public static string AllLicensesMenu()
        {
            String option = null;
            Console.WriteLine("Please enter the corresponding number to the desired status. " + Environment.NewLine +
                              "1 Get all cars 'InRepair' status. " + Environment.NewLine +"2 Get all cars with 'Repaired' status." +
                              Environment.NewLine + " 3 Get all vehicles with 'PaidFor' status. " + Environment.NewLine + " 4 Get all vehicle in the garage.");
            string userInput = Console.ReadLine();
            while(!IntInputValidator(userInput, 1, 4))
            {
                userInput = Console.ReadLine();
            }

            int userChoice = int.Parse(userInput);
                switch(userChoice)
                {
                    case(1):
                        option = "InRepair";
                        break;
                    case(2):
                        option = "Repaired";
                        break;
                    case(3):
                        option = "PaidFor";
                        break;
                    case(4):
                        option = "all";
                        break;
                }
            
            return option;
        }

        public static void GetCarInfo(Dictionary<String, String> i_UserInfo)
        {
            Console.WriteLine("Please enter the car's color.");
            String wantedColor = CarColorMenu();
            i_UserInfo.Add("carColor", wantedColor);
            Console.WriteLine("How many doors does the car have?");
            i_UserInfo.Add("numOfDoors", Console.ReadLine());
        }

        public static void GetMotorcycleInfo(Dictionary<String, String> i_UserInfo)
        {
            MotorcycleLicenseTypeMenu();
            i_UserInfo.Add("LicenseType", Console.ReadLine());
            Console.WriteLine("What is the engine's volume?");
            i_UserInfo.Add("EngineVolume", Console.ReadLine());
        }

        public static void GetTruckInfo(Dictionary<String, String> i_UserInfo)
        {
            Console.WriteLine("Does the truck contain dangerous materials? (enter Y for yes and N for no)");
            if((Console.ReadLine() == "Y") || (Console.ReadLine() == "y")){
                i_UserInfo.Add("DangerousMaterials", "true");
            }
            else
            {
                i_UserInfo.Add("DangerousMaterials", "false");
            }
            Console.WriteLine("What is the truck maximum cargo weight?");
            i_UserInfo.Add("MaxCargoWeight", Console.ReadLine());
        }


        public static void GetCustomerInfo(Dictionary<String, String> i_UserInfo)
        {
            Console.WriteLine("First, Lets set up a members card. What is the owner's full name?" +
                              "\nExample: 'Firstname Lastname'");
            i_UserInfo.Add("CustomerName", Console.ReadLine()); 
            Console.WriteLine("Please enter the owner's phone number.");
            string phoneNum = Console.ReadLine();
            while(!FloatInputValidatorz(phoneNum, 0, 9999999999))
            {
                phoneNum = Console.ReadLine();
            }
            i_UserInfo.Add("CustomerPhoneNumber", phoneNum);
            i_UserInfo.Add("CustomerStatus", "InRepair");
            Console.WriteLine("Great, we have set up a membership card!");
        }

        public static void VehicleTypeMenu()
        {
            Console.WriteLine("Please enter the corrosponding number to the type you want to choose: \n" +
                              " 1 Car \n 2 Electronic Car \n 3 Motorcycle \n 4 Electronic Motorcycle \n 5 Truck ");
        }

        public static void MotorcycleLicenseTypeMenu()
        {
            Console.WriteLine("Please enter the corrosponding number to the type you want to choose:\n" +
                              "1 A\n 2 A1\n 3 A2\n 4 B\n");
        }

        public static bool IntInputValidator(string o_Input, int i_MinValidInput, int i_MaxValidInput)
        {
            bool isParsed = true;
            float inputInInt = 0; 

            try
            {
                inputInInt = int.Parse(o_Input);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter an integer number.");
                isParsed = false;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Please enter an integer number.");
                isParsed = false;
            }
            if(inputInInt < i_MinValidInput || i_MaxValidInput < inputInInt)
            {
                Console.WriteLine("Please enter an integer number between {0} and {1}.", i_MinValidInput, i_MaxValidInput);
                isParsed = false;
            }

            return isParsed;
        }

        public static bool FloatInputValidatorz(string i_Input, float i_MinValidInput, float i_MaxValidInput)
        {
            bool isParsed = true;
            float inputInFloat = 0; 

            try
            {
                inputInFloat = float.Parse(i_Input);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter a decimal number.");
                isParsed = false;
            } 
            catch(ArgumentNullException e)
            {
                Console.WriteLine("Please enter a decimal number.");
                isParsed = false;
            }

            if(inputInFloat < i_MinValidInput || i_MaxValidInput < inputInFloat)
            {
                Console.WriteLine("Please enter a decimal number.");
                isParsed = false;
            }

            return isParsed;
        }

        public static bool StringLengthInputValidator(string io_Input, int i_NumOfWantedArgs)
        {
            bool isParsed = true;
            string[] input = io_Input.Split(' ');

            if(input.Length != i_NumOfWantedArgs)
            {
                Console.WriteLine("Please enter {0} arguments.", i_NumOfWantedArgs);
                isParsed = false;
            }

            if(string.IsNullOrEmpty(io_Input))
            {
                Console.WriteLine("Please enter {0} arguments.", i_NumOfWantedArgs);
                isParsed = false;
            }

            return true;
        }

        public static string StatusTypeMenu()
        {
            string wantedStatus = null;

            Console.WriteLine("Please enter the corresponding number to the relevant status.\n" +
                              "1 InRepair.\n 2 Repaired.\n 3 PaidFor");
            string userChoice = Console.ReadLine();
            while(!IntInputValidator(userChoice, 1, 3))
            {
                userChoice = Console.ReadLine();
            }

            switch (int.Parse(userChoice))
            {
                case 1:
                    wantedStatus = "InRepair";
                    break;

                case 2:
                    wantedStatus = "Repaired";
                    break;

                case 3:
                    wantedStatus = "PaidFor";
                    break;
            }

            return wantedStatus;
        }

        public static string FuelTypeMenu()
        {
            Console.Clear();
            string fuelWanted= null;
            Console.WriteLine("Please enter the corresponding number to the relevant fuel type.\n" +
                              "1 Octan95.\n 2 Octan96.\n 3 Octan98\n 4 Soler");
            string userChoice = Console.ReadLine();
            while(!IntInputValidator(userChoice, 1, 4))
            {
                userChoice = Console.ReadLine();
            }

            switch (int.Parse(userChoice))
            {
                case 1:
                    fuelWanted = "Octan95";
                    break;

                case 2:
                    fuelWanted = "Octan96";
                    break;

                case 3:
                    fuelWanted = "Octan98";
                    break;

                case 4:
                    fuelWanted = "Soler";
                    break;
            }

            return fuelWanted;
        }

        public static string CarColorMenu()
        { 
            Console.Clear();
            string wantedColor = null;
            Console.WriteLine("Please enter the corresponding number to the relevant car color.\n" +
                              "1 Red.\n 2 Black.\n 3 Silver.\n 4 White");
            String userChoice = Console.ReadLine();
            while(!IntInputValidator(userChoice, 1, 4))
            {
                userChoice = Console.ReadLine();
            }

            switch (int.Parse(userChoice))
            {
                case 1:
                    wantedColor = "Red";
                    break;

                case 2:
                    wantedColor = "Black";
                    break;

                case 3:
                    wantedColor = "Silver";
                    break;

                case 4:
                    wantedColor = "White";
                    break;
            }

                return wantedColor;
            }

        public static bool NewActionMenu()
        {
            bool newAction = false;

            Console.WriteLine("Do you want to make another action?\n" +
                              "Enter 'Y' for yes.\nEnter 'N' for no");
            String userChoice = Console.ReadLine();
            while((!userChoice.Equals("y")) && (!userChoice.Equals("Y")) && (!userChoice.Equals("n")) && (!userChoice.Equals("N")))
            {
                Console.WriteLine("Please enter 'y' for yes or 'n' for no");
                userChoice = Console.ReadLine();
            }

            if(userChoice.Equals("y") || userChoice.Equals("Y"))
            {
                newAction = true;
            }

            return newAction;
        }
    }
}