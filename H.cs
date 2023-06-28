using System;
using System.IO;
using System.Runtime.InteropServices;

namespace cars
{
    class H:Cars
    {
        public string Name { get; set; }
        
        public string Color { get; set; }
        public double Price { get; set; }
        public H()
        {
            Cars.Id++;
        }
        public void Add_data()
        {
            File.AppendAllText("h.txt", Cars.Id +"-" + " " + this.Name + " " + this.Color + " " + this.Price + " ");

        }
        public String[] Show_Resault()
        {
            String d = File.ReadAllText("h.txt");
            return d.Split("*");


        }
    }
}
