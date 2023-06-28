using System;


namespace cars
{
    interface Cars
    {
        string Name { set; get; }
        static int Id {set; get;}
        string Color { set; get; }
        double Price { set; get; }
        void Add_data();
        String[] Show_Resault();
        




    }
}
