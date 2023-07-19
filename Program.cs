using System;
using System.IO;

namespace cars
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "", name = "", color = "";
            int price = 0;
            string Path = "Id_text.txt";

            int id = Cars.Id;



            do
            {

                try
                {
                    Cars.Id = Id_Read(Path);
                }
                catch (Exception)
                {
                    Cars.Id = 0;

                }
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("****************Menu Of Cars*************************");
                Console.WriteLine("1-add Car To M \n2-add Car to L \n3-Add Cars To H\n4-show Car from M \n5-show Car from L \n6-show Car from H\n7.search by Id");
                Console.WriteLine("Enter Nummer of Choice From Menu: ");
                string input = Console.ReadLine();
                int ch;
                bool success = int.TryParse(input, out ch);


                Console.Clear();
                if (success)
                {
                    if (ch == 1 | ch == 2 | ch == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter Name Of Cars");
                        name = Console.ReadLine();

                        Console.WriteLine("Enter Color Of Cars");
                        color = Console.ReadLine();


                        id = Cars.Id;
                        Console.WriteLine("Enter Price Of Cars");
                        do
                        {

                            string input_price = Console.ReadLine();
                            bool price_bool = int.TryParse(input_price, out price);

                            if (price_bool)
                            {
                                break;
                            }
                            Console.WriteLine("Enter nummber for Price.....");
                            Console.WriteLine("Enter Price Of Cars : ");
                        } while (true);
                        Console.Clear();
                    }
                    switch (ch)
                    {
                        case 1:
                            M m = new M();
                            Cars.Id++;
                            Service_Class.installized(m, name, Cars.Id, price, color);


                            break;
                        case 2:
                            L l = new L();
                            Cars.Id++;
                            Service_Class.installized(l, name, Cars.Id, price, color);
                            break;
                        case 3:
                            H h = new H();
                            Cars.Id++;
                            Service_Class.installized(h, name, Cars.Id, price, color);
                            Console.WriteLine("Done");
                            break;
                        case 4:
                            M mm = new M();
                            Ergebnisse(mm);
                            break;
                        case 5:
                            L ll = new L();
                            String[] arr1 = Service_Class.Show_Resault(ll);
                            Ergebnisse(ll);
                            break;
                        case 6:
                            H hh = new H();
                            Ergebnisse(hh);
                            break;
                        case 7:
                            do
                            {
                                int new_id;
                                if (Cars.Id <= 0)
                                {
                                    Console.WriteLine(" There is no Car");
                                    break;
                                }

                                   

                                    Console.WriteLine("Enter nummber between 1 and " + Cars.Id + " or x to exit");
                                string id_tosearch = Console.ReadLine();
                                bool tester_bool = int.TryParse(id_tosearch, out new_id);
                                if (id_tosearch == "x".ToLower())
                                {
                                    break;
                                }
                                if (new_id > Cars.Id || new_id < 0)
                                {
                                    Console.WriteLine("Enter nummber between 0 and " + Cars.Id + " or x to exit");
                                    continue;
                                }
                                Cars[] cars = new Cars[3];

                                cars[0] = new H();
                                cars[1] = new M();
                                cars[2] = new L();

                                string[][] Conterner = new string[3][];


                                for (int i = 0; i < cars.Length; i++)
                                {
                                    Conterner[i] = Service_Class.Show_Resault(cars[i]);
                                    search(Conterner[i], new_id);
                                    //Cars.Id = id;

                                }
                                break;

                            } while (true);
                            break;

                        default:
                            Console.WriteLine("error................");
                            break;
                    }


                    Console.WriteLine("\nTo show menu enter y or x to exit ");
                    s = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number. Press Enter To Continue");
                    Console.ReadLine();



                }
                if (s == "x")
                {
                    Id_Write(Path);
                    break;
                }
                Id_Write(Path);
            } while (true);
            static void search(String[] s, int eingaben)

            {
                if (s == null) { return; }
               
                foreach (var item in s)
                {
                    if (item.Contains(eingaben.ToString() + "-"))
                    { Console.WriteLine(item); }
                    else { continue; }
                }

                
                
                Console.WriteLine();

                 }
            static void Ergebnisse(Cars mm)

            {
                int count = 0;
                String[] Title = { "Id : ", "Car : ", "Color: ", "Price: ", "" };

                String[] arr = Service_Class.Show_Resault(mm);
                Console.WriteLine("**************Die Ergebnisse************");
                if(arr == null) { 

                    Console.WriteLine("There is no Car");
                    return;
                
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    String[] ss = arr[i].Split(" ");

                    for (int j = 0; j < ss.Length; j++)
                    {
                        Console.Write(Title[count] + ss[j] + " ");
                        count++;
                        if (count > 4)
                        {
                            count = 0;

                            Console.WriteLine("\n**************************");
                        }
                        Console.WriteLine();

                    }

                }

            }

            
        }

        private static void Id_Write(string idtext)
        {
            if (File.Exists(idtext))
            {
                using (StreamWriter writer = new StreamWriter(idtext))
                {

                    writer.Write(string.Empty);
                    writer.WriteLine(Cars.Id);

                }

            }
            else
            {
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(idtext, false);

                    // Schreibe den Inhalt in die Datei
                    writer.WriteLine(Cars.Id);



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
        private static int Id_Read(string Path)
        {

             if  (!File.Exists(Path)) { return 0;  }

           
                using (StreamReader reader = new StreamReader(Path))
                {
                    int last_ID;
                    try
                    {
                        last_ID = int.Parse(reader.ReadLine());

                    }
                 
                    finally { reader?.Close(); }

                    return last_ID;
                }
                

            
            
        }
    }
}
