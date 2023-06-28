using System;

namespace cars
{
    class Program
    {
        static void Main(string[] args)
        {
            String s, name = "", color = "";
            int id = Cars.Id, price = 0;

            do
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("****************Menu Of Cars*************************");
                Console.WriteLine("1-add Car To M \n2-add Car to L \n3-Add Cars To M\n4-show Car from M \n5-show Car from L \n6-show Car from M\n7.search by Id");
                Console.WriteLine("Enter Nummer of Choice From Menu: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
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
                    price = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                switch (ch)
                {
                    case 1:
                        M m = new M();
                        installized( m,name,id,price,color );
                      

                        break;
                    case 2:
                        L l = new L();
                        installized(l, name, id, price, color);
                        break;
                    case 3:
                        H h = new H();
                        installized(h, name, id, price, color);
                        Console.WriteLine("Done");
                        break;
                    case 4:
                        M mm = new M();
                        Ergebnisse(mm);
                        break;
                    case 5:
                        L ll = new L();
                        String[] arr1 = ll.Show_Resault();
                        Ergebnisse(ll);
                        break;
                    case 6:
                        H hh = new H();
                        Ergebnisse(hh);
                        break;
                    case 7:

                        
                        int new_id = int.Parse(Console.ReadLine());
                        Cars[] cars = new Cars[3];
                            
                        cars[0] = new H();
                        cars[1] = new M();
                        cars[2] = new L();
                       
                        string[][] Conterner = new string[3][];
                         

                        for (int i = 0; i < cars.Length; i++)
                        {
                            Conterner[i] = cars[1].Show_Resault();
                            search(Conterner[i], new_id);
                           
                        }
                        break;

                    default:
                        Console.WriteLine("error................");
                        break;
                }
                Console.WriteLine("\nTo show menu enter y");
                s = Console.ReadLine();
                



            } while (s == "y");
            static void search(String[] s, int eingaben)

            {

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].Contains(eingaben.ToString() + "-"))
                        Console.Write(s[i] + " " + s[i + 1] + " " + s[i + 2] + " " + s[i + 3]);
                }
                Console.WriteLine();

            }
            static void Ergebnisse(Cars mm)

            {
                int count = 0;
                String[] Title = { "Id : ", "Car : ", "Color: ", "Price: " ,""};

                String[] arr = mm.Show_Resault();
                Console.WriteLine("**************Die Ergebnisse************");
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

            static void installized(Cars car ,String name1, int id1, int price1, String color1)
            {

                car.Name = name1;
                
                car.Price = price1;
                car.Color = color1;
                car.Add_data();
                Console.WriteLine("Done");

            }
        }
    }
}
