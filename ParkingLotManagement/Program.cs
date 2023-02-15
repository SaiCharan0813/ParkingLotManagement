using System;

namespace ParkingLotManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            ParkingLotSystem vehicles= new();
            Console.WriteLine("-----Welcome to parking lot simulation------");
            ParkingSlots numberOfSlots = new();
            numberOfSlots.NumberOfVehicles();
            numberOfSlots.SlotInitialization();
            int userChoice;
            Constant.VehicleType userVehicleChoice; 
            bool isOptionValid = false;
            while (isOptionValid != true)
            {

            enterUserChoice: Console.WriteLine("1.See Parking Lot current occupancy details\n2.Park Vehicle and Issue Ticket\n3.Un-park Vehicle\n4.Exit");

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserChoice;
                }
                if (userChoice < 1 && userChoice > 4)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserChoice;
                }
                switch (userChoice)
                {
                    
                    case 1:
                        vehicles.DisplayAllSlots(numberOfSlots.NumberOfTwoWheelers,numberOfSlots.NumberOfFourWheelers,numberOfSlots.NumberOfHeavyVehicles);
                        break;
                    case 2:

                    chooseVehicleType: Console.WriteLine("1.Two Wheeler\n2.Four Wheeler\n3.Heavy vehicle");

                        try
                        {
                            userVehicleChoice =(Constant.VehicleType) Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseVehicleType;
                        }
                        if ((int)userVehicleChoice < 1 || (int)userVehicleChoice > 3)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseVehicleType;
                        }                   
                        vehicles.AddVehicle(userVehicleChoice);
                        break;
                    case 3:
                    chooseUnParkingVehicleType: Console.WriteLine("1.Two Wheeler\n2.Four Wheeler\n3.Heavy vehicle");

                        try
                        {
                            userVehicleChoice = (Constant.VehicleType)Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseUnParkingVehicleType;
                        }
                        if ((int)userVehicleChoice < 1 || (int)userVehicleChoice > 3)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseUnParkingVehicleType;
                        }
                        vehicles.UnParkVehicle(numberOfSlots.NumberOfTwoWheelers,numberOfSlots.NumberOfFourWheelers,numberOfSlots.NumberOfHeavyVehicles,userVehicleChoice);
                              

                        break;
                    case 4:
                        Environment.Exit(0);
                        break;

                }
            }


        }
    }
}
