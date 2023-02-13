using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            string slots;
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
            int userChoice = 0;ParkingSlots.VehicleType userVehicleChoice; bool isOptionValid = false;
            while (isOptionValid != true)
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
                            userVehicleChoice =(ParkingSlots.VehicleType) Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseVehicleType;
                        }
                        if ((int)userVehicleChoice < 1 && (int)userVehicleChoice > 3)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseVehicleType;
                        }
                        if ((int)userVehicleChoice == 1)
                        {
                            slots = "twoWheeler";
                        }
                        else if ((int)userVehicleChoice==2)
                        {
                            slots = "fourWheeler";
                        }
                        else
                        {
                            slots = "heavyVehicle";
                        }
                        vehicles.AddVehicle(slots);
                        break;
                    case 3:
                    chooseUnParkingVehicleType: Console.WriteLine("1.Two Wheeler\n2.Four Wheeler\n3.Heavy vwhicle");

                        try
                        {
                            userVehicleChoice = (ParkingSlots.VehicleType)Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseUnParkingVehicleType;
                        }
                        if ((int)userVehicleChoice < 1 && (int)userVehicleChoice > 3)
                        {
                            Console.WriteLine("Enter valid choice");
                            goto chooseUnParkingVehicleType;
                        }
                        if ((int)userVehicleChoice == 1)
                        {
                            slots = "twoWheeler";
                        }
                        else if ((int)userVehicleChoice == 2)
                        {
                            slots = "fourWheeler";
                        }
                        else
                        {
                            slots = "heavyVehicle";
                        }
                        vehicles.UnParkVehicle(twoWheeler, fourWheeler, heavyVehicle,slots);
                              

                        break;
                    case 4:
                        isOptionValid = true;
                        break;

                }
            }


        }
    }
}
