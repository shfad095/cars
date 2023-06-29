using System;
using System.IO;

namespace cars
{
    class L:Cars
    {
        public string Name { get; set; }
        
        public string Color { get; set; }
        public double Price { get; set; }
        public L()
        {
         
        }
        public void Add_data()
        {
            File.AppendAllText("l.txt",Cars.Id + "-" + " "+Name+" "+Color+" "+Price+" ");
        
        }
        public String[] Show_Resault()
        {
            String d = File.ReadAllText("l.txt");
            return d.Split("*");


        }
    }
}
