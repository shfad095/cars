using System;

using System.IO;



namespace cars
{
    public static  class Service_Class
    {
       public static void installized(Cars car, String name1, int id1, int price1, String color1)
        {

            car.Name = name1;

            car.Price = price1;
            car.Color = color1;
            Add_data(car);
            Console.WriteLine("Done");

        }
        public static void Add_data(Cars car)
        {
            string textname = car.GetType().Name;
            textname += ".txt";

            if (File.Exists(textname))
            {
                using (StreamWriter writer = new StreamWriter(textname, true))
                {
                    writetofile(writer,car);

                }

            }
            else
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(textname, false);

                    writetofile(writer,car);



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

        private static void writetofile(StreamWriter writer,Cars car)
        {
            writer.Write(Cars.Id + "-" + " " + car.Name + " " + car.Color + " " + car.Price + " " + "*");
        }
        public static  String[] Show_Resault(Cars car)
        {
            string textname = car.GetType().Name;
            textname += ".txt";
            if (!File.Exists(textname)) { return null; }
            try
            {
                String d = File.ReadAllText(textname);
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
