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
            if (File.Exists("m.txt"))
            {
                using (StreamWriter writer = new StreamWriter("m.txt",true))
                {
                    writer.Write(Cars.Id + "-" + " " + this.Name + " " + this.Color + " " + this.Price + " "+"*");

                }

            }
            else
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter("m.txt", true);

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
            if (File.Exists("m.txt"))
            {

            try
            {
                String d = File.ReadAllText("m.txt");
                return d.Split("*");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
                
            }
            return null;

        }

    }
}
