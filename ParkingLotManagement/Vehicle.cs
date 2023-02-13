using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ParkingLotManagement
{
    public class Vehicle
    {
        Ticket ticket=new Ticket();
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public void AddVehicle(string slots)
        {
            Vehicle[] newVehicle;
            if (slots == "twoWheeler"){
                newVehicle = ParkingSlots.twoWheeler;
            }
            else if (slots == "fourWheeler")
            {
                newVehicle  = ParkingSlots.fourWheeler;
            }
            else
            {
                newVehicle  = ParkingSlots.heavyVehicle;
            }
            if (newVehicle.Contains(null))
            {
                var indexNumber = newVehicle.Length;
                for (int i = 0; i < newVehicle.Length; i++)
                {
                    if (newVehicle[i] == null)
                    {
                        indexNumber = i;
                        
                        break;
                    }
                }

                if (indexNumber != newVehicle.Length)
                {
                    Vehicle vehicleToPark = new Vehicle();
                    vehicleToPark.ticket.TokenNumber = Ticket.TicketId;
                    Ticket.TicketId += 1;
                enterTwoWheelerVehicleNumber:


                    Console.WriteLine("Enter vehicle number: ");

                    try
                    {
                        vehicleToPark.VehicleNumber = Console.ReadLine();
                        if (vehicleToPark.VehicleNumber == "")
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
                    vehicleToPark.ticket.InTime = DateTime.Now;
                    if (slots == "twoWheeler")
                    {
                        ParkingSlots.twoWheeler[indexNumber] = vehicleToPark;
                
                    }

                    else if (slots == "fourWheeler")
                    {
                        ParkingSlots.fourWheeler[indexNumber] = vehicleToPark;
                        

                    }
                    else
                    {
                        ParkingSlots.heavyVehicle[indexNumber] = vehicleToPark;
                        
                    }
                    vehicleToPark.VehicleType = slots;
                    Console.WriteLine("Your vehicle Type is: "+vehicleToPark.VehicleType);
                    Console.WriteLine("Your vehicle number is: " + vehicleToPark.VehicleNumber);
                    Console.WriteLine("Your vehicle In Time is: " + vehicleToPark.ticket.InTime);
                    Console.WriteLine("Your Vehicle Token Number is:" + vehicleToPark.ticket.TokenNumber);
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
        public void UnParkVehicle(int twoWheeler, int fourWheeler, int heavyVehicle,string slots)
        {
            Vehicle[] newVehicle;

            Console.WriteLine(slots);
            if (slots == "twoWheeler")
            {
                newVehicle = ParkingSlots.twoWheeler;
            }
            else if (slots == "fourWheeler")
            {
                newVehicle = ParkingSlots.fourWheeler;
            }
            else
            {
                newVehicle = ParkingSlots.heavyVehicle;
            }
            int slotsOccupaid = newVehicle.Count(s => s != null);
            int slotsAvailable = twoWheeler - slotsOccupaid;
            if (slotsAvailable == twoWheeler)
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
                var index = newVehicle.Length;
                bool isVehicleExist = false;
                for (int i = 0; i < newVehicle.Length; i++)
                {

                    if (newVehicle[i].ticket.TokenNumber == vehicleTokenId)
                    {
                        isVehicleExist = true;
                        Console.WriteLine(newVehicle[i].VehicleNumber);

                        index = i;

                        break;
                    }

                }

                if (isVehicleExist == true)
                {
                    Console.WriteLine("Your Vehicle Type is: "+newVehicle[index].VehicleType);
                    Console.WriteLine("Your Vehicle number: "+ newVehicle[index].VehicleNumber);
                    newVehicle[index].ticket.OutTime = DateTime.Now;
                    Console.WriteLine("Vehicle In Time: " + newVehicle[index].ticket.InTime);
                    Console.WriteLine("Vehicle out time: " + newVehicle[index].ticket.OutTime);
                    newVehicle[index].ticket.Duration = newVehicle[index].ticket.OutTime.Subtract(newVehicle[index].ticket.InTime);
                    Console.WriteLine("Toatal duration of the vehicle: " + newVehicle[index].ticket.Duration);
                    newVehicle[index].ticket.Amount = newVehicle[index].ticket.Duration.TotalSeconds * 0.1; ;
                    Console.WriteLine("Amount to be paid: " + newVehicle[index].ticket.Amount + " Rupees");
                    if (slots == "twoWheeler")
                    {
                        ParkingSlots.twoWheeler[index] = null;
                    }
                    else if(slots=="fourWheeler")
                    {
                        ParkingSlots.fourWheeler[index] = null;
                    }
                    else
                    {
                        ParkingSlots.heavyVehicle[index] = null;

                    }
                }
                else
                {
                    Console.WriteLine("Vehicle not available");
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

    