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
            if (File.Exists("l.txt"))
            {
                using (StreamWriter writer = new StreamWriter("l.txt",true))
                {
                    writer.Write(Cars.Id + "-" + " " + this.Name + " " + this.Color + " " + this.Price + " " + "*");

                }

            }
            else
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter("l.txt");

                    writer.Write(Cars.Id + "-" + " " + this.Name + " " + this.Color + " " + this.Price + " " + "*");



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
            if (!File.Exists("l.txt")) { return null; }


            try
                {
                    String d = File.ReadAllText("l.txt");
                    return d.Split("*");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return null;
                }

            
           

        }
    }
}
