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
            string gate = "C:\\Users\\johny\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\boardinggates.csv";
            string airline = "C:\\Users\\johny\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\airlines.csv";
            string flight = "C:\\Users\\johny\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\flights.csv";
            List<string> flightdata = new List<string>(File.ReadLines(flight));
            List<string> airdata = new List<string>(File.ReadLines(airline));
            List<string> gatedata = new List<string>(File.ReadLines(gate));


            void LoadAirLine()
            {
                Console.WriteLine("loading AirLines.....");
                foreach (string i in airdata)   /// load airlines file
                {
                    if (airdata.IndexOf(i) == 0)
                    {
                        continue;
                    }
                    List<string> data = new List<string>(i.Split(","));
                    airdic[data[1]] = new AirLine(data[0], data[1], flightdic);

                }
                Console.WriteLine($"{airdic.Count()} AirLines Loaded");
            }
            void LoadGate()  // load gatefile

            {
                Console.WriteLine("loading Boarding Gates.....");
                foreach (string i in gatedata.Skip(1))
                {

                    List<string> data = new List<string>(i.Split(","));

                    gatedic[data[0]] = new BoardingGate(data[0], Convert.ToBoolean(data[1]), Convert.ToBoolean(data[2]), Convert.ToBoolean(data[3]), null);

                }

                Console.WriteLine($"{gatedic.Count()} Boarding Gates Loaded");
            }

            void LoadFlight()
            {



                Console.WriteLine("loading Flight.....");
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
                        flightdic[data[0]] = new NORMFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time");
                    }
                    else if (data[4] == "CFFT")
                    {
                        flightdic[data[0]] = new CFFTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time");
                    }
                    else if (data[4] == "LWTT")
                    {
                        flightdic[data[0]] = new LWTTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time");
                    }
                    else if (data[4] == "DDJB")
                    {
                        flightdic[data[0]] = new DDJBFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time");
                    }


                }
                Console.WriteLine($"{flightdic.Count()} Flights Loaded");
            }
            void Menu()
            {

                Console.WriteLine("=============================================");
                Console.WriteLine("Welcome to Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. List All Flights");
                Console.WriteLine("2. List Boarding Gates");
                Console.WriteLine("3. Assign a Boarding Gate to a Flight");
                Console.WriteLine("4. Create Flight");
                Console.WriteLine("5. Display Airline Flights");
                Console.WriteLine("6. Modify Flight Details");
                Console.WriteLine("7. Display Flight Schedule");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Please select your option:");

            }
            void Assign()
            {
                bool judge = false;
                bool judge2 = false;
                Console.WriteLine("Enter Flight Number:");
                string flightnum = Console.ReadLine()!;
                Console.WriteLine("Enter Boarding Gate Name:");
                string gatename = Console.ReadLine()!;

                foreach (var i in flightdic)
                {
                    if (flightnum == i.Key)
                    {
                        judge = true;

                        Console.WriteLine($"{i.Value.FlightNumber}");
                        Console.WriteLine($"{i.Value.Origin}");
                        Console.WriteLine($"{i.Value.Destination}");
                        Console.WriteLine($" {i.Value.ExpectedTime}");


                        foreach (string m in flightdata)
                        {

                            List<string> data = new List<string>(m.Split(","));
                            if (i.Key == data[0])
                            {
                                if (data[4] == "")
                                {

                                    Console.WriteLine($"Special Request Code: {"none"}");

                                }
                                else { Console.WriteLine($"Special Request Code: {data[4]}"); }


                            }

                        }

                    }

                }
                if (judge2 == false)
                {
                    Console.WriteLine("invalid flight input try again later.");
                }

                foreach (var x in gatedic.Values)
                {
                    if (gatename == x.GetName)
                    {
                        Console.WriteLine($"Boarding Gate Name: {gatename}");

                        Console.WriteLine($"Supports DDJB:{x.SupportsDDJB}");

                        Console.WriteLine($"Supports CFFT::{x.SupportsCFFT}");

                        Console.WriteLine($"Supports LWTT:{x.SupportsLWTT}");


                        judge = true;
                        break;

                    }

                }
                if (judge == false)
                {
                    Console.WriteLine("Invalid GateNumber Input");
                }
                else
                {
                    Console.WriteLine($"Boarding Gate Name: {gatename}");
                }

                Console.WriteLine("Would you like to update the status of the flight? (Y/N)");

                string choice = Console.ReadLine()!;
                if (choice == "Y")
                {
                    Console.WriteLine("1. Delayed\r\n2. Boarding\r\n3. On Time");
                    string choice2 = Console.ReadLine()!;
                    switch (choice2)
                    {
                        case "1":
                            k.Status = "Delayed";
                            break;

                        case "2":
                            k.Status = "Boarding";
                            break;

                        case "3":
                            k.Status = "On Time";
                            break;

                    }
                    foreach (var i in gatedic.Values)
                    {
                        if (gatename == i.GetName)
                            foreach (var m in flightdic.Values)
                            {
                                if (flightnum == m.FlightNumber)
                                {
                                    i.Flight = m; break;
                                    Console.WriteLine($"Flight {m.FlightNumber} has been assigned to Boarding Gate {i.GetName}!");
                                }
                            }
                    }

                }
                else
                {

                }

            }
            void CreateFlight(string flightNumber, string origin, string destination, string expectedTime, string specialRequestCode)
            {
                string filePath = "C:\\Users\\johny\\Source\\Repos\\Assignment-PRG2\\Assignment PRG2\\data\\flights.csv";

                // Format the expected time to match the existing format (e.g., 10:00 AM)
                string formattedTime = expectedTime.ToString("h:mm tt");

                // Handle empty special request code
                if (string.IsNullOrWhiteSpace(specialRequestCode))
                {
                    specialRequestCode = "";  // Ensure empty value is added correctly in CSV
                }

                // Prepare the flight record
                string newFlightEntry = $"{flightNumber},{origin},{destination},{formattedTime},{specialRequestCode}";

                try
                {
                    // Append the new entry to the file
                    using (StreamWriter writer = new StreamWriter(filePath, append: true))
                    {
                        writer.WriteLine(newFlightEntry);
                    }

                    Console.WriteLine("Flight added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to file: {ex.Message}");
                }
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
                    if (answer == "3")
                    {
                        Assign();



                    }

                    if (answer == "4")
                    {
                        Console.Write("Enter Flight Number:");
                        string flightNumber = Console.ReadLine();
                        Console.Write("Enter Origin:");
                        string origin = Console.ReadLine();
                        Console.Write("Enter Destination:");
                        string destination = Console.ReadLine();
                        Console.Write("Enter Expected Departure / Arrival Time(dd / mm / yyyy hh: mm):");
                        string expectedTime = Console.ReadLine();




                    }
                }






                LoadGate();
                LoadFlight();
                LoadAirLine();
                Command();
            }

        }
    }
}








