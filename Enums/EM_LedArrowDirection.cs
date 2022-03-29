using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParking.Enums
{
    public class LedArrowDirection
    {
        public static byte GetLedArrowDirection(EM_LedArrowDirection ledArrowDirection)
        {
            switch (ledArrowDirection)
            {
                case EM_LedArrowDirection.RIGHT_SIDE_and_LEFT_TO_RIGHT:
                    return 0x30;
                case EM_LedArrowDirection.RIGHT_SIDE_and_RIGHT_TO_LEFT:
                    return 0x31;
                case EM_LedArrowDirection.RIGHT_SIDE_and_BOTTOM_TO_TOP:
                    return 0x32;
                case EM_LedArrowDirection.RIGHT_SIDE_and_TOP_TO_BOTTOM:
                    return 0x33;
                case EM_LedArrowDirection.LEFT_SIDE_and_LEFT_TO_RIGHT:
                    return 0x34;
                case EM_LedArrowDirection.LEFT_SIDE_and_RIGHT_TO_LEFT:
                    return 0x35;
                case EM_LedArrowDirection.LEFT_SIDE_and_BOTTOM_TO_TOP:
                    return 0x36;
                case EM_LedArrowDirection.LEFT_SIDE_and_TOP_TO_BOTTOM:
                    return 0x37;
                default:
                    return 0x00;
            }
        }
        public static EM_LedArrowDirection GetLedArrowDirection(byte ledArrowDirection)
        {
            switch (ledArrowDirection)
            {
                case 0x30:
                    return EM_LedArrowDirection.RIGHT_SIDE_and_LEFT_TO_RIGHT;
                case 0x31:
                    return EM_LedArrowDirection.RIGHT_SIDE_and_RIGHT_TO_LEFT;
                case 0x32:
                    return EM_LedArrowDirection.RIGHT_SIDE_and_BOTTOM_TO_TOP;
                case 0x33:
                    return EM_LedArrowDirection.RIGHT_SIDE_and_TOP_TO_BOTTOM;
                case 0x34:
                    return EM_LedArrowDirection.LEFT_SIDE_and_LEFT_TO_RIGHT;
                case 0x35:
                    return EM_LedArrowDirection.LEFT_SIDE_and_RIGHT_TO_LEFT;
                case 0x36:
                    return EM_LedArrowDirection.LEFT_SIDE_and_BOTTOM_TO_TOP;
                case 0x37:
                    return EM_LedArrowDirection.LEFT_SIDE_and_TOP_TO_BOTTOM;
                default:
                    return EM_LedArrowDirection.UNKNOWN;
            }
        }
        public static string GetLedArrowName(byte ledArrow)
        {
            return Enum.GetName(typeof(EM_LedArrowDirection), GetLedArrowDirection(ledArrow));
        }
    }
    public enum EM_LedArrowDirection
    {
        RIGHT_SIDE_and_LEFT_TO_RIGHT,
        RIGHT_SIDE_and_RIGHT_TO_LEFT,
        RIGHT_SIDE_and_BOTTOM_TO_TOP,
        RIGHT_SIDE_and_TOP_TO_BOTTOM,

        LEFT_SIDE_and_LEFT_TO_RIGHT,
        LEFT_SIDE_and_RIGHT_TO_LEFT,
        LEFT_SIDE_and_BOTTOM_TO_TOP,
        LEFT_SIDE_and_TOP_TO_BOTTOM,

        UNKNOWN,
    }
}
