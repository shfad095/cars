using System;
using System.IO;

namespace cars
{
    class M : Cars
    {    
        public string Name { get; set; }
        
        public string Color { get; set; }
        public double Price { get; set; }
        public M()
        {
           
        }
        public void Add_data()
        {
            File.AppendAllText("m.txt", Cars.Id+"-" + " " + Name + " " + Color + " " + Price + " "+"*");
            //throw new NotImplementedException();

        }
        public String[] Show_Resault()
        {
            String d = File.ReadAllText("m.txt");
            
            
            return d.Split("*");

        
        }

    }
}
