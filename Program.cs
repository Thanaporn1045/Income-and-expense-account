using System;

namespace รายรับรายจ่าย
{
    class Program
    { 
       
        static void Main(string[] args)
        {
            Newprogram();
        }
        static void Newprogram()
        {
            int year, daymonth; string x;
            year = Checkpositiveyear();
            daymonth = Checkmonth(year);
            In_and_ex(daymonth);
            do
            {
                Console.Write("Do you want to start a new program? : ");
                x = Console.ReadLine();
                if (x != "Yes" && x != "No") { Console.WriteLine("Please input Yes or No"); }
            } while (x != "Yes" && x != "No");
            
            if(x == "Yes") 
            {
                Console.WriteLine();
                Newprogram();
            }
        }

        static void In_and_ex(int daymonth)
        {
            int date=0; 
            double oldincome = 0, newincome, oldexpenses = 0, newexpenses, total = 0;
   
            do
            {
                do
                {
                    Console.Write("date : ");
                    date = int.Parse(Console.ReadLine());
                    if (date <= 0 || date > daymonth) 
                    { 
                        Console.WriteLine("Please enter a valid date.");
                        Console.WriteLine("");
                    }
                } while (date <= 0 || date > daymonth);
                do
                {
                    Console.Write("income : ");
                    newincome = double.Parse(Console.ReadLine());
                    Console.Write("expenses : ");
                    newexpenses = double.Parse(Console.ReadLine());
                    
                    if (newincome < 0 || newexpenses < 0) 
                    { Console.WriteLine("Please input positive number."); }

                    if (newexpenses > total + newincome)
                    {Console.WriteLine("You cannot have more expenses than total. Please input new income ");}
                    
                } while (newincome < 0 || newexpenses < 0|| newexpenses > total + newincome);
                
                total = total + newincome - newexpenses; 
                oldincome = oldincome + newincome;
                oldexpenses = oldexpenses + newexpenses;
                
                Console.WriteLine("Total : {0}", total);
                Console.WriteLine();

            } while (date != daymonth);
            Console.WriteLine("This month you have all income : {0} expenses : {1} total : {2}",oldincome,oldexpenses,total);
            Console.WriteLine();
        }

        static int Checkpositiveyear()
        {   
            int x;
            do
            {
                Console.Write("Year (AD) : ");
                x = int.Parse(Console.ReadLine());
                if (x <= 0) { Console.WriteLine("Please input positive number."); Console.WriteLine(); }
            } while (x <= 0);
            return x;
        }
        static int Checkmonth(int year)
        {
            string month; int day = 0;
            Console.Write("Month : ");
            month = Console.ReadLine();
            switch (month)
            {
                case "January" : day = 31; break;
                case "March" : day = 31; break;
                case "April" : day = 30; break;
                case "May": day = 31; break;
                case "June" : day = 30; break;
                case "July": day = 31; break;
                case "August" : day = 31; break;
                case "September" : day = 30; break;
                case "October" : day = 31; break;
                case "November" : day = 30; break;
                case "December" : day = 31; break;
                case "February" :
                if (year % 4 == 0)
                { day = 29; }
                else { day = 28; return day; } break;
                default : 
                Console.WriteLine("Please enter a valid month name.");
                Console.WriteLine();
                day = Checkmonth(year); break;
        }
            return day;
        }
    }
}
