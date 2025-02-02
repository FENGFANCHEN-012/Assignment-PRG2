using Assignment_PRG2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;



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




            List<string> code = new List<string> { "DDJB","CFFT","LWTT",""};
            List<Flight> flightlist = new List<Flight>();
            Dictionary<string, AirLine> airdic = new Dictionary<string, AirLine>();
            Dictionary<string, Flight> flightdic = new Dictionary<string, Flight>();
            Dictionary<string, BoardingGate> gatedic = new Dictionary<string, BoardingGate>();
            Dictionary<string, double> fees = new Dictionary<string, double>();
            string gate = "C:\\Users\\johny\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\boardinggates.csv";
            string airline = "C:\\Users\\johny\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\airlines.csv";
            string flight = "C:\\Users\\johny\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\flights.csv";
            List<string> flightdata = new List<string>(File.ReadLines(flight));

            List<string> gatedata = new List<string>(File.ReadLines(gate));
            List<string> airdata = new List<string>(File.ReadLines(airline));

            Terminal terminal5 = new Terminal("terminal5", airdic, flightdic, gatedic, fees);



            void FlightType(List<string> flightdata, AirLine air, List<string> info)
            {
                
                string specialRequestCode = info[4]; 

                if (specialRequestCode == "CFFT")
                {
                    air.AddFlight(new CFFTFlight(info[0], info[1], info[2], Convert.ToDateTime(info[3]), "On Time"));
                }
                else if (specialRequestCode == "")
                {
                    air.AddFlight(new NORMFlight(info[0], info[1], info[2], Convert.ToDateTime(info[3]), "On Time"));
                }
                else if (specialRequestCode == "LWTT")
                {
                    air.AddFlight(new LWTTFlight(info[0], info[1], info[2], Convert.ToDateTime(info[3]), "On Time"));
                }
                else if (specialRequestCode == "DDJB")
                {
                    air.AddFlight(new DDJBFlight(info[0], info[1], info[2], Convert.ToDateTime(info[3]), "On Time"));
                }
            }

            void PrintGate()
            {
                Console.WriteLine($"{"Gate NAME",-10}{"DDJB",-10}{"CFFT",-10}{"LWTT",-10}");
                foreach (var x in gatedic.Values)
                {
                    Console.WriteLine($"{x.GetName,-10} {x.SupportsDDJB,-10} {x.SupportsCFFT,-10} {x.SupportsLWTT,-10}");
                }

            }
           
            void PrintFlight()
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
            AirLine LoopAirline(Dictionary<string,AirLine> airline,string choice)
            {
                Console.WriteLine(airline[choice].ToString());
                return airline[choice];
            }
            Flight LoopFlight(Dictionary<string, Flight> flight, string choice)
            {
                Console.WriteLine(flight[choice].ToString());
                return flight[choice];


            }
            BoardingGate LoopGate(Dictionary<string, BoardingGate> gate, string choice)
            {
                Console.WriteLine(gate[choice].ToString());
                return gate[choice];
            }
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

            void LoadFlight(Dictionary<string,AirLine> air)
            {



                Console.WriteLine("loading Flight.....");
                foreach (string i in flightdata)  /// load flight file
                {
                    if (flightdata.IndexOf(i) == 0)
                    {
                        continue;
                    }
                    List<string> data = new List<string>(i.Split(","));
                    foreach (var w in air)
                    {
                        if (data[0].Substring(0, 2) == w.Value.Name)
                        {
                            if (data[4] == "")

                            {
                                Console.WriteLine(data[4]);

                                w.Value.AddFlight(new NORMFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time"));
                             
                            }
                            else if (data[4] == "CFFT")
                            {
                                w.Value.AddFlight(flightdic[data[0]] = new CFFTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time"));
                                

                            }
                            else if (data[4] == "LWTT")
                            {
                                w.Value.AddFlight(flightdic[data[0]] = new LWTTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time"));
                              
                            }
                            else if (data[4] == "DDJB")
                            {
                                w.Value.AddFlight(flightdic[data[0]] = new DDJBFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), "ON Time"));
                             
                            }

                           

                        }
                    }

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
                Console.WriteLine("8. Assigned all Unassined Flight to gates");
                Console.WriteLine("9. Caculated fees of each airlines corporation");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Please select your option:");

            }
           
            void Assign()
            {

                try
                {
                    Console.WriteLine("Enter Flight Number:");
                    string flightnum = Console.ReadLine()!.Trim();
                    Console.WriteLine("Enter Boarding Gate Name:");
                    string gatename = Console.ReadLine()!.Trim();
                    LoopFlight(flightdic, flightnum);
                    Console.WriteLine(LoopFlight(flightdic, flightnum));
                    LoopGate(gatedic, gatename);
                    Console.WriteLine("Would you like to update the status of the flight? (Y/N)");
                    string choice1 = Console.ReadLine()!.ToUpper();
                    if (choice1 == "Y")
                    {
                        Console.WriteLine("1. Delayed\r\n2. Boarding\r\n3. On Time\r\nPlease select the new status of the flight:");
                        string choice2 = Console.ReadLine()!;
                        switch (choice2)
                        {
                            case "1":
                                LoopFlight(flightdic, flightnum).Status = "Delayed";
                                break;

                            case "2":
                                LoopFlight(flightdic, flightnum).Status = "Boarding";
                                break;

                            case "3":
                                LoopFlight(flightdic, flightnum).Status = "On Time";
                                break;

                        }
                        
                    }
                    LoopGate(gatedic, gatename).Flight = LoopFlight(flightdic, flightnum);
                    Console.WriteLine($"Flight {LoopFlight(flightdic, flightnum).FlightNumber} has been assigned to Boarding Gate {LoopGate(gatedic, gatename).GetName}!");

                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid Value Input Try Again Later");
                }
            }

                void DisplayAirLine(Dictionary<string,AirLine> air,Dictionary<string,Flight> flight,List<string> listdata,Dictionary<string,BoardingGate> gates)
            {

                Console.WriteLine($"{"AirLine Code",-15}{"AirLine Name",-15}");
                foreach(var i in air)
                {
                    Console.WriteLine($"{i.Key,-15}{i.Value.Name,-15}");
                }
                Console.Write("Enter Airline Code: ");

                string aircode = Console.ReadLine()!;
                Console.WriteLine("=============================================\r\nList of Airlines for Changi Airport Terminal 5\r\n=============================================");
                Console.WriteLine($"{"Flight Number",-25}{"AirLine Name",-25}{"Origin",-20}{"destination",-20}{"Expected Arrival",-20}{"Special Request Code",-15}{"Boarding Gate"}");
                foreach (var i in flight)
                {
                   

                            if (aircode == i.Key.Substring(0, 2))
                    {

                        foreach (var w in air)
                        {
                            if (aircode == w.Key)
                            {
                                foreach (string k in listdata)
                                {
                                    List<string> list = new List<string>(k.Split(","));
                                    if (list[0] == i.Value.FlightNumber)
                                    {
                                        bool gateAssigned = false;
                                        foreach (var m in gates)
                                        {
                                            if (m.Value.Flight != null && m.Value.Flight.FlightNumber == i.Value.FlightNumber)
                                            {
                                                Console.WriteLine($"{i.Value.FlightNumber,-25}{w.Value.Name,-25}{i.Value.Origin,-20}{i.Value.Destination,-20}{i.Value.ExpectedTime,-20}{list[4],-15}{m.Value.GetName}");
                                                gateAssigned = true;
                                                break; 
                                            }
                                        }
                                        if (!gateAssigned)
                                        {
                                            Console.WriteLine($"{i.Value.FlightNumber,-25}{w.Value.Name,-25}{i.Value.Origin,-20}{i.Value.Destination,-20}{i.Value.ExpectedTime,-20}{list[4],-15}{""}");
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
              
            }
            void Schedule(Dictionary<string, Flight> flightdic, Dictionary<string, BoardingGate> gatedic, Dictionary<string, AirLine> airdic,List<string> flightdata)
            {
                List<Flight> sortedFlights = flightdic.Values.ToList();
                sortedFlights.Sort((f1, f2) => f1.ExpectedTime.CompareTo(f2.ExpectedTime));
                Console.WriteLine("=============================================\r\nFlight Schedule for Changi Airport Terminal 5\r\n=============================================");
                Console.WriteLine($"{"Flight Number",-20}{"Airline Name",-20}{"Origin",-15}{"Destination",-15}{"Expected Arrival",-20}{"Status",-10}{"Special Code",-10}{"Boarding Gate"}");

                foreach (var flight in sortedFlights)
                {
                    string airlineName = airdic.ContainsKey(flight.FlightNumber.Substring(0, 2)) ? airdic[flight.FlightNumber.Substring(0, 2)].Name : "Unknown";
                    string gateName = "";

                    foreach (var data in flightdata)
                    {
                        List<string> data2 = new List<string>(data.Split(","));
                        if (data2[0] == flight.FlightNumber)
                        {
                            string code = data2[4];
                            if (data2[4] == "")
                            {
                                code = "Unassigned";
                            }
                            foreach (var gate in gatedic)
                            {
                                if (gate.Value.Flight != null && gate.Value.Flight.FlightNumber == flight.FlightNumber)
                                {
                                    gateName = gate.Value.GetName;
                                    break;
                                }
                            }

                            Console.WriteLine($"{flight.FlightNumber,-20}{airlineName,-20}{flight.Origin,-15}{flight.Destination,-15}{flight.ExpectedTime,-20}{flight.Status,-10}{code,-10}{gateName}");
                        }
                    }
                }
            }

            void ModifyFlight(Dictionary<string, AirLine> air, Dictionary<string, Flight> flight,List<string> flightdata,Dictionary<string,BoardingGate> boardgate) {
                DisplayAirLine(air, flight,flightdata, gatedic);
                string path = "C:\\Users\\Samue\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\flights.csv";
                Console.Write("Choose an existing Flight to modify or delete:");
                string choice2 = Console.ReadLine()!;
                Flight fly = LoopFlight(flight, choice2);
                
               


             
                Console.WriteLine("1. Modify Flight\r\n2. Delete Flight\r\nChoose an option:");
                string choice3 = Console.ReadLine()!;
                switch (choice3)
                {
                    case "1":
                        Console.WriteLine("1. Modify Basic Information\r\n2. Modify Status\r\n3. Modify Special Request Code\r\n4. Modify Boarding Gate\r\nChoose an option:");
                       string choice4 = Console.ReadLine()!;
                        switch(choice4){
                            case "1":
                                Console.WriteLine("Enter new Origin:");
                                string origin = Console.ReadLine()!;
                                Console.WriteLine("Enter new Destination:");
                                string destination = Console.ReadLine()!;
                                Console.WriteLine("Enter new Expected Departure/Arrival Time (dd/mm/yyyy hh:mm):");
                                string time = Console.ReadLine()!;
                                string formattedTime = Regex.Replace(time, @"(\d{1,2}:\d{2})\s*(am|pm)", "$1 $2", RegexOptions.IgnoreCase).ToUpper();
                               
                            
                                fly.Origin = origin;
                                fly.Destination = destination;
                                fly.ExpectedTime = Convert.ToDateTime(formattedTime);
                                Console.WriteLine("flight updated");

                                break;
                                
                                case "2":
                                Console.WriteLine("Enter new Status");
                                string status = Console.ReadLine()!;
                                fly.Status= status;
                                
                                break;
                                case "3":
                                Console.WriteLine("Enter special request code:");
                                string special = Console.ReadLine()!;
                            
                                
                                    for (int i = 0; i < flightdata.Count; i++)
                                    {
                                        List<string> list = new List<string>(flightdata[i].Split(','));
                                        if (list[0] == fly.FlightNumber)
                                        {
                                            // Update the special request code
                                            list[4] = special;
                                            flightdata[i] = string.Join(",", list);
                                            break; // Exit the loop once the line is found and modified
                                        }
                                    }

                                    // Write all lines back to the file
                                    File.WriteAllLines(path, flightdata);

                                break;

                            case "4":
                                Console.WriteLine("Enter the new BoardingGate Assign");
                                string gate = Console.ReadLine()!;
                                LoopGate(boardgate, gate).Flight = fly;
                                Console.WriteLine("Gate Assignment Finished");
                                
                                break;


                        }

                        Console.WriteLine($"{"Flight Number",-25}{"AirLine Name",-25}{"Origin",-20}{"Destination",-20}{"Expected Arrival",-20}{"Special Request Code",-15}{"Boarding Gate"}");

                        foreach (var i in flightdata)
                        {
                            List<string> w = new List<string>(i.Split(","));
                            if (w[0] == fly.FlightNumber)
                            {
                                string gateName = "";
                                foreach (var w2 in boardgate)
                                {
                                    if (w2.Value.Flight != null && w2.Value.Flight.FlightNumber == fly.FlightNumber)
                                    {
                                        gateName = w2.Value.GetName;
                                        break;
                                    }
                                }


                                string airlineName = "";
                                if (air.TryGetValue(fly.FlightNumber.Substring(0, 2), out var airline))
                                {
                                    airlineName = airline.Name;
                                }


                                Console.WriteLine($"{fly.FlightNumber,-25}{airlineName,-25}{fly.Origin,-20}{fly.Destination,-20}{fly.ExpectedTime,-20}{w[4],-15}{gateName}");
                                break;
                            }
                        }
                        break;
                       
                        
                        
                    case "2":


                        if (flight.ContainsKey(choice2))
                        {
                            string flightNum = flight[choice2].FlightNumber;
                            Console.WriteLine($"Delete {choice2} Successfully !");

                            flight.Remove(choice2);

                            foreach (var i in air)
                            {
                                if (flightNum.Substring(0, 2) == i.Value.Code)
                                {
                                    i.Value.Flights.Remove(choice2);
                                    break;
                                }
                            }

                            foreach (var gate in boardgate.Values)
                            {
                                if (gate.Flight != null && gate.Flight.FlightNumber == choice2)
                                {
                                    gate.Flight = null;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Can't find {choice2} Flight !");
                        }

                        break;
                      
                }
              

            }
            void CreateFlight(Dictionary<string,Flight> flight, Dictionary<string,AirLine> airline,List<string> code)
            {
                try
                { bool w = false;
                    while (!w)
                    {
                        Console.Write("Enter Flight Number:");
                        string flightNumber = Console.ReadLine()!.ToUpper();
                        if (airline.ContainsKey(flightNumber.Substring(0, 2)))
                        {


                            if (flight.ContainsKey(flightNumber))
                            {
                                Console.WriteLine("This Flight Already Exists, Try Create Another one");
                                return;
                            }
                            else

                            {




                                Console.Write("Enter Origin:");
                                string origin = Console.ReadLine()!;
                                Console.Write("Enter Destination:");
                                string destination = Console.ReadLine()!;
                                Console.Write("Enter Expected Departure / Arrival Time(dd / mm / yyyy hh: mm):");
                                string time = Console.ReadLine()!.Trim().ToUpper();
                                string expectedTime = Regex.Replace(time, @"\s*(AM|PM)\s*", " $1"); /////////////////////////////////////////////////
                                DateTime parsedWithSpace = DateTime.ParseExact(expectedTime, "h:mm tt", CultureInfo.InvariantCulture);


                                Console.Write("Enter Special Request Code");
                                string specialRequestCode = Console.ReadLine()!;

                                string filePath = "C:\\Users\\johny\\Desktop\\Assignment-PRG2\\Assignment PRG2\\data\\flights.csv";



                                // Handle empty special request code
                                if (string.IsNullOrWhiteSpace(specialRequestCode))
                                {
                                    specialRequestCode = "";  // Ensure empty value is added correctly in CSV
                                }
                                if (!code.Contains(specialRequestCode))
                                {
                                    Console.WriteLine("Invalid SpecialRequestCode");
                                }
                                else
                                {
                                    string newFlightEntry = $"{flightNumber},{origin},{destination},{expectedTime},{specialRequestCode}";
                                    List<string> info = new List<string> { flightNumber, origin, destination, parsedWithSpace.ToString(), specialRequestCode };
                                    foreach (var i in airline)
                                    {
                                        if (flightNumber.Substring(0, 2) == i.Value.Code)
                                        {
                                            FlightType(flightdata, i.Value, info);
                                            break;
                                        }
                                    }
                                    // Prepare the flight record




                                    // Append the new entry to the file
                                    using (StreamWriter writer = new StreamWriter(filePath, append: true))
                                    {
                                        writer.WriteLine(newFlightEntry);
                                    }


                                    Console.WriteLine("Flight added successfully.");







                                }
                                Console.Write("Do you want add another flight ?");
                                string ans = Console.ReadLine()!;
                                if(ans == "Y")
                                {
                                    w = false;
                                }
                                else
                                {
                                    w= true;
                                }
                            }
                        }




                        else
                        {
                            Console.WriteLine("Invalid AirLine flight!");
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("invalid input " + ex);
                }




               
            }





            // Advanced features
            void BulkAssignBoardingGates(Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> gates)
            {
                Queue<Flight> unassignedFlights = new Queue<Flight>();
                int unassignedGatesCount = 0;


                foreach (var flight in flights.Values)
                {
                    bool isAssigned = false;
                    foreach (var gate in gates.Values)
                    {
                        if (gate.Flight != null && gate.Flight.FlightNumber == flight.FlightNumber)
                        {
                            isAssigned = true;
                            break;
                        }
                    }
                    // check whether flight has assigned to the gate
                    if (!isAssigned)
                    {
                        unassignedFlights.Enqueue(flight); // add the flight into queue 
                    }
                }


                foreach (var gate in gates.Values)
                {
                    if (gate.Flight == null)
                    {
                        unassignedGatesCount++; // count number of unassigned flight in queue
                    }
                }

                Console.WriteLine($"Total unassigned flights: {unassignedFlights.Count}");
                Console.WriteLine($"Total unassigned gates: {unassignedGatesCount}");


                while (unassignedFlights.Count > 0)
                {
                    Flight flight = unassignedFlights.Dequeue();               // get first items in queue
                    bool gateAssigned = false;

                    foreach (var gate in gates.Values)
                    {                                                    
                        if (gate.Flight == null)
                        {  
                            if (flight is CFFTFlight && gate.SupportsCFFT ||   // check requirement of gate 
                                flight is DDJBFlight && gate.SupportsDDJB ||
                                flight is LWTTFlight && gate.SupportsLWTT ||
                                flight is NORMFlight && !gate.SupportsCFFT && !gate.SupportsDDJB && !gate.SupportsLWTT)
                            {
                                gate.Flight = flight;
                                gateAssigned = true;
                                Console.WriteLine($"Flight {flight.FlightNumber} assigned to Gate {gate.GetName}");
                                break;
                            }
                        }
                    }

                    if (!gateAssigned)
                    {
                        Console.WriteLine($"No available gate for Flight {flight.FlightNumber}");
                    }
                }

                Console.WriteLine("Bulk assignment completed.");
            }
          
            void CalculateDailyFees(Dictionary<string, AirLine> airlines, Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> gates)
            {
             
                foreach (var flight in flights.Values)
                {
                    bool isAssigned = false;
                    foreach (var gate in gates.Values)
                    {
                        if (gate.Flight != null && gate.Flight.FlightNumber == flight.FlightNumber)
                        {
                            isAssigned = true;
                            break;
                        }
                    }
                    if (!isAssigned)
                    {
                        Console.WriteLine("Please assign boarding gates to all flights before calculating fees.");
                        return;
                    }
                }

              
                foreach (var airline in airlines.Values)
                {
                    double totalFee = 0;
                    double totalDiscount = 0;
                    int flightCount = 0;

                    foreach (var flight in airline.Flights.Values)
                    {
                       
                        if (flight.Origin == "Singapore (SIN)")
                        {
                            totalFee += 800; 
                        }
                        else if (flight.Destination == "Singapore (SIN)")
                        {
                            totalFee += 500; 
                        }

                        if (flight is CFFTFlight)
                        {
                            totalFee += 150;
                        }
                        else if (flight is DDJBFlight)
                        {
                            totalFee += 300;
                        }
                        else if (flight is LWTTFlight)
                        {
                            totalFee += 500;
                        }

                        // 登机口基础费用
                        totalFee += 300;

                        flightCount++;
                    }

                    // 计算折扣
                    if (flightCount >= 3)
                    {
                        totalDiscount += 350;
                    }
                    if (flightCount > 5)
                    {
                        totalDiscount += totalFee * 0.03;
                    }

                    // 显示每家航空公司的费用
                    Console.WriteLine($"Airline: {airline.Name}");
                    Console.WriteLine($"Total Fee: {totalFee}");
                    Console.WriteLine($"Total Discount: {totalDiscount}");
                    Console.WriteLine($"Final Fee: {totalFee - totalDiscount}");
                    Console.WriteLine();
                }
            }
        







            void Command(Dictionary<string, Flight> flight, Dictionary<string, BoardingGate> gate, Dictionary<string, AirLine> airline)
            {
                while (true)

                {
                    Menu();


                    string answer = Console.ReadLine()!.Trim();
                    if (answer == "0")
                    {
                        break;
                    }
                    else {
                        
                        switch (answer)
                        {
                            case "1":  // feature 3


                                PrintFlight();

                                break;


                            //feature 4 
                            case "2":
                                PrintGate();
                                break;


                            case "3":
                                Assign();
                                break;
                            case "4":
                                CreateFlight(flight, airdic,terminal5);
                                break;
                            case "5":
                                DisplayAirLine(airdic, flightdic, flightdata, gatedic);
                                break;
                            case "6":
                                ModifyFlight(airdic, flightdic, flightdata, gatedic);
                                break;
                            case "7":
                                Schedule(flightdic, gatedic, airdic, flightdata);
                                break;
                            case "8":
                                Console.WriteLine("sd");
                                break;
                            case "9":
                                Console.WriteLine("sd");
                                break;

                        }
                           








                    }

                }



              
            }
            LoadGate();
            LoadFlight(airdic);
            LoadAirLine();
            BulkAssignBoardingGates(flightdic, gatedic);
            CalculateDailyFees(airdic, flightdic, gatedic);
            Command(flightdic, gatedic, airdic);
        }
    }
}
        
    











