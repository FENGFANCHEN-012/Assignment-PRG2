using System;
using System.Collections.Generic;
using System.IO;



//==========================================================
// Student Number : S10268902
// Student Name   : CHEN FENGFAN
// Partner Name   : Samuel Tay
//==========================================================

namespace Assignment_PRG2
{
    class Program
    {
        static void Main(string[] args)
        {






            Dictionary<string, AirLine> airdic = new Dictionary<string, AirLine>();
            Dictionary<string, Flight> flightdic = new Dictionary<string, Flight>();
            Dictionary<string, BoardingGate> gatedic = new Dictionary<string, BoardingGate>();
            string gate = "C:\\Users\\johny\\Source\\Repos\\Assignment-PRG2\\Assignment PRG2\\data\\boardinggates.csv";
            string airline = "C:\\Users\\johny\\Source\\Repos\\Assignment-PRG2\\Assignment PRG2\\data\\airlines.csv";
            string flight = "C:\\Users\\johny\\Source\\Repos\\Assignment-PRG2\\Assignment PRG2\\data\\flights.csv";
            List<string> flightdata = new List<string>(File.ReadLines(flight));
            List<string> airdata = new List<string>(File.ReadLines(airline));
            List<string> gatedata = new List<string>(File.ReadLines(gate));


            void LoadAirLine()
            {
                foreach (string i in airdata)   /// load airlines file
                {
                    if (airdata.IndexOf(i) == 0)
                    {
                        continue;
                    }
                    List<string> data = new List<string>(i.Split(","));
                    airdic[data[1]] = new AirLine(data[0], data[1], flightdic);

                }
            }
            void LoadGate()  // load gatefile

            {

                foreach (string i in gatedata.Skip(1))
                {

                    List<string> data = new List<string>(i.Split(","));

                    gatedic[data[0]] = new BoardingGate(data[0], Convert.ToBoolean(data[1]), Convert.ToBoolean(data[2]), Convert.ToBoolean(data[3]), null);

                }

            }

            void LoadFlight()
            {
                foreach (string i in flightdata)  /// load flight file
                {
                    if (flightdata.IndexOf(i) == 0)
                    {
                        continue;
                    }
                    List<string> data = new List<string>(i.Split(","));

                    if (data[4] == "")

                    {
                        Console.WriteLine(data[4]);
                        flightdic[data[0]] = new NORMFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
                    }
                    else if (data[4] == "CFFT")
                    {
                        flightdic[data[0]] = new CFFTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
                    }
                    else if (data[4] == "LWTT")
                    {
                        flightdic[data[0]] = new LWTTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
                    }
                    else if (data[4] == "DDJB")
                    {
                        flightdic[data[0]] = new DDJBFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
                    }


                }
            }
            void Menu()
            {
                Console.WriteLine(@"
=============================================
Welcome to Changi Airport Terminal 5
=============================================
1. List All Flights
2. List Boarding Gates
3. Assign a Boarding Gate to a Flight
4. Create Flight
5. Display Airline Flights
6. Modify Flight Details
7. Display Flight Schedule
0. Exit
Please select your option:
");
                
            }



            void Command()
            {
                while (true)

                {
                    Menu();

                    string answer = Console.ReadLine()!;


                    if (answer == "1")   // feature 3
                    {

                        Console.WriteLine($"{"Flight Number",-30}{"AirLine Name",-30}{"Origin",-27}{"destination",-30}{"Expected Arrival",-15}");

                        foreach (var i in flightdic)
                        {

                            foreach (var w in airdic)
                            {
                                if (w.Value.Code == i.Value.FlightNumber.Substring(0, 2))
                                {
                                    Console.WriteLine($"{i.Value.FlightNumber,-30}{w.Value.Name,-30}{i.Value.Origin,-27}{i.Value.Destination,-30}{i.Value.ExpectedTime,-15}");

                                }
                            }
                        }






                        //feature 4 
                        if (answer == "2")
                        {
                            Console.WriteLine($"{"Gate NAME",-10}{"DDJB",-10}{"CFFT",-10}{"LWTT",-10}");
                            foreach (var x in gatedic.Values)
                            {
                                Console.WriteLine($"{x.GetName,-10} {x.SupportsDDJB,-10} {x.SupportsCFFT,-10} {x.SupportsLWTT,-10}");
                            }





                        
                        }


                    }



                }
            
            }
            LoadGate();
            LoadFlight();
            LoadAirLine();
            Command();
        }
    }
}
            

        

    

            
