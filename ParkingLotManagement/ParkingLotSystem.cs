using System;
using System.Linq;
namespace ParkingLotManagement
{
    public class ParkingLotSystem
    {
        public static List<string> vehicleNumbers = new List<string>();
        public void AddVehicle(Constant.VehicleType vehicleType)
        {
            Ticket ticketOfVehicle = new();
            Ticket[]? newTicket;
            
            Console.WriteLine("You have selected " + vehicleType + " to park.");
            if (vehicleType == (Constant.VehicleType.TwoWheeler)){
                newTicket = ParkingSlots.twoWheelerTickets;
            }
            else if (vehicleType == (Constant.VehicleType.FourWheeler))
            {
                newTicket  = ParkingSlots.fourWheelerTickets;
            }
            else 
            {
                newTicket  = ParkingSlots.heavyVehicleTickets;
            }
            if (newTicket!.Contains(null))
            {
                var indexNumber = newTicket!.Length;
                for (int i = 0; i < indexNumber; i++)
                {
                    if (newTicket[i] == null)
                    {
                        indexNumber = i;
                        
                        break;
                    }
                }

                if (indexNumber != newTicket.Length)
                {
                    ParkingLotSystem vehicleToPark = new();
                    ticketOfVehicle.TokenNumber = Ticket.TicketId;
                    Ticket.TicketId += 1;
                enterVehicleNumber:
                    Console.WriteLine("Enter vehicle number: ");
                    try
                    {
                        ticketOfVehicle.vehicle.VehicleNumber = Console.ReadLine()!;
                        if (vehicleNumbers.Contains(ticketOfVehicle.vehicle.VehicleNumber))
                        {
                            Console.WriteLine("Vehicle number already exist");
                            goto enterVehicleNumber;
                        }
                        if (ticketOfVehicle.vehicle.VehicleNumber == "")
                        {
                            Console.WriteLine("Enter valid Vehicle Number");
                            goto enterVehicleNumber;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter valid Vehicle number");
                        goto enterVehicleNumber;
                    }

                    if (vehicleType == (Constant.VehicleType.TwoWheeler))
                    {
                        ParkingSlots.twoWheelerTickets![indexNumber] = ticketOfVehicle;
                
                    }

                    else if (vehicleType == (Constant.VehicleType.FourWheeler))
                    {
                        ParkingSlots.fourWheelerTickets![indexNumber] = ticketOfVehicle;
                        

                    }
                    else
                    {
                        ParkingSlots.heavyVehicleTickets![indexNumber] = ticketOfVehicle;
                        
                    }
                    vehicleNumbers.Add(ticketOfVehicle.vehicle.VehicleNumber);
                    ticketOfVehicle.vehicle.VehicleType = vehicleType;
                    Console.WriteLine("Your vehicle Type is: "+ticketOfVehicle.vehicle.VehicleType);
                    Console.WriteLine("Your vehicle number is: " + ticketOfVehicle.vehicle.VehicleNumber);
                    ticketOfVehicle.InTime = DateTime.Now;
                    Console.WriteLine("Your vehicle In Time is: " + ticketOfVehicle.InTime);
                    Console.WriteLine("Your Vehicle Token Number is:" + ticketOfVehicle.TokenNumber);
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
        public void UnParkVehicle(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots,Constant.VehicleType vehicleType)
        {
            Ticket ticketOfVehicle;
            Ticket[]? unParkingVehicleTicket;
            int vehicleSlotsAvailability;
            Console.WriteLine("You have selected "+vehicleType +" to unpark.");
            if (vehicleType == (Constant.VehicleType.TwoWheeler))
            {
                unParkingVehicleTicket = ParkingSlots.twoWheelerTickets;
                vehicleSlotsAvailability = twoWheelerSlots;
            }
            else if (vehicleType == (Constant.VehicleType.FourWheeler))
            {
                unParkingVehicleTicket = ParkingSlots.fourWheelerTickets;
                vehicleSlotsAvailability = fourWheelerSlots;
            }
            else
            {
                unParkingVehicleTicket = ParkingSlots.heavyVehicleTickets;
                vehicleSlotsAvailability = heavyVehicleSlots;
            }
            int slotsOccupaid = unParkingVehicleTicket!.Count(s => s != null);
            int slotsAvailable = vehicleSlotsAvailability - slotsOccupaid;
            if (slotsAvailable == vehicleSlotsAvailability)
            {
                Console.WriteLine("No vehicles to unpark");
            }
            else
            {
            enterTokenIdNumber:
                Console.WriteLine("Enter Token Number :");
                int vehicleTokenId;

                try
                {
                    vehicleTokenId = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid Token number");
                    goto enterTokenIdNumber;
                }
                var index = unParkingVehicleTicket!.Length;
                bool isVehicleExist = false;                
                for (int i = 0; i < index; i++)
                {

                    if (unParkingVehicleTicket[i]!=null && unParkingVehicleTicket[i].TokenNumber== vehicleTokenId)
                    {
                        isVehicleExist = true;

                        index = i;

                        break;
                    }
                }

                if (isVehicleExist == true)
                {
                    ticketOfVehicle = unParkingVehicleTicket[index];
                    ticketOfVehicle.OutTime = DateTime.Now;
                    Console.WriteLine("Vehicle In Time: " + ticketOfVehicle.InTime);
                    Console.WriteLine("Vehicle out time: " + ticketOfVehicle.OutTime);
                    ticketOfVehicle.Duration = ticketOfVehicle.OutTime.Subtract(ticketOfVehicle.InTime);
                    Console.WriteLine("Toatal duration of the vehicle: " + ticketOfVehicle.Duration);
                    ticketOfVehicle.Amount = Math.Round(ticketOfVehicle.Duration.TotalSeconds * 0.1,2); ;
                    Console.WriteLine("Amount to be paid: " + ticketOfVehicle.Amount + " Rupees");
                    if (vehicleType == (Constant.VehicleType.TwoWheeler))
                    {
                        ParkingSlots.twoWheelerTickets![index] = null!;
                    }
                    else if(vehicleType ==(Constant.VehicleType.FourWheeler))
                    {
                        ParkingSlots.fourWheelerTickets![index] = null!;
                    }
                    else
                    {
                        ParkingSlots.heavyVehicleTickets![index] = null!;

                    }
                }
                else
                {
                    Console.WriteLine("Vehicle not available with that Token Number");
                }
            }

        }
        public void DisplayAllSlots(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
        {
            int twoWheelerSlotsOccupaid = ParkingSlots.twoWheelerTickets!.Count(s => s != null);
            int twoWheelerSlotsAvailable = twoWheelerSlots - twoWheelerSlotsOccupaid;
            Console.WriteLine("Two Wheeler Slots Available: "+twoWheelerSlotsAvailable);
            int fourWheelerSlotsOccupaid = ParkingSlots.fourWheelerTickets!.Count(s => s != null);
            int fourWheelerSlotsAvailable = fourWheelerSlots - fourWheelerSlotsOccupaid;
            Console.WriteLine("Four Wheeler Slots Available: "+fourWheelerSlotsAvailable);
            int heavyVehicleSlotsOccupaid = ParkingSlots.heavyVehicleTickets!.Count(s => s != null);
            int heavyVehicleSlotsAvailable = heavyVehicleSlots - heavyVehicleSlotsOccupaid;
            Console.WriteLine("Heavy Vehicle Slots Available: "+heavyVehicleSlotsAvailable);
        }
        public void IsVehicleAlreadyExist()
        {

        }

    }
}

    