using System;
using System.Collections.Generic;

namespace interview_question
{


    public class location
    {
        private DateTime date;
        private string name;
        private string route;
        private string bestRoute = "";
        //ints to store number of blocks from origin
        private int x = 0;
        private int y = 0;
        //char to store current facing direction
        private char direction = 'w';
        //some styling
        private string dots =  "\n*********************************************************\n" ;

        public location(DateTime inDate, string inName, string inRoute)
        {
            date = inDate;
            name = inName;
            route = inRoute;
            createBestPath();
        }

        public location(string inName, string inRoute)
        {
            date = DateTime.Today;
            name = inName;
            route = inRoute;
            createBestPath();
        }
                                                                    //method to create the most direct route
        private void createBestPath()
        {
            string[] moves = route.Split(',');

            foreach (var move in moves)
            {
                                                                    //cases for left and right movement 
                switch (move.Substring(1, 1))
                {
                    case "L":
                    case "l":
                        {                                           //cases for facing direction 
                                                                    //x and y represent x and y on a cartesian plane 
                            switch (direction)
                            {
                                case 'w':
                                    {
                                        x = x - Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 's';
                                        break;
                                    }
                                case 'n':
                                    {
                                        y = y + Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 'w';
                                        break;
                                    }
                                case 'e':
                                    {
                                        x = x + Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 'n';
                                        break;
                                    }
                                case 's':
                                    {
                                        y = y - Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 'e';
                                        break;
                                    }
                            }

                            break;
                        }
                    case "R":
                    case "r":
                        {                                               //cases for facing direction 
                            switch (direction)
                            {
                                case 'w':
                                    {
                                        x = x + Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 'n';
                                        break;
                                    }
                                case 'n':
                                    {
                                        y = y - Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 'e';
                                        break;
                                    }
                                case 'e':
                                    {
                                        x = x - Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 's';
                                        break;
                                    }
                                case 's':
                                    {
                                        y = y + Convert.ToInt32(move.Substring(2, move.Length - 2));
                                        direction = 'w';
                                        break;
                                    }
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"\ninvalid movement '{move.Substring(1, 1)}', skipping movment\n");
                            break;
                        }
                }
            }
            //best route string building
            // -x = left -y = down x = right y = up
            if (x < 0)                                                  //first direction left
            {
                bestRoute += $"L{Math.Abs(x)},";                        //second direction
                if (y < 0)
                {
                    bestRoute += $"L{Math.Abs(y)},";
                }

                else if (y > 0)
                {
                    bestRoute += $"R{y},";
                }
            }
            else if (x == 0 && y < 0)                                   //first direction right    
            {
                bestRoute += $"R{x},";                                  //cannot go down so turn right 0 blocks 
                if (y < 0)                                              //second direction    
                {
                    bestRoute += $"R{Math.Abs(y)},";
                }

                else if (y > 0)                                         
                {
                    bestRoute += $"L{y},";
                }
            }
            else if (x > 0)                                             //first direction right
            {
                bestRoute += $"R{x},";
                if (y < 0)                                              //second direction
                {
                    bestRoute += $"R{Math.Abs(y)},";
                }

                else if (y > 0)
                {
                    bestRoute += $"L{y},";
                }
            }
            else if (x == 0 && y > 0)                                   //first direction forward 
            {
                bestRoute += $"F{y},";
            }
        }

        public override string ToString()
        {                                                                                                                                 
            return dots + "**                    Best route                       **" + dots   //to remove last ','
                  +  $"\n{ date.ToString("yyyy-MM-dd")}; {name}; {bestRoute.Substring(0, bestRoute.Length - 1)}"; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            string dots = "\n*********************************************************\n";

            bool go = true;
            string header = dots + "** enter input as (Date; Name; Route) or (Name; Route) **" + dots;

            Console.WriteLine(header.Substring(1,header.Length - 1));

            string input = Console.ReadLine();
            string[]inputs = input.Split(';');

            while (go)                                                  //keeps input cycle going
            {

               
               if (inputs.Length == 3)
                {
                    DateTime myDate;                                    //convert the input string to a date 
                    try { myDate = DateTime.ParseExact(inputs[0], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); }
                    catch{ 
                        Console.WriteLine("\ninvalid date format, today assumed\n");
                        myDate = DateTime.Today;
                    }
                    location three = new location(myDate, inputs[1], inputs[2]);
                    Console.WriteLine(three);                           //output
                    Console.WriteLine(dots + "**              Keep going or enter 'q'?               **" + dots);
                    input = Console.ReadLine();
                    inputs = input.Split(';');                          //gets next input
                }
                else if (inputs.Length == 2)
                {
                    location two = new location(inputs[0], inputs[1]);
                    Console.WriteLine(two);
                    Console.WriteLine(dots + "**              Keep going or enter 'q'?               **" + dots);
                    input = Console.ReadLine();                         //output
                    inputs = input.Split(';');                          //gets next input
                }
                if (inputs.Length == 1)
                {
                    if ((input == "q") || (input == "Q"))
                    { 
                       go = false;
                    }
                    else
                    {
                        Console.WriteLine("\ninvalid input, quitting...");
                        go = false;
                    }
                }



                

            }


            //2017-01-01;Coffee Shop; L2, L5, L5, R5, L2
            //2017-01-02;Advertising Agency; R3, R3, R3, L2


        }
    }
}



