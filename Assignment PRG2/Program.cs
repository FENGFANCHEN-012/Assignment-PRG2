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




            Console.WriteLine("=============================================\r\nWelcome to Changi Airport Terminal 5\r\n=============================================\r\n1. List All Flights\r\n2. List Boarding Gates\r\n3. Assign a Boarding Gate to a Flight\r\n4. Create Flight\r\n5. Display Airline Flights\r\n6. Modify Flight Details\r\n7. Display Flight Schedule\r\n0. Exit\r\nPlease select your option:");
            string answer = Console.ReadLine()!;

            Dictionary<string, AirLine> airdic = new Dictionary<string, AirLine>();
            Dictionary<string, Flight> flightdic = new Dictionary<string, Flight>();
            Dictionary<string, BoardingGate> gatedic = new Dictionary<string, BoardingGate>();
            string gate = "C:\\Users\\johny\\source\\repos\\Assignment PRG2\\Assignment PRG2\\data\\boardinggates.csv";
            string airline = "C:\\Users\\johny\\source\\repos\\Assignment PRG2\\Assignment PRG2\\data\\airlines.csv";
            string flight = "C:\\Users\\johny\\source\\repos\\Assignment PRG2\\Assignment PRG2\\data\\flights.csv";
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

            void LoadFlight()
            {
                foreach (string i in flightdata)  /// load flight file
                {
                    if (flightdata.IndexOf(i) == 0)
                    {
                        continue;
                    }
                    List<string> data = new List<string>(i.Split(","));
                }
            }
            void LoadGate() {


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


            // feature 3
            void Command() {
                if (answer == "1")
                {
                    Console.WriteLine($"{"Flight Number",-30}{"AirLine Name",-30}{"Origin",-27}{"destination",-30}{"Expected Arrival",-15}");
                    foreach (var i in flightdic)
                    {
            void Command() {
                while (true) {
                    if (answer == "1")
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
                            foreach (var w in airdic)
                            {
                                if (w.Value.Code == i.Value.FlightNumber.Substring(0, 2))
                                {
                                    Console.WriteLine($"{i.Value.FlightNumber,-30}{w.Value.Name,-30}{i.Value.Origin,-27}{i.Value.Destination,-30}{i.Value.ExpectedTime,-15}");
                                }

                        }
                    }
                }
                /// create the boardgate object

                foreach (string i in gatedata.Skip(1))
                {

                    List<string> data = new List<string>(i.Split(","));
                            }
                        }
                    }
                    /// create the boardgate object

                 


                }


                /// Testing execution of files

                    /// Testing execution of files

                //feature 4
                if (answer == "2") {
                    Console.WriteLine($"{"Gate NAME",-10}{"DDJB",-10}{"CFFT",-10}{"LWTT",-10}");
                    foreach (var i in gatedic.Values)
                    {
                        Console.WriteLine($"{i.GetName,-10}{i.SupportsDDJB,-10}{i.SupportsCFFT,-10}{i.SupportsLWTT,-10}");
                    }

                    //feature 4
                    if (answer == "2") {
                        Console.WriteLine($"{"Gate NAME",-10}{"DDJB",-10}{"CFFT",-10}{"LWTT",-10}");
                        foreach (var i in gatedic.Values)
                        {
                            Console.WriteLine($"{i.GetName,-10}{i.SupportsDDJB,-10}{i.SupportsCFFT,-10}{i.SupportsLWTT,-10}");
                        }






                }
                if (answer == "3") { }
                foreach (var w in gatedic)
                {
                    }
                    if (answer == "3") { }
                    foreach (var w in gatedic)
                    {


                    foreach (var i in flightdic)
                    {
                        foreach (var i in flightdic)
                        {

                        if (i.Value.Status == w.)
                        {
                            if (i.Value.Status == w.)
                            {

                        }
                    } }

            }
                            }
                        } }

                }

            }

            LoadAirLine();
            LoadFlight();
            LoadGate();
            Command();

            Console.WriteLine($"Loaded airlines: {airdic.Count}");
            Console.WriteLine($"Loaded flights: {flightdic.Count}");
        } } }
            
