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
        
        }
        public void Add_data()
        {
            //using (StreamWriter writer = new StreamWriter("h.txt"))
            //{

            //    writer.Write(string.Empty);
            //    writer.WriteLine("h.txt", Cars.Id + "-" + " " + this.Name + " " + this.Color + " " + this.Price + " ");

            //}
            if (File.Exists("h.txt"))
            {
                using (StreamWriter writer = new StreamWriter("h.txt",true ))
                {
                    writer.Write(Cars.Id + "-" + " " + this.Name + " " + this.Color + " " + this.Price + " " + "*");

                }

            }
            else
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter("h.txt", false);

                    writer.Write(Cars.Id + "-" + " " + this.Name + " " + this.Color + " " + this.Price + " "+"*");



                }
                catch (IOException ex)
                {
                    Console.WriteLine("Fehler beim Erstellen der Datei: " + ex.Message);
                }
                finally
                {
                    writer?.Close();
                }
            }


        }
        public String[] Show_Resault()
        {
            if (!File.Exists("h.txt")) { return null; }
            try
            {
                String d = File.ReadAllText("h.txt");
                return d.Split("*");
            }
            catch (Exception e)
            {

                Console.WriteLine(  e.Message);
                return null;
            }
            


        }
    }
}
