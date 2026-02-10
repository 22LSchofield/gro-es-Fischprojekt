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
        static void set_font_white()// sets text to white
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void set_font_blue()// sets text to blue
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        static void set_font_purple()// sets text to purple
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
        static void set_font_orange()// sets text to orange
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan; //blue for fish tank
            Building_The_Tank();
            Console.ForegroundColor = ConsoleColor.DarkMagenta; // purple for choosing fish

            Console.ForegroundColor = ConsoleColor.DarkYellow; // orange for
        }
        static void Building_The_Tank() // executes all functions to build the tank 
        {
            // Input tank dimensions
            Console.Write("Enter height of tank(cm):");
            set_font_white();
            double Tank_height = Convert.ToDouble(Console.ReadLine());
            set_font_blue();
            Console.Write("Enter width of tank(cm):");
            set_font_white();
            double Tank_width = Convert.ToDouble(Console.ReadLine());
            set_font_blue();
            Console.Write("Enter depth of tank(cm):");
            set_font_white();
            double Tank_depth = Convert.ToDouble(Console.ReadLine());
            set_font_blue();
            // Calculate tank volume
            double Tank_volume = Building_The_Tank_Volume(Tank_height, Tank_width, Tank_depth);
            Console.Write("Volume of tank(m³)= ");
            set_font_white();
            Console.WriteLine(Tank_volume);
            set_font_blue();
            // Calculate water volume
            double Water_volume_metres = Building_The_Tank_Volume_Water_M(Tank_volume);// vol of water in m³
            double Water_volume_litres = Building_The_Tank_Volume_Water_L(Water_volume_metres);// vol of water in litres
            Console.Write("Recommended volume of water(m³)= ");
            set_font_white();
            Console.WriteLine(Water_volume_metres);
            set_font_blue();
            Console.Write("Recommended volume of water(l)= ");
            set_font_white();
            Console.WriteLine(Water_volume_litres);
            set_font_blue();

            // Calculate glass thickness
            double glass_thickness = Building_The_Tank_Glass_Thickness(Water_volume_litres);
            Console.Write("Glass thickness(cm)= ");
            set_font_white();
            Console.WriteLine(glass_thickness);
            set_font_blue();

            //calculate glass area (cm²)
            double glass_area_front_and_back = Building_The_Tank_Glass_Area_Front_And_Back(Tank_height, Tank_width);
            double glass_area_sides = Building_The_Tank_Glass_Area_Sides(Tank_height, Tank_depth, glass_thickness);
            double glass_area_base = Building_The_Tank_Glass_Area_Base(Tank_width, Tank_depth, glass_thickness);

            double total_glass_area = Building_The_Tank_Glass_Area_Sum(glass_area_front_and_back, glass_area_sides, glass_area_base);
            Console.Write("Total glass area(cm²)= ");
            set_font_white();
            Console.WriteLine(total_glass_area);
            set_font_blue();

            // Calculate glass volume (cm³)
            double glass_volume = Building_The_Tank_Glass_Volume(total_glass_area, glass_thickness);
            Console.Write("Total glass volume(cm³)= ");
            set_font_white();
            Console.WriteLine(glass_volume);
            set_font_blue();

            // Calculate glass cost (pence)
            double glass_cost_pence = Building_The_Tank_Glass_Cost_Pence(glass_volume);
            Console.Write("Total glass cost= ");
            set_font_white();
            Console.Write(glass_cost_pence);
            Console.WriteLine("p");
            set_font_blue();

            // Calculate glass cost (pounds)
            double glass_cost_pounds = Building_The_Tank_Glass_Cost_Pounds(glass_cost_pence);
            Console.Write("Total glass cost= £");
            set_font_white();
            Console.WriteLine(glass_cost_pounds);
            set_font_blue();
        }
        static double Building_The_Tank_Volume(double height, double width, double depth) // calculates vol of tank
        {
            double volume = (height * width * depth) / 1000000;
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
        static double Building_The_Tank_Glass_Thickness(double water_vol)// calculates thickness of glass
        {
            double power = Math.Floor(water_vol / 250) - 1;
            double thickness = Math.Pow(2, power); //cm
            if (thickness < 1)
            {
                thickness = 1;
            }
            return thickness;
        }
        static double Building_The_Tank_Glass_Area_Front_And_Back(double height, double width)// calculates  area of glass front and back
        {
            double area_front = 2 * (height * width);
            return area_front;
        }
        static double Building_The_Tank_Glass_Area_Sides(double height, double depth, double thickness)// calculates  area of glass sides
        {
            double area_sides = 2 * ((depth + thickness * 2) * height);
            return area_sides;
        }
        static double Building_The_Tank_Glass_Area_Base(double width, double depth, double thickness)// calculates  area of glass bottom
        {
            double base_area = (width + thickness * 2) * (depth + thickness * 2);
            return base_area;
        }
        static double Building_The_Tank_Glass_Area_Sum(double front, double side, double bottom)// calculates total area of glass
        {
            double total_area = front + side + bottom;
            return total_area;
        }
        static double Building_The_Tank_Glass_Volume(double area, double thickness)// calculates volume of glass (cm³)
        {
            double glass_volume = area * thickness;
            return glass_volume;
        }
        static double Building_The_Tank_Glass_Cost_Pence(double volume_ofglass)// calculates cost of glass (pence)
        {
            double cost = volume_ofglass * 1.2;
            return cost;
        }
        static double Building_The_Tank_Glass_Cost_Pounds(double costpence)// calculates cost of glass (pounds)
        {
            double costpounds = costpence / 100;

            return costpounds;

        }

        static void Choosing_The_fish()
        {

        }

        static void Choosing_The_Fish_Fixed_Costs()
        {

        }

        static void Choosing_The_Fish_Species()
        {

        }

        struct Fish
        {
            public string name;
            public string waterType;
            public string colour;
            public string socialType;
            public bool iridescent;
            public double unitPrice;
            public string size;

            public Fish(string name, string watertype, string colour, string socialtype, bool iridescent, double unitprice, string size)
            {


            }
        }

        static Fish[] Choosing_The_Fish_shopList()
        {
            Fish[] aquarium = new Fish[]
            {
                new Fish("Neon Tetra", "Warm", "Colourful", "Shoaling", true, 1.50, "Small"),
                new Fish("Goldfish", "Cold", "Muted", "Solitary", false, 5.00, "Medium"),
                new Fish ("Guppy", "Warm", "Colourful", "Shoaling", true, 2.00, "Small"),
                new Fish("Betta", "Warm", "Colourful", "Solitary", true, 8.00, "Medium"),
                new Fish("White Cloud Mountain Minnow", "Cold", "Muted", "Shoaling", false, 1.80, "Small"),
                new Fish("Zebra Danio", "Warm", "Muted", "Shoaling", false, 1.20, "Small"),
                new Fish("Corydoras Catfish", "Warm", "Muted", "Shoaling", false, 3.00, "Medium"),
                new Fish("Angelfish", "Warm", "Colourful", "Shoaling", true, 10.00, "Large"),
                new Fish("Molly", "Cold", "Colourful", "Shoaling", true, 2.50, "Medium"),
                new Fish("Swordtail", "Cold", "Colourful", "Shoaling", true, 3.00, "Medium"),
                new Fish("Platy", "Warm", "Colourful", "Shoaling", true, 2.00, "Small"),
                new Fish("Cherry Barb", "Cold", "Colourful", "Shoaling", true, 1.80, "Small"),
                new Fish("Rainbowfish", "Cold", "Colourful", "Shoaling", true, 4.00, "Medium"),
                new Fish("Oscar", "Cold", "Colourful", "Solitary", true, 15.00, "Large"),
                new Fish("Discus", "Warm", "Colourful", "Shoaling", true, 20.00, "Large"),
                new Fish("Clownfish", "Warm", "Colourful", "Solitary", true, 12.00, "Medium"),
                new Fish("Rainbow Trout", "Cold", "Muted", "Solitary", false, 5.00, "Medium"),
                new Fish("Gourami", "Cold", "Colourful", "Shoaling", true, 4.00, "Medium")
            };
            return aquarium;



        }


    }
}