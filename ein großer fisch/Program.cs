using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

/*
Autor: Lewis Schofield
Datum: 2026-30-1
Zweck: Gestaltung und Bestückung eines Aquariums.

Gehen Sie detaillierter vor: Berechnen Sie die Größe des Aquariums, sein Wasservolumen und die Kosten für das Glas.
Ermitteln Sie die Kosten für die Ausrüstung und wählen Sie die passenden Fische aus. 
Bestimmen Sie die optimale Anzahl jeder Fischart, damit sich die Fische im Aquarium wohlfühlen und gesund bleiben.
*/


namespace ein_großer_fisch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Building_The_Tank();    
        }
        static void Building_The_Tank() // executes all functions to build the tank 
        {
            // Input tank dimensions
            Console.Write("Enter height of tank(cm):");
            double Tank_height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter width of tank(cm):");
            double Tank_width = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter depth of tank(cm):");
            double Tank_depth = Convert.ToDouble(Console.ReadLine());

            // Calculate tank volume
            double Tank_volume = Building_The_Tank_Volume(Tank_height, Tank_width, Tank_depth);
            Console.WriteLine("Volume of tank(m³)=" + Tank_volume);

            // Calculate water volume
            double Water_volume_metres = Building_The_Tank_Volume_Water_M(Tank_volume);// vol of water in m³
            double Water_volume_litres = Building_The_Tank_Volume_Water_L(Water_volume_metres);// vol of water in litres
            Console.WriteLine("Recommended volume of water(m³)=" + Water_volume_metres);
            Console.WriteLine("Recommended volume of water(l)=" + Water_volume_litres);

            // Calculate glass thickness
            int glass_thickness = Building_The_Tank_Glass_Thickness(Water_volume_litres);
            Console.WriteLine("Glass thickness(cm)=" + glass_thickness);

            //calculate glass area (cm²)
            double glass_area_front_and_back = Building_The_Tank_Glass_Area_Front_And_Back(Tank_height, Tank_width);
            double glass_area_sides = Building_The_Tank_Glass_Area_Sides(Tank_height, Tank_depth, glass_thickness);
            double glass_area_base = Building_The_Tank_Glass_Area_Base(Tank_width, Tank_depth, glass_thickness);

            double total_glass_area = Building_The_Tank_Glass_Area_Sum(glass_area_front_and_back, glass_area_sides, glass_area_base);
            Console.WriteLine("Total glass area(cm²)=" + total_glass_area);

            // Calculate glass volume (cm³)
            double glass_volume = Building_The_Tank_Glass_Volume(total_glass_area, glass_thickness);
            Console.WriteLine("Total glass volume(cm³)=" + glass_volume);

            // Calculate glass cost (pence)
            double glass_cost = Building_The_Tank_Glass_Cost(glass_volume);
            Console.WriteLine("Total glass cost=" + glass_cost + "p");
        }
        static double Building_The_Tank_Volume(double height, double width, double depth) // calculates vol of tank
        {
            double volume = (height * width * depth)/ 1000000;
            return volume;
        }
        static double Building_The_Tank_Volume_Water_M(double TankVolume) // calculates amount of water that can go in tank (m³)
        {
            double Water_volume = TankVolume * 0.8; // vol of water in m^3
            return Water_volume;
        }
        static double Building_The_Tank_Volume_Water_L(double waterVolume) // calculates amount of water that can go in tank (l)
        {
            double Watervolume_l = waterVolume * 1000;
            return Watervolume_l;
        }
        static int Building_The_Tank_Glass_Thickness(double water_vol)// calculates thickness of glass
        {
            int power = Math.Floor(water_vol / 250) - 1;
            int thickness = Math.Pow(2,power); //cm
        }

        static double Building_The_Tank_Glass_Area_Front_And_Back(double height, double width,)// calculates  area of glass front and back
        {         
            double area_front = 2 * (height * width);
            return area_front;
        }
        static double Building_The_Tank_Glass_Area_Sides(double height, double depth,int thickness)// calculates  area of glass sides
        {
            double area_sides = 2 * (depth+ thickness * 2) * height);
            return area_sides;
        }
        static double Building_The_Tank_Glass_Area_Base(double width, double depth, int thickness)// calculates  area of glass bottom
        {         
            double base_area = (width + thickness * 2) * (depth + thickness * 2);
            return base_area;
        }
        static double Building_The_Tank_Glass_Area_Sum(double front, double side, double bottom)// calculates total area of glass
        {
            double total_area = front + side + bottom;
            return total_area;
        }
        static double Building_The_Tank_Glass_Volume(double area, int thickness)// calculates volume of glass (cm³)
        {
            double glass_volume = area * thickness;
            return glass_volume;
        }
        static double Building_The_Tank_Glass_Cost(double volume_ofglass)// calculates cost of glass (pence)
        {
           double cost = volume_ofglass * 1.2;
           return cost;
        }
    }
}

