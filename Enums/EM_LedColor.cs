using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParking.Enums
{
    public class LedColor
    {
        public static byte GetLedColor(EM_LedColor ledColor)
        {
            switch (ledColor)
            {
                case EM_LedColor.RED:
                    return 0x30;
                case EM_LedColor.YELLOW:
                    return 0x31;
                case EM_LedColor.GREEN:
                    return 0x32;
                default:
                    return 0x00;
            }
        }
        public static EM_LedColor GetLedColor(byte ledColor)
        {
            switch (ledColor)
            {
                case 0x30:
                    return EM_LedColor.RED;
                case 0x31:
                    return EM_LedColor.YELLOW;
                case 0x32:
                    return EM_LedColor.GREEN;
                default:
                    return EM_LedColor.UNKNOWN;
            }
        }
        public static string GetLedColorName(byte ledColor)
        {
            return Enum.GetName(typeof(EM_LedColor), GetLedColor(ledColor));
        }
    }
    public enum EM_LedColor
    {
        RED,
        YELLOW,
        GREEN,
        UNKNOWN
    }
}
