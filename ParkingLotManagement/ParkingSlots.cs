using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingSlots
    {
        public enum VehicleType
        {
            TwoWheeler=1,FourWheeler,HeavyVehicle
        }
        public static Vehicle[] twoWheeler;
        public static Vehicle[] fourWheeler;
        public static Vehicle[] heavyVehicle;
        public void SlotInitialization(int twoWheelerSlots, int fourWeelerSlots, int heavyVehicleSlots)
        {
            twoWheeler = new Vehicle[twoWheelerSlots];
            fourWheeler = new Vehicle[fourWeelerSlots];
            heavyVehicle = new Vehicle[heavyVehicleSlots];
        }
    }
}
