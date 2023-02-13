using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class Vehicle
    {
        public static int TicketId = 1;
        public int TokenNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string VehicleNumber { get; set; }
        public double Amount { get; set; }
        
        public void AddTwoWheeler()
        {
            if (ParkingSlots.twoWheeler.Contains(null))
            {
                var indexNumber = ParkingSlots.twoWheeler.Length;
                for (int i = 0; i < ParkingSlots.twoWheeler.Length; i++)
                {
                    if (ParkingSlots.twoWheeler[i] == null)
                    {
                        indexNumber = i;
                        
                        break;
                    }
                }

                if (indexNumber != ParkingSlots.twoWheeler.Length)
                {
                    Vehicle twoWheelerVehicle = new Vehicle();
                    twoWheelerVehicle.TokenNumber = TicketId;
                    Vehicle.TicketId += 1;
                enterTwoWheelerVehicleNumber:


                    Console.WriteLine("Enter vehicle number: ");

                    try
                    {
                        twoWheelerVehicle.VehicleNumber = Console.ReadLine();
                        if (twoWheelerVehicle.VehicleNumber == "")
                        {
                            Console.WriteLine("Enter valid Vehicle Number");
                            goto enterTwoWheelerVehicleNumber;
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Vehicle number");
                        goto enterTwoWheelerVehicleNumber;
                    }
                    twoWheelerVehicle.InTime = DateTime.Now;
                    ParkingSlots.twoWheeler[indexNumber] = twoWheelerVehicle;
                    Console.WriteLine("Your vehicle number is: "+twoWheelerVehicle.VehicleNumber);
                    Console.WriteLine("Your vehicle In Time is: "+twoWheelerVehicle.InTime);
                    Console.WriteLine("Your Vehicle Token Number is:"+twoWheelerVehicle.TokenNumber);
                    
                }
                else
                {
                    Console.WriteLine("No Slots Available");
                }


            }
            else
            {
                Console.WriteLine("No slots available");
            }



        }
        public void AddFourWheeler()
        {
            
            if (ParkingSlots.fourWheeler.Contains(null))
            {
                var indexNumber = ParkingSlots.fourWheeler.Length;
                for (int i = 0; i < ParkingSlots.fourWheeler.Length; i++)
                {
                    if (ParkingSlots.fourWheeler[i] == null)
                    {
                        indexNumber = i;
                        break;
                    }
                }

                if (indexNumber != ParkingSlots.fourWheeler.Length)
                {
                    Vehicle fourWheelerVehicle = new Vehicle();
                    fourWheelerVehicle.TokenNumber = TicketId;
                    Vehicle.TicketId += 1;
                enterFourWheelerVehicleNumber:


                    Console.WriteLine("Enter vehicle number: ");

                    try
                    {
                        fourWheelerVehicle.VehicleNumber = Console.ReadLine();
                        if (fourWheelerVehicle.VehicleNumber == "")
                        {
                            Console.WriteLine("Enter valid Vehicle Number");
                            goto enterFourWheelerVehicleNumber;
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Vehicle number");
                        goto enterFourWheelerVehicleNumber;
                    }
                    fourWheelerVehicle.InTime = DateTime.Now;
                    ParkingSlots.fourWheeler[indexNumber] = fourWheelerVehicle;
                    Console.WriteLine("Your vehicle number is: " + fourWheelerVehicle.VehicleNumber);
                    Console.WriteLine("Your vehicle In Time is: " + fourWheelerVehicle.InTime);
                    Console.WriteLine("Your Vehicle Token Number is:" + fourWheelerVehicle.TokenNumber);

                }
                else
                {
                    Console.WriteLine("No Slots Available");
                }


            }
            else
            {
                Console.WriteLine("No slots available");
            }
        }
        public void AddHeavyVehicle()
        {
            if (ParkingSlots.heavyVehicle.Contains(null))
            {
                var indexNumber = ParkingSlots.heavyVehicle.Length;
                for (int i = 0; i < ParkingSlots.heavyVehicle.Length; i++)
                {
                    if (ParkingSlots.heavyVehicle[i] == null)
                    {
                        indexNumber = i;
                        break;
                    }
                }

                if (indexNumber != ParkingSlots.heavyVehicle.Length)
                {
                    Vehicle heavyWheelerVehicle = new Vehicle();
                    heavyWheelerVehicle.TokenNumber = TicketId;
                    Vehicle.TicketId += 1;

                  
                   
                enterHeavyVehicleNumber:


                    Console.WriteLine("Enter vehicle number: ");

                    try
                    {
                        heavyWheelerVehicle.VehicleNumber = Console.ReadLine();
                        if (heavyWheelerVehicle.VehicleNumber == "")
                        {
                            Console.WriteLine("Enter valid Vehicle Number");
                            goto enterHeavyVehicleNumber;
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter valid Vehicle number");
                        goto enterHeavyVehicleNumber;
                    }
                    heavyWheelerVehicle.InTime = DateTime.Now;
                    ParkingSlots.heavyVehicle[indexNumber] = heavyWheelerVehicle;
                    Console.WriteLine("Your vehicle number is: " + heavyWheelerVehicle.VehicleNumber);
                    Console.WriteLine("Your vehicle In Time is: " + heavyWheelerVehicle.InTime);
                    Console.WriteLine("Your Vehicle Token Number is:" + heavyWheelerVehicle.TokenNumber);
                }
                else
                {
                    Console.WriteLine("No Slots Available");
                }


            }
            else
            {
                Console.WriteLine("No slots available");
            }
        }
        public void UnParkTwoWheeler(int twoWheeler, int fourWheeler, int heavyVehicle)
        {
            int twoWheelerSlotsOccupaid = ParkingSlots.twoWheeler.Count(s => s != null);
            int twoWheelerSlotsAvailable = twoWheeler - twoWheelerSlotsOccupaid;
            if (twoWheelerSlotsAvailable == twoWheeler)
            {
                Console.WriteLine("No vehicles to unpark");
            }
            else
            {
            enterTokenIdNumber:
                Console.WriteLine("Enter Ticket Id :");
                int vehicleTokenId;

                try
                {
                    vehicleTokenId = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Token id number");
                    goto enterTokenIdNumber;
                }
                var index = ParkingSlots.twoWheeler.Length;
                bool isVehicleExist = false;
                for (int i = 0; i < ParkingSlots.twoWheeler.Length; i++)
                {

                    if (ParkingSlots.twoWheeler[i].TokenNumber == vehicleTokenId)
                    {
                        isVehicleExist = true;
                        Console.WriteLine(ParkingSlots.twoWheeler[i].VehicleNumber);

                        index = i;

                        break;
                    }

                }

                if (isVehicleExist == true)
                {
                    Console.WriteLine("Your Vehicle number: "+ParkingSlots.twoWheeler[index].VehicleNumber);
                    ParkingSlots.twoWheeler[index].OutTime = DateTime.Now;
                    Console.WriteLine("Vehicle In Time: " + ParkingSlots.twoWheeler[index].InTime);
                    Console.WriteLine("Vehicle out time: " + ParkingSlots.twoWheeler[index].OutTime);
                    ParkingSlots.twoWheeler[index].Duration = ParkingSlots.twoWheeler[index].OutTime.Subtract(ParkingSlots.twoWheeler[index].InTime);
                    Console.WriteLine("Toatal duration of the vehicle: " + ParkingSlots.twoWheeler[index].Duration);
                    ParkingSlots.twoWheeler[index].Amount = ParkingSlots.twoWheeler[index].Duration.TotalSeconds * 0.1; ;
                    Console.WriteLine("Amount to be paid: " + ParkingSlots.twoWheeler[index].Amount + " Rupees");
                    ParkingSlots.twoWheeler[index] = null;

                }
                else
                {
                    Console.WriteLine("Vehicle not available");
                }
            }

        }
        public void UnParkFourWheeler(int twoWheeler, int fourWheeler, int heavyVehicle)
        {
            int fourWheelerSlotsOccupaid = ParkingSlots.fourWheeler.Count(s => s != null);
            int fourWheelerSlotsAvailable = fourWheeler - fourWheelerSlotsOccupaid;
            if (fourWheelerSlotsAvailable == fourWheeler)
            {
                Console.WriteLine("No vehicles to unpark");
            }
            else
            {
            enterTokenIdNumber:
                Console.WriteLine("Enter Ticket Id :");
                int vehicleTokenId;

                try
                {
                    vehicleTokenId = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Token id number");
                    goto enterTokenIdNumber;
                }
                var index = ParkingSlots.fourWheeler.Length;
                bool isVehicleExist = false;
                for (int i = 0; i < ParkingSlots.fourWheeler.Length; i++)
                {

                    if (ParkingSlots.fourWheeler[i].TokenNumber == vehicleTokenId)
                    {
                        isVehicleExist = true;
                        Console.WriteLine(ParkingSlots.fourWheeler[i].VehicleNumber);

                        index = i;

                        break;
                    }

                }
                if (isVehicleExist == true)
                {
                    Console.WriteLine("Your Vehicle Number: "+ParkingSlots.fourWheeler[index].VehicleNumber);
                    ParkingSlots.fourWheeler[index].OutTime = DateTime.Now;
                    Console.WriteLine("Vehicle In time: " + ParkingSlots.fourWheeler[index].InTime);
                    Console.WriteLine("Vehicle out time: " + ParkingSlots.fourWheeler[index].OutTime);
                    ParkingSlots.fourWheeler[index].Duration = ParkingSlots.fourWheeler[index].OutTime.Subtract(ParkingSlots.fourWheeler[index].InTime);
                    Console.WriteLine("Total duration of the vehicle: " + ParkingSlots.fourWheeler[index].Duration);
                    ParkingSlots.fourWheeler[index].Amount = ParkingSlots.fourWheeler[index].Duration.TotalSeconds * 0.2; ;
                    Console.WriteLine("Amount to be paid: " + ParkingSlots.fourWheeler[index].Amount+ "Rupees");
                    ParkingSlots.fourWheeler[index] = null;

                }
            }
        }
        public void UnParkHeavyVehicle(int twoWheeler, int fourWheeler, int heavyVehicle)
        {
            int heavyVehicleSlotsOccupaid = ParkingSlots.heavyVehicle.Count(s => s != null);
            int heavyVehicleSlotsAvailable = heavyVehicle - heavyVehicleSlotsOccupaid;
            if (heavyVehicleSlotsAvailable == heavyVehicle)
            {
                Console.WriteLine("No vehicles to unpark");
            }
            else
            {
            enterTokenIdNumber:


                Console.WriteLine("Enter Ticket Id :");
                int vehicleTokenId;

                try
                {
                    vehicleTokenId = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter valid Token id number");
                    goto enterTokenIdNumber;
                }
                var index = ParkingSlots.heavyVehicle.Length;
                bool isVehicleExist = false;
             
                for (int i = 0; i < ParkingSlots.heavyVehicle.Length; i++)
                {

                    if (ParkingSlots.heavyVehicle[i].TokenNumber == vehicleTokenId)
                    {
                        isVehicleExist = true;
                        Console.WriteLine(ParkingSlots.heavyVehicle[i].VehicleNumber);

                        index = i;

                        break;
                    }

                }
                if (isVehicleExist == true)
                {
                    Console.WriteLine("Your vehicle Number: "+ParkingSlots.heavyVehicle[index].VehicleNumber);

                    ParkingSlots.heavyVehicle[index].OutTime = DateTime.Now;
                    Console.WriteLine("Vehicle In time: " + ParkingSlots.heavyVehicle[index].InTime);
                    Console.WriteLine("Vehicle out time: " + ParkingSlots.heavyVehicle[index].OutTime);
                    ParkingSlots.heavyVehicle[index].Duration = ParkingSlots.heavyVehicle[index].OutTime.Subtract(ParkingSlots.heavyVehicle[index].InTime);
                    Console.WriteLine("Toatal duration of the vehicle: " + ParkingSlots.heavyVehicle[index].Duration);
                    ParkingSlots.heavyVehicle[index].Amount = ParkingSlots.heavyVehicle[index].Duration.TotalSeconds * 0.3;
                    Console.WriteLine("Amount to be paid: " + ParkingSlots.heavyVehicle[index].Amount+" Rupees");
                    ParkingSlots.heavyVehicle[index] = null;

                }
            }
        }
        public void DisplayAllSlots(int twoWheeler, int fourWheeler, int heavyVehicle)
        {
            int twoWheelerSlotsOccupaid = ParkingSlots.twoWheeler.Count(s => s != null);
            int twoWheelerSlotsAvailable = twoWheeler - twoWheelerSlotsOccupaid;
            Console.WriteLine("Two Wheeler Slots Available: "+twoWheelerSlotsAvailable);
            int fourWheelerSlotsOccupaid = ParkingSlots.fourWheeler.Count(s => s != null);
            int fourWheelerSlotsAvailable = fourWheeler - fourWheelerSlotsOccupaid;
            Console.WriteLine("Four Wheeler Slots Available: "+fourWheelerSlotsAvailable);
            int heavyVehicleSlotsOccupaid = ParkingSlots.heavyVehicle.Count(s => s != null);
            int heavyVehicleSlotsAvailable = heavyVehicle - heavyVehicleSlotsOccupaid;
            Console.WriteLine("Heavy Vehicle Slots Available: "+heavyVehicleSlotsAvailable);
        }

    }
}

    