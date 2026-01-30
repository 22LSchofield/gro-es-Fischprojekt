using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ein_großer_fisch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter height of tank(m):");
            double Tank_height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter width of tank(m):");
            double Tank_width = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter depth of tank(m):");
            double Tank_depth = Convert.ToDouble(Console.ReadLine());

            double Tank_volume = Building_The_Tank_Volume(Tank_height, Tank_width, Tank_depth);
            Console.WriteLine("Volume of tank(m³)=" + Tank_volume);

            double Water_volume_metres = Building_The_Tank_Volume_Water(Tank_volume);// vol of water in m^3
            double Water_volume_litres = Water_volume_metres * 1000; // vol of water in litres
            Console.WriteLine("Recommended volume of water(m³)=" + Water_volume_metres);
            Console.WriteLine("Recommended volume of water(l)=" + Water_volume_litres);
        }

        static double Building_The_Tank_Volume(double height, double width, double depth) // calculates vol of tank
        {
            double volume = height * width * depth;
            return volume;
        }
        static double Building_The_Tank_Volume_Water(double TankVolume) // calculates amount of water that can go in tank
        {
            double Water_volume = TankVolume * 0.8; // vol of water in m^3
            return Water_volume;
        }
        static void Building_The_Tank_Volume_Glass_Thickness()// calculates thickness of glass
        {

        }
    }
}

