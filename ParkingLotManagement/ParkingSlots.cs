using System;

namespace ParkingLotManagement
{
    public class ParkingSlots
    {
        public static Ticket[] ?twoWheelerTickets;
        public static Ticket[] ?fourWheelerTickets;
        public static Ticket[] ?heavyVehicleTickets;
        public int NumberOfTwoWheelers { get; private set; }
        public int NumberOfFourWheelers { get; private set; }
        public int NumberOfHeavyVehicles { get; private set; }

        public void NumberOfVehicles()
        {
            
        twoWheelerSlotsCount: Console.WriteLine("Enter the count of Two Wheeler Slots :");

            try
            {
                NumberOfTwoWheelers = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter  positive Integer value");
                goto twoWheelerSlotsCount;
            }
            if (NumberOfTwoWheelers < 0)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto twoWheelerSlotsCount;
            }
        fourWheelerSlotsCount: Console.WriteLine("Enter the count of Four Wheeler Slots:");

            try
            {
                NumberOfFourWheelers = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto fourWheelerSlotsCount;
            }
            if (NumberOfFourWheelers < 0)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto fourWheelerSlotsCount;
            }
        heavyVehicleSlotsCount: Console.WriteLine("Enter the count of Heavy Vehicle Slots");

            try
            {
                NumberOfHeavyVehicles = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto heavyVehicleSlotsCount;
            }
            if (NumberOfHeavyVehicles < 0)
            {
                Console.WriteLine("Enter Positive Integer value");
                goto heavyVehicleSlotsCount;
            }
        }
        public void SlotInitialization()
        {
            twoWheelerTickets = new Ticket[NumberOfTwoWheelers];
            fourWheelerTickets = new Ticket[NumberOfFourWheelers];
            heavyVehicleTickets = new Ticket[NumberOfHeavyVehicles];
        }
        
    }
}
