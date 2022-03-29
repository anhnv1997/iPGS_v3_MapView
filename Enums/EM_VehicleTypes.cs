using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iParking.Enums
{
    public enum EM_VehicleTypes
    {
        Unknown = -1,
        BigTruckWithoutFee = 0,
        OtherVehicleWithoutFee = 1,
        VehicleWithFee = 2,
    }

    // Get Vehicle Types
    public class Define_VehicleType
    {
        public static EM_VehicleTypes GetType(string vehicleType)
        {
            return (EM_VehicleTypes)Enum.Parse(typeof(EM_VehicleTypes), vehicleType, true);
        }

        public static EM_VehicleTypes GetType(int index)
        {
            return (EM_VehicleTypes)index;
        }

        public static string GetString(EM_VehicleTypes vehicleType)
        {
            switch (vehicleType)
            {
                case EM_VehicleTypes.BigTruckWithoutFee:
                    {
                        return "Xe tải lớn - miễn phí";
                    }
                case EM_VehicleTypes.OtherVehicleWithoutFee:
                    {
                        return "Xe khác - miễn phí";
                    }
                case EM_VehicleTypes.VehicleWithFee:
                    {
                        return "Xe tính phí";
                    }
                default:
                    return "";
            }
        }

        public static string GetString(string vehicleTypeString)
        {
            switch (vehicleTypeString)
            {
                case "Bicycle":
                    {
                        return "Xe đạp";
                    }
                case "Moto":
                    {
                        return "Xe máy";
                    }
                case "Car":
                    {
                        return "Ô tô";
                    }
                case "ElectricBike":
                    {
                        return "Xe đạp điện";
                    }
                case "Walk":
                    {
                        return "Đi bộ";
                    }
                default:
                    return "";
            }
        }

        public static EM_VehicleTypes GetVehicleType(string vehicleString)
        {
            switch (vehicleString)
            {
                case "Xe tải lớn - miễn phí":
                    {
                        return EM_VehicleTypes.BigTruckWithoutFee;
                    }
                case "Xe khác - miễn phí":
                    {
                        return EM_VehicleTypes.OtherVehicleWithoutFee;
                    }
                case "Xe tính phí":
                    {
                        return EM_VehicleTypes.VehicleWithFee;
                    }
                default:
                    return EM_VehicleTypes.Unknown;
            }
        }
    }
}
