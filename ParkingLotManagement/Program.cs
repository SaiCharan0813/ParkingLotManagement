using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParkingLotManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            Vehicle vehicles= new Vehicle();
            Console.WriteLine("-----Welcome to parking lot simulation------");
            int twoWheeler;
        twoWheelerSlotsCount: Console.WriteLine("Enter the count of Two Wheeler Slots :");

            try
            {
                twoWheeler = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter  positive Integer value");
                goto twoWheelerSlotsCount;
            }
            if (twoWheeler < 0)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto twoWheelerSlotsCount;
            }
            int fourWheeler;
        fourWheelerSlotsCount: Console.WriteLine("Enter the count of Four Wheeler Slots:");

            try
            {
                fourWheeler = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto fourWheelerSlotsCount;
            }
            if (fourWheeler < 0)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto fourWheelerSlotsCount;
            }
            int heavyVehicle;
        heavyVehicleSlotsCount: Console.WriteLine("Enter the count of Heavy Vehicle Slots");

            try
            {
                heavyVehicle = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto heavyVehicleSlotsCount;
            }
            if (heavyVehicle < 0)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto heavyVehicleSlotsCount;
            }
            ParkingSlots vehicle = new ParkingSlots();
            vehicle.SlotInitialization(twoWheeler,fourWheeler,heavyVehicle);
            int userChoice = 0,userVehicleChoice=0; bool isOption = false;
            while (isOption != true)
            {

            enterUserChoice: Console.WriteLine("1.See Parking Lot current occupancy details\n2.Park Vehicle and Issue Ticket\n3.Un-park Vehicle\n4.Exit");

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
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
                        vehicles.DisplayAllSlots(twoWheeler, fourWheeler, heavyVehicle);
                        break;
                    case 2:

                    chooseVehicleType: Console.WriteLine("1.Two Wheeler\n2.Four Wheeler\n3.Heavy vehicle");

                        try
                        {
                            userVehicleChoice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseVehicleType;
                        }
                        if (userVehicleChoice < 1 && userVehicleChoice > 3)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseVehicleType;
                        }
                        switch (userVehicleChoice)
                        {
                            case 1:
                                vehicles.AddTwoWheeler();
                                break;
                            case 2:
                                vehicles.AddFourWheeler();
                                break;
                            case 3:
                                vehicles.AddHeavyVehicle();
                                break;
                        }

                        break;
                    case 3:
                    chooseUnParkingVehicleType: Console.WriteLine("1.Two Wheeler\n2.Four Wheeler\n3.Heavy vwhicle");

                        try
                        {
                            userVehicleChoice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseUnParkingVehicleType;
                        }
                        if (userVehicleChoice < 1 && userVehicleChoice > 3)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseUnParkingVehicleType;
                        }
                        switch (userVehicleChoice)
                        {
                            case 1:
                                vehicles.UnParkTwoWheeler(twoWheeler, fourWheeler, heavyVehicle);
                                break;
                            case 2:
                                vehicles.UnParkFourWheeler(twoWheeler, fourWheeler, heavyVehicle);
                                break;
                            case 3:
                                vehicles.UnParkHeavyVehicle(twoWheeler, fourWheeler, heavyVehicle);
                                break;
                        }

                        break;
                    case 4:
                        isOption = true;
                        break;

                }
            }


        }
    }
}








