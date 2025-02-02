//==========================================================
// Student Number: S10267911
// Student Name	: Dylan Leong
// Partner Name	: Isaac Lum
//==========================================================

using S10267911_PRG2Assignment.Classes;
using System.Globalization;
using System.Xml.Serialization;

// Load Airlines
Console.WriteLine("Loading Airlines...");
Dictionary<string, Airline> airlineDict = new Dictionary<string, Airline>();
CreateAirline(airlineDict);
Console.WriteLine($"{airlineDict.Count} Airlines Loaded!");
// Load Boarding Gates
Console.WriteLine("Loading Boarding Gates...");
Dictionary<string, BoardingGate> boardingGateDict = new Dictionary<string, BoardingGate>();
CreateBoardingGate(boardingGateDict);
Console.WriteLine($"{boardingGateDict.Count} Boarding Gates Loaded!");
// Load Flights :D
Console.WriteLine("Loading Flights...");
Dictionary<string, Flight> flightDict = new Dictionary<string, Flight>();
CreateFlight(flightDict, airlineDict);
Console.WriteLine($"{flightDict.Count} Flights Loaded!");

while (true)
{
    // Menu 
    Console.WriteLine("\r\n=============================================\r\nWelcome to Changi Airport Terminal 5\r\n=============================================\r\n1. List All Flights\r\n2. List Boarding Gates\r\n3. Assign a Boarding Gate to a Flight\r\n4. Create Flight\r\n5. Display Airline Flights\r\n6. Modify Flight Details\r\n7. Display Flight Schedule\r\n8. Process all unassigned flights to boarding gates in bulk\r\n9. Calculate Fees\r\n10. Flight Status Statistics\r\n11. Flight Search by Origin/Destination\r\n0. Exit\r\n");
    Console.WriteLine("Please Enter Your Choice: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        // List All Flights
        Console.WriteLine("=============================================");
        Console.WriteLine("List of Flights for Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        ListAllFlights(flightDict, airlineDict);
    }
    else if (choice == "2")
    {
        // List Boarding Gates
        Console.WriteLine("=============================================");
        Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        ListAllBoardingGates(boardingGateDict);
    }
    else if (choice == "3")
    {
        // Assign a Boarding Gate to a Flight
        Console.WriteLine("=============================================");
        Console.WriteLine("Assigning a Boarding Gate to a Flight...");
        Console.WriteLine("=============================================");
        AssignBoardingGateToFlight(flightDict, boardingGateDict);
    }
    else if (choice == "4")
    {
        // Create Flights:D
        Console.WriteLine("=============================================");
        Console.WriteLine("Create a New Flight");
        Console.WriteLine("=============================================");
        CreateNewFlight(flightDict, airlineDict);
    }
    else if (choice == "5")
    {
        // Display Airline Flights :D
        Console.WriteLine("=============================================");
        Console.WriteLine("Display Flights for an Airline");
        Console.WriteLine("=============================================");
        DisplayAirlineFlights(flightDict, airlineDict, boardingGateDict);
    }
    else if (choice == "6")
    {
        // Modify Flight Details :D

        ModifyFlightDetails(flightDict);
    }
    else if (choice == "7")
    {
        // Display Flight Schedule :D
        Console.WriteLine("=============================================");
        Console.WriteLine("Flight Schedule for Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        DisplayFlightSchedule(flightDict, airlineDict, boardingGateDict);
    }
    else if (choice == "8")
    {
        // Bulk Assign Gates (Advanced Features :D)
        Console.WriteLine("=============================================");
        Console.WriteLine("Bulk Assign Boarding Gates to Flights");
        Console.WriteLine("=============================================");
        BulkAssignGates(flightDict, boardingGateDict);
    }
    else if (choice == "9")
    {
        // Calculate Fees (Advanced Features :D)
        Console.WriteLine("=============================================");
        Console.WriteLine("Calculate Fees for Airlines");
        Console.WriteLine("=============================================");
        CalculateFees(airlineDict, boardingGateDict, flightDict);
    }
    else if (choice == "10")
    {
        // Flight Status Statistics
        ShowFlightStatusTrendAnalysis(flightDict);

    }
    else if (choice == "11")
    {
        // Additional Feature (d): Flight Search by Origin/Destination
        Console.WriteLine("=============================================");
        Console.WriteLine("Flight Search by Origin/Destination");
        Console.WriteLine("=============================================");
        SearchFlightsByOriginDestination(flightDict);
    }
    else if (choice == "0")
    {
        // Exit
        Console.WriteLine("Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid Choice! Please Try Again!");
    }
}
// Get Airline data from csv (Basic Feature 1)
void CreateAirline(Dictionary<string, Airline> airlineDict)
{
    string[] csvLines = File.ReadAllLines("D:\\School\\Data Science Y1S2\\Programming\\S10267911_PRG2Assignment\\S10267911_PRG2Assignment\\CSVs\\airlines.csv"); //For Dylan's use
    //8string[] csvLines = File.ReadAllLines("C:\\Users\\isaac\\OneDrive - Ngee Ann Polytechnic\\Apps\\DS Y1 SEM 2\\PROGRAMMING ii\\asg 2\\airlines.csv"); //For Isaac's use
    for (int i = 1; i < csvLines.Length; i++)
    {
        string[] data = csvLines[i].Split(',');
        string name = data[0];
        string code = data[1];
        Airline airline = new Airline(name, code);
        airlineDict.Add(code, airline); //add airline to the dictionary
    }
}
//Get BoardingGate data from csv (Basic Feature 1)
void CreateBoardingGate(Dictionary<string, BoardingGate> boardingGateDict)
{
    string[] csvLines = File.ReadAllLines("D:\\School\\Data Science Y1S2\\Programming\\S10267911_PRG2Assignment\\S10267911_PRG2Assignment\\CSVs\\boardinggates.csv");  //For Dylan's use
    //string[] csvLines = File.ReadAllLines("C:\\Users\\isaac\\OneDrive - Ngee Ann Polytechnic\\Apps\\DS Y1 SEM 2\\PROGRAMMING ii\\asg 2\\boardinggates.csv");  //For Isaac's use
    for (int i = 1; i < csvLines.Length; i++)
    {
        string[] data = csvLines[i].Split(',');
        string gateName = data[0];
        bool supportCFFT = bool.Parse(data[1]);
        bool supportsDDJB = bool.Parse(data[2]);
        bool supportsLWTT = bool.Parse(data[3]);
        BoardingGate boardingGate = new BoardingGate(gateName, supportCFFT, supportsDDJB, supportsLWTT);
        boardingGateDict.Add(gateName, boardingGate); //Add boarding gate to dictionary
    }
}
// Get Flight data from CSV (Basic Feature 2 :D)

void CreateFlight(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict) //csv file
{
    string[] csvLines = File.ReadAllLines("D:\\School\\Data Science Y1S2\\Programming\\S10267911_PRG2Assignment\\S10267911_PRG2Assignment\\CSVs\\flights.csv");  //For Dylan's use
    //string[] csvLines = File.ReadAllLines("C:\\Users\\isaac\\OneDrive - Ngee Ann Polytechnic\\Apps\\DS Y1 SEM 2\\PROGRAMMING ii\\asg 2\\flights.csv");   //For Isaac's use

    for (int i = 1; i < csvLines.Length; i++)
    {
        string[] data = csvLines[i].Split(',');
        string flightNumber = data[0];
        string origin = data[1];
        string destination = data[2];
        DateTime currentDate = DateTime.Now;
        DateTime expectedTime = DateTime.ParseExact(currentDate.ToString("dd/MM/yyyy ") + data[3], "d/M/yyyy h:mm tt", CultureInfo.InvariantCulture);//invariant culture helps to ensure no parsing errors and date format remains consistent etc france 18-01-2025 instead of 18/01/2025
        string specialRequestCode = data[4];
        string airlineCode = flightNumber.Split(' ')[0];
        if (!airlineDict.ContainsKey(airlineCode))
        {
            Console.WriteLine($"Airline {airlineCode} not found for flight {flightNumber}");
            continue;
        }
        Flight flight;
        switch (specialRequestCode.ToUpper())
        {
            case "CFFT":
                flight = new CFFTFlight(flightNumber, origin, destination, expectedTime);
                break;
            case "DDJB":
                flight = new DDJBFlight(flightNumber, origin, destination, expectedTime);
                break;
            case "LWTT":
                flight = new LWTTFlight(flightNumber, origin, destination, expectedTime);
                break;
            default:
                flight = new NormFlight(flightNumber, origin, destination, expectedTime);
                break;
        }
        flightDict.Add(flightNumber, flight); //add to dict
        airlineDict[airlineCode].flights.Add(flightNumber, flight); //Associate flight with airline
    }
}
// ===---------==== Menu Option Methods ===---------==== :D
// List All Flights (Basic Feature 3 :D)

void ListAllFlights(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict)
{
    Console.WriteLine($"{"Flight Number",-15}{"Airline Name",-20}{"Origin",-20}{"Destination",-20}{"Expected Departure/Arrival Time",-30}");
    foreach (var flight in flightDict.Values)
    {
        // Extract the airline code from the flight number (e.g., "SQ 115" -> "SQ")
        string airlineCode = flight.FlightNumber.Split(' ')[0];

        // Retrieve the airline name from the airline dictionary
        string airlineName = airlineDict.ContainsKey(airlineCode) ? airlineDict[airlineCode].name : "Unknown Airline";

        // Format the expected time as "dd/MM/yyyy hh:mm:ss tt"
        string formattedTime = flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm:ss tt");

        // Display the flight details
        Console.WriteLine($"{flight.FlightNumber,-15}{airlineName,-20}{flight.Origin,-20}{flight.Destination,-20}{formattedTime,-30}");
    }
}
// List All Boarding Gates (Basic Feature 4)
void ListAllBoardingGates(Dictionary<string, BoardingGate> boardingGateDict)
{
    Console.WriteLine($"{"Gate Name",-20}{"DDJB",-15}{"CFFT",-15}{"LWTT",-15}{"Flight Number",-15}");
    foreach (var boardingGate in boardingGateDict.Values)
    {
        if (boardingGate.flight == null)
        {
            Console.WriteLine($"{boardingGate.gateName,-20}{boardingGate.supportsDDJB,-15}{boardingGate.supportCFFT,-15}{boardingGate.supportsLWTT,-15}{"No Assigned Flights",-15}");
        }
        else
        {
            Console.WriteLine($"{boardingGate.gateName,-20}{boardingGate.supportsDDJB,-15}{boardingGate.supportCFFT,-15}{boardingGate.supportsLWTT,-15}{boardingGate.flight.FlightNumber,-15}");
        }
    }
}
// Assign a Boarding Gate to a Flight numberr (Basic Feature 5 :D)
void AssignBoardingGateToFlight(Dictionary<string, Flight> flightDict, Dictionary<string, BoardingGate> boardingGateDict)
{
    Console.Write("Enter Flight Number: ");
    string flightNumber = Console.ReadLine();
    if (!flightDict.ContainsKey(flightNumber))
    {
        Console.WriteLine("Flight not found!");
        return;
    }
    Console.Write("Enter Boarding Gate: ");
    string gateName = Console.ReadLine();
    if (!boardingGateDict.ContainsKey(gateName))
    {
        Console.WriteLine("Boarding Gate not found!");
        return;
    }
    BoardingGate gate = boardingGateDict[gateName];
    Flight flight = flightDict[flightNumber];
    string SRC;
    if (flight is CFFTFlight)
    {
        SRC = "CFFT";
    }
    else if (flight is DDJBFlight)
    {
        SRC = "DDJB";
    }
    else if (flight is LWTTFlight)
    {
        SRC = "LWTT";
    }
    else
    {
        SRC = "None";
    }
    // Check if gate supports any special requests
    if (flight is CFFTFlight && !gate.supportCFFT ||
        flight is DDJBFlight && !gate.supportsDDJB ||
        flight is LWTTFlight && !gate.supportsLWTT)
    {
        Console.WriteLine("This gate does not support the flight's special request!");
        return;
    }
    if (gate.flight != null)
    {
        Console.WriteLine("This gate is already occupied!");
        return;
    }
    Console.WriteLine($"Flight Number: {flight.FlightNumber}");
    Console.WriteLine($"Origin: {flight.Origin}");
    Console.WriteLine($"Destination: {flight.Destination}");
    Console.WriteLine($"Expected Time: {flight.ExpectedTime}");
    Console.WriteLine($"Special Request Code: {SRC}");
    Console.WriteLine($"Boarding Gate Name: {gate.gateName}");
    Console.WriteLine($"Supports DDJB: {gate.supportsDDJB}");
    Console.WriteLine($"Supports CFFT: {gate.supportCFFT}");
    Console.WriteLine($"Supports LWTT: {gate.supportsLWTT}");
    Console.WriteLine("Would you like to update the status of the flight? (Y/N): ");
    string updatestatus = Console.ReadLine().ToUpper().Trim();
    if (updatestatus == "Y")
    {
        Console.WriteLine("1. Delayed\r\n2. Boarding\r\n3. On Time\r\nPlease select the new status of the flight:");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            flight.Status = "Delayed";
        }
        else if (choice == "2")
        {
            flight.Status = "Boarding";
        }
        else if (choice == "3")
        {
            flight.Status = "On Time";
        }
        else
        {
            Console.WriteLine("Invalid choice!");
            return;
        }
        gate.flight = flight;
        Console.WriteLine($"Flight {flightNumber} has been assigned to Boarding Gate {gateName}.");
    }
    else if (updatestatus == "N")
    {
        gate.flight = flight;
        Console.WriteLine($"Flight {flightNumber} has been assigned to Boarding Gate {gateName}.");
    }
    else
    {
        Console.WriteLine("Invalid choice!");
        return;
    }
}
// Create a New Flight (Basic Feature 6)
void CreateNewFlight(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict)
{
    Console.Write("Enter Flight Number (e.g., SQ 123): ");
    string flightNumber = Console.ReadLine().Trim().ToUpper();
    if (flightDict.ContainsKey(flightNumber))
    {
        Console.WriteLine("Flight already exists!");
        return;
    }

    Console.Write("Enter Origin: ");
    string origin = Console.ReadLine().Trim();

    Console.Write("Enter Destination: ");
    string destination = Console.ReadLine().Trim();

    // Prompt for Expected Departure/Arrival Time in the correct format
    Console.Write("Enter Expected Departure/Arrival Time (dd/MM/yyyy HH:mm): ");
    string expectedTimeInput = Console.ReadLine().Trim();

    // Parse the input using the correct format (allow single-digit day and month)
    DateTime expectedTime;
    if (!DateTime.TryParseExact(expectedTimeInput, "d/M/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out expectedTime))
    {
        Console.WriteLine("Invalid date/time format. Please use the format dd/MM/yyyy HH:mm.");
        return;
    }

    Console.Write("Enter Special Request Code (CFFT/DDJB/LWTT/None): ");
    string specialRequestCode = Console.ReadLine().Trim().ToUpper();

    // Extract the airline code from the flight number (e.g., "SQ 739" -> "SQ")
    string airlineCode = flightNumber.Split(' ')[0];
    if (!airlineDict.ContainsKey(airlineCode))
    {
        Console.WriteLine("Airline not found!");
        return;
    }

    // Create the appropriate flight object based on the special request code
    Flight flight;
    switch (specialRequestCode)
    {
        case "CFFT":
            flight = new CFFTFlight(flightNumber, origin, destination, expectedTime);
            break;
        case "DDJB":
            flight = new DDJBFlight(flightNumber, origin, destination, expectedTime);
            break;
        case "LWTT":
            flight = new LWTTFlight(flightNumber, origin, destination, expectedTime);
            break;
        default:
            flight = new NormFlight(flightNumber, origin, destination, expectedTime);
            break;
    }

    // Add the flight to the dictionaries
    flightDict.Add(flightNumber, flight);
    airlineDict[airlineCode].flights.Add(flightNumber, flight);

    Console.WriteLine($"Flight {flightNumber} has been added!");
    Console.Write("Would you like to add another flight? (Y/N): ");
    string addAnother = Console.ReadLine().Trim().ToUpper();
    if (addAnother == "Y")
    {
        CreateNewFlight(flightDict, airlineDict); // Recursively call to add another flight
    }
}

// Display Airline Flights (Basic Feature 7)
void DisplayAirlineFlights(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict, Dictionary<string, BoardingGate> boardingGateDict)
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine($"{"Airline Code",-15}{"Airline Name",-20}");
    foreach (var airline in airlineDict.Values)
    {
        Console.WriteLine($"{airline.code,-15}{airline.name,-20}");
    }
    Console.Write("Enter Airline Code: ");
    string airlineCode = Console.ReadLine().Trim();
    if (!airlineDict.ContainsKey(airlineCode))
    {
        Console.WriteLine("Airline not found!");
        return;
    }
    Console.WriteLine("=============================================");
    Console.WriteLine($"List of Flights for {airlineDict[airlineCode].name}:");
    Console.WriteLine("=============================================");
    Console.WriteLine($"{"Flight Number",-15}{"Origin",-20}{"Destination",-20}{"Expected Time",-25}{"Status",-10}{"Special Request Code",-25}{"Boarding Gate",-15}");
    foreach (var flight in airlineDict[airlineCode].flights.Values)
    {
        string bg = "Unassigned";
        string SRC; //Storing Special Request Code of the flight
        if (flight is CFFTFlight)
        {
            SRC = "CFFT";
        }
        else if (flight is DDJBFlight)
        {
            SRC = "DDJB";
        }
        else if (flight is LWTTFlight)
        {
            SRC = "LWTT";
        }
        else
        {
            SRC = "None";
        }
        foreach (var boardingGate in boardingGateDict.Values)
        {
            if (boardingGate.flight == null) continue; // Skip if no flight assigned
            else if (boardingGate.flight.FlightNumber == flight.FlightNumber)
            {
                bg = boardingGate.gateName; // Stores Gate Name
            }
        }
        // Displaying the flight details
        Console.WriteLine($"{flight.FlightNumber,-15}{flight.Origin,-20}{flight.Destination,-20}{flight.ExpectedTime.ToString("dd/MM/yyyy h:mm tt"),-25}{flight.Status,-10}{SRC,-25}{bg,-15}");
    }
}
// Modify Flight Details (Basic Feature 8)
void ModifyFlightDetails(Dictionary<string, Flight> flightDict)
{
    //Display Airlines
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine($"{"Airline Code",-15}{"Airline Name",-20}");
    foreach (var airline in airlineDict.Values)
    {
        Console.WriteLine($"{airline.code,-15}{airline.name,-20}");
    }
    // User Input to choose the Airline
    Console.Write("Enter Airline Code: ");
    string airlineCode = Console.ReadLine().Trim();
    if (!airlineDict.ContainsKey(airlineCode))
    {
        Console.WriteLine("Airline not found!");
        return;
    }
    //Display Flights of the chosen Airline
    Console.WriteLine($"List of Flights for {airlineDict[airlineCode].name}:");
    Console.WriteLine($"{"Flight Number",-15}{"Origin",-20}{"Destination",-20}{"Expected Time",-15}");
    Dictionary<string, Flight> chosenAirline = new Dictionary<string, Flight>();
    foreach (var f in airlineDict[airlineCode].flights.Values)
    {
        chosenAirline.Add(f.FlightNumber, f);
        Console.WriteLine($"{f.FlightNumber,-15}{f.Origin,-20}{f.Destination,-20}{f.ExpectedTime.ToString("dd/MM/yyyy h:mm tt"),-15}");
    }
    //User Input to choose the Flight
    Console.Write("Choose an existing Flight to modify or delete: ");
    string flightNumber = Console.ReadLine().Trim();
    if (!chosenAirline.ContainsKey(flightNumber))
    {
        Console.WriteLine("Flight not found!");
        return;
    }
    Flight flight = flightDict[flightNumber]; // Selected Flight
    Console.WriteLine("1. Modify Flight\r\n2. Delete Flight\r\nChoose an option: "); // Getting user input
    string option = Console.ReadLine().Trim();
    if (option == "1")
    {
        Console.WriteLine("1. Modify Basic Information\r\n2. Modify Status\r\n3. Modify Special Request Code\r\n4. Modify Boarding Gate\r\nChoose an option:"); // User Input
        string choice = Console.ReadLine().Trim();
        if (choice == "1")
        {
            Console.Write("Enter new Origin: ");
            flight.Origin = Console.ReadLine().Trim();
            Console.Write("Enter new Destination: ");
            flight.Destination = Console.ReadLine().Trim();
            Console.Write("Enter Expected Departure/Arrival Time (dd/MM/yyyy HH:mm): ");
            string expectedTimeInput = Console.ReadLine().Trim();

            // Parse the input using the correct format (allow single-digit day and month)
            DateTime expectedTime;
            if (!DateTime.TryParseExact(expectedTimeInput, "d/M/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out expectedTime))
            {
                Console.WriteLine("Invalid date/time format. Please use the format dd/MM/yyyy HH:mm.");
                return;
            }
        }
        else if (choice == "2")
        {
            Console.WriteLine("1. Delayed\r\n2. Boarding\r\n3. On Time\r\nPlease select the new status of the flight:");
            string statuschoice = Console.ReadLine();
            if (statuschoice == "1")
            {
                flight.Status = "Delayed";
            }
            else if (statuschoice == "2")
            {
                flight.Status = "Boarding";
            }
            else if (statuschoice == "3")
            {
                flight.Status = "On Time";
            }
            else
            {
                Console.WriteLine("Invalid choice!");
                return;
            }
        }
        else if (choice == "3")
        {
            Console.Write("Enter Special Request Code (CFFT/DDJB/LWTT/None): ");
            string specialRequestCode = Console.ReadLine().Trim().ToUpper();
            switch (specialRequestCode)
            {
                case "CFFT":
                    flight = new CFFTFlight(flightNumber, flight.Origin, flight.Destination, flight.ExpectedTime);
                    break;
                case "DDJB":
                    flight = new DDJBFlight(flightNumber, flight.Origin, flight.Destination, flight.ExpectedTime);
                    break;
                case "LWTT":
                    flight = new LWTTFlight(flightNumber, flight.Origin, flight.Destination, flight.ExpectedTime);
                    break;
                default:
                    flight = new NormFlight(flightNumber, flight.Origin, flight.Destination, flight.ExpectedTime);
                    break;
            }
        }
        else if (choice == "4")

        {
            Console.Write("Enter Boarding Gate to assign flight to: ");
            string gateName = Console.ReadLine();
            if (!boardingGateDict.ContainsKey(gateName))
            {
                Console.WriteLine("Boarding Gate not found!");
                return;
            }
            BoardingGate gate = boardingGateDict[gateName];
            gate.flight = flight;
        }
        else Console.WriteLine("Invalid choice!");
        string SRC;
        if (flight is CFFTFlight)
        {
            SRC = "CFFT";
        }
        else if (flight is DDJBFlight)
        {
            SRC = "DDJB";
        }
        else if (flight is LWTTFlight)
        {
            SRC = "LWTT";
        }
        else
        {
            SRC = "None";
        }
        string bg = "Unassigned";
        foreach (var boardingGate in boardingGateDict.Values)
        {
            if (boardingGate.flight == null) continue; // Skip if no flight assigned
            else if (boardingGate.flight.FlightNumber == flight.FlightNumber)
            {
                bg = boardingGate.gateName; // Stores Gate Name
            }
        }
        Console.WriteLine("Flight updated!");
        // Displaying the new updated Flight details with Basic Information of all Flights
        Console.WriteLine($"Flight Number: {flight.FlightNumber}");
        Console.WriteLine($"Airline Name: {airlineDict[airlineCode].name}");
        Console.WriteLine($"Origin: {flight.Origin}");
        Console.WriteLine($"Destination: {flight.Destination}");
        Console.WriteLine($"Expected Time: {flight.ExpectedTime}");
        Console.WriteLine($"Status: {flight.Status}");
        Console.WriteLine($"Special Request Code: {SRC}");
        Console.WriteLine($"Boarding Gate: {bg}");
    }
    else if (option == "2")
    {
        airlineDict[airlineCode].flights.Remove(flightNumber);
        flightDict.Remove(flightNumber);
        Console.WriteLine("Flight deleted!");
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}
// Display Flight Schedule in chronological order  (Basic Feature 9)
void DisplayFlightSchedule(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict, Dictionary<string, BoardingGate> boardingGateDict)
{

    Console.WriteLine($"{"Flight Number",-15}{"Airline Name",-20}{"Origin",-20}{"Destination",-20}{"Expected Departure/Arrival Time",-35}{"Status",-30}{"Boarding Gate",-25}");

    // Sort flights by ExpectedTime using IComparable<Flight>
    var sortedFlights = flightDict.Values.OrderBy(f => f).ToList();

    foreach (var flight in sortedFlights)
    {
        // Retrieve the airline name from the airline dictionary
        string airlineCode = flight.FlightNumber.Split(' ')[0];
        string airlineName = airlineDict.ContainsKey(airlineCode) ? airlineDict[airlineCode].name : "Unknown Airline";

        // Retrieve the boarding gate for the flight
        string boardingGate = "Unassigned";
        foreach (var gate in boardingGateDict.Values)
        {
            if (gate.flight != null && gate.flight.FlightNumber == flight.FlightNumber)
            {
                boardingGate = gate.gateName;
                break;
            }
        }

        // Format the expected time as "dd/MM/yyyy hh:mm:ss tt"
        string formattedTime = flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm:ss tt");

        // Display the flight details
        Console.WriteLine($"{flight.FlightNumber,-15}{airlineName,-20}{flight.Origin,-20}{flight.Destination,-20}{formattedTime,-35}{flight.Status,-30}{boardingGate,-12}");
    }
}


// Bulk Assign Gates (Advanced Features)
void BulkAssignGates(Dictionary<string, Flight> flightDict, Dictionary<string, BoardingGate> boardingGateDict)
{
    Queue<Flight> unassignedFlightsqueue = new Queue<Flight>();  // Initialize a queue to store unassigned flights
    List<BoardingGate> availableGates = new List<BoardingGate>();  // Initialize a list to store available boarding gates
    foreach (var boardingGate in boardingGateDict.Values)   // Loop through the boarding gates to find the ones that are not assigned to any flight
    {
        if (boardingGate.flight == null)
        {
            availableGates.Add(boardingGate);
        }
        else continue;  // Skip gates already assigned to a flight
    }
    //add all unassigned flights to queue
    foreach (var flight in flightDict.Values)
    {
        if (!boardingGateDict.Values.Any(gate => gate.flight == flight)) //// If the flight is not already assigned to a gate, add it to the queue
        {
            unassignedFlightsqueue.Enqueue(flight);
        }
    }
    // Output the number of unassigned flights and gates
    Console.WriteLine($"Total Number of Unnasigned Flights: {unassignedFlightsqueue.Count}");
    Console.WriteLine($"Total Number of Unnasigned Boarding Gates: {availableGates.Count}");
    Console.WriteLine($"{"Flight Number",-15}{"Airline Name",-20}{"Origin",-20}{"Destination",-20}{"Expected Departure/Arrival Time",-35}{"Special Request Code",-25}{"Boarding Gate",-15}");
    int assigned = 0;
    foreach (var flight in unassignedFlightsqueue)
    {
        string SRC;
        var compatibleGate = availableGates.FirstOrDefault(g => // Check for compatibility between the flight type and the gate
        (flight is CFFTFlight && g.supportCFFT) ||
        (flight is DDJBFlight && g.supportsDDJB) ||
        (flight is LWTTFlight && g.supportsLWTT) ||
        flight is NormFlight);


        if (compatibleGate != null)
        {
            assigned++; // Increment the assigned counter
            compatibleGate.flight = flight; // Assign the flight to the gate
            availableGates.Remove(compatibleGate); // Remove the gate from the available list
        }
        if (flight is CFFTFlight) // Set the special request code based on the type of flight
        {
            SRC = "CFFT";
        }
        else if (flight is DDJBFlight)
        {
            SRC = "DDJB";
        }
        else if (flight is LWTTFlight)
        {
            SRC = "LWTT";
        }
        else
        {
            SRC = "None";
        }
        // Extract the airline code from the flight number (e.g., "SQ 115" -> "SQ")
        string airlineCode = flight.FlightNumber.Split(' ')[0];

        // Retrieve the airline name from the airline dictionary
        string airlineName = airlineDict.ContainsKey(airlineCode) ? airlineDict[airlineCode].name : "Unknown Airline";
        Console.WriteLine($"{flight.FlightNumber,-15}{airlineName,-20}{flight.Origin,-20}{flight.Destination,-20}{flight.ExpectedTime.ToString("dd/MM/yyyy h:mm tt"),-35}{SRC,-25}{(compatibleGate != null ? compatibleGate.gateName : "Unassigned"),-15}");
    }
    Console.WriteLine($"Total Number of Flights and Boarding Gates assigned: {assigned}");
    Console.WriteLine($"Total number of Flights and Boarding Gates that were processed automatically over those that were already assigned: {((decimal)assigned / (decimal)flightDict.Count) * 100:0.00}%");
}
// Calculate Fees (Advanced Features)
void CalculateFees(Dictionary<string, Airline> airlineDict, Dictionary<string, BoardingGate> boardingGateDict, Dictionary<string, Flight> flightDict)
{
    // Check if all flights have been assigned boarding gates
    var unassignedFlights = flightDict.Values.Where(f => !boardingGateDict.Values.Any(g => g.flight != null && g.flight.FlightNumber == f.FlightNumber)).ToList();
    if (unassignedFlights.Any())
    {
        Console.WriteLine("The following flights have not been assigned boarding gates:");
        foreach (var flight in unassignedFlights)
        {
            Console.WriteLine($"- {flight.FlightNumber}");
        }
        Console.WriteLine("Please assign boarding gates to all flights before running this feature again.");
        return;
    }

    double totalSubtotalFees = 0; // Total fees for all airlines
    double totalSubtotalDiscounts = 0; // Total discounts for all airlines

    Console.WriteLine("\nCalculating fees for all airlines...");
    Console.WriteLine("=============================================");

    foreach (var airline in airlineDict.Values)
    {
        double subtotalFees = 0; // Subtotal fees for the current airline
        double subtotalDiscounts = 0; // Subtotal discounts for the current airline
        int flightCount = airline.flights.Count; // Number of flights for the airline
        int earlyLateCount = 0; // Count of flights departing/arriving before 11 AM or after 9 PM
        int specialOriginCount = 0; // Count of flights with special origins (DXB, BKK, NRT)
        int noRequestCount = 0; // Count of normal flights (no special requests)

        Console.WriteLine($"\nAirline: {airline.name}");
        Console.WriteLine("=============================================");

        foreach (var flight in airline.flights.Values)
        {
            double flightFee = 0; // Fee for the current flight

            // Apply base fees based on origin and destination
            if (flight.Origin == "Singapore (SIN)") flightFee += 800; // Departure fee
            if (flight.Destination == "Singapore (SIN)") flightFee += 500; // Arrival fee

            // Apply special request fees
            if (flight is CFFTFlight) flightFee += 150;
            else if (flight is DDJBFlight) flightFee += 300;
            else if (flight is LWTTFlight) flightFee += 500;

            // Apply boarding gate base fee
            var assignedGate = boardingGateDict.Values.FirstOrDefault(g => g.flight != null && g.flight.FlightNumber == flight.FlightNumber);
            if (assignedGate != null)
            {
                flightFee += 300; // Boarding gate base fee
            }

            subtotalFees += flightFee; // Add to subtotal fees

            // Count discounts
            if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour >= 21) earlyLateCount++; // Early/late flights
            if (flight.Origin.Contains("(DXB)") || flight.Origin.Contains("(BKK)") || flight.Origin.Contains("(NRT)")) specialOriginCount++; // Special origins
            if (flight is NormFlight) noRequestCount++; // Normal flights

            Console.WriteLine($"Flight {flight.FlightNumber}: ${flightFee:F2}");
        }

        // Calculate discounts
        subtotalDiscounts = (flightCount / 3) * 350 + // Discount for every 3 flights
                            earlyLateCount * 110 + // Discount for early/late flights
                            specialOriginCount * 25 + // Discount for special origins
                            noRequestCount * 50; // Discount for normal flights

        if (flightCount > 5)
        {
            subtotalDiscounts += subtotalFees * 0.03; // Additional 3% discount for airlines with more than 5 flights
        }

        double finalTotal = subtotalFees - subtotalDiscounts; // Final total after discounts

        Console.WriteLine("=============================================");
        Console.WriteLine($"Subtotal Fees: ${subtotalFees:F2}");
        Console.WriteLine($"Subtotal Discounts: ${subtotalDiscounts:F2}");
        Console.WriteLine($"Final Total: ${finalTotal:F2}");

        // Add to overall totals
        totalSubtotalFees += subtotalFees;
        totalSubtotalDiscounts += subtotalDiscounts;
    }

    // Display overall totals
    Console.WriteLine("\nOverall Totals for Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine($"Total Subtotal Fees: ${totalSubtotalFees:F2}");
    Console.WriteLine($"Total Subtotal Discounts: ${totalSubtotalDiscounts:F2}");
    Console.WriteLine($"Final Total Fees: ${totalSubtotalFees - totalSubtotalDiscounts:F2}");
    Console.WriteLine($"Percentage of Discounts: {(totalSubtotalDiscounts / (totalSubtotalFees - totalSubtotalDiscounts)) * 100:F2}%");
}
//void CalculateFees(Dictionary<string, Airline> airlineDict)
//{
//    foreach (var airline in airlineDict.Values)
//    {
//        double totalFees = 0; // Initialize total fees
//        int flightCount = airline.flights.Count; // Get the number of flights for the airline
//        int earlyLateCount = 0; // Count of early or late flights
//        int specialOriginCount = 0; // Count of flights with special origins
//        int noRequestCount = 0; // Count of normal flights with no special requests
//        foreach (var flight in airline.flights.Values)
//        {
//            totalFees += flight.CalculateFees();

//            // Count discounts
//            if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour >= 21) earlyLateCount++;
//            if (flight.Origin.Contains("(DXB)") || flight.Origin.Contains("(BKK)") || flight.Origin.Contains("(NRT)")) specialOriginCount++;
//            if (flight is NormFlight) noRequestCount++;
//        }
//        // Apply discounts
//        double discounts = (flightCount / 3) * 350 +
//                          earlyLateCount * 110 +
//                          specialOriginCount * 25 +
//                          noRequestCount * 50;

//        if (flightCount > 5)
//            discounts += totalFees * 0.03;
//        Console.WriteLine($"{airline.name} - Total Fees: {totalFees:C2}");
//        Console.WriteLine($"Discounts Applied: {discounts:C2}");
//        Console.WriteLine($"Net Total: {totalFees - discounts:C2}\n");
//    }
//}

// Additional Feature (c): Flight status trend statistics - Dylan Leong
void ShowFlightStatusTrendAnalysis(Dictionary<string, Flight> flightDict)
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Flight Status Trend Analysis");
    Console.WriteLine("=============================================");

    // Track status changes over time
    var statusChanges = new List<(string FlightNumber, string FromStatus, string ToStatus, DateTime TimeChanged)>();
    foreach (var flight in flightDict.Values)
    {
        // Simulate status changes (for demonstration purposes)
        if (flight.Status == "Delayed")
        {
            statusChanges.Add((flight.FlightNumber, "On Time", "Delayed", flight.ExpectedTime.AddMinutes(-30)));
        }
        else if (flight.Status == "Boarding")
        {
            statusChanges.Add((flight.FlightNumber, "On Time", "Boarding", flight.ExpectedTime.AddMinutes(-15)));
        }
    }

    var statusTransitions = statusChanges // Group status changes by transition type and calculate the average time spent in each transition
        .GroupBy(sc => $"{sc.FromStatus} → {sc.ToStatus}")
        .Select(g => new
        {
            Transition = g.Key,
            Count = g.Count(),
            AverageTime = g.Average(sc => (DateTime.Now - sc.TimeChanged).TotalMinutes)
        })
        .OrderByDescending(g => g.Count)
        .ToList();

    // Display status transitions
    Console.WriteLine("\nStatus Transitions:");
    foreach (var transition in statusTransitions)
    {
        Console.WriteLine($"  - {transition.Transition}: {transition.Count} flights (Avg Time: {transition.AverageTime:F2} minutes)");
    }

    // Calculate average time spent in each status
    var statusDurations = new Dictionary<string, List<double>>();
    foreach (var flight in flightDict.Values)
    {
        if (!statusDurations.ContainsKey(flight.Status))
        {
            statusDurations[flight.Status] = new List<double>();
        }
        // Simulate time spent in status (for demonstration purposes)
        statusDurations[flight.Status].Add((DateTime.Now - flight.ExpectedTime).TotalMinutes);
    }

    Console.WriteLine("\nAverage Time Spent in Each Status:");
    foreach (var status in statusDurations)
    {
        Console.WriteLine($"  - {status.Key}: {status.Value.Average():F2} minutes");
    }

    // Display most frequent status transitions
    var mostFrequentTransition = statusTransitions.FirstOrDefault();
    if (mostFrequentTransition != null)
    {
        Console.WriteLine($"\nMost Frequent Status Transition: {mostFrequentTransition.Transition} ({mostFrequentTransition.Count} flights)");
    }

    Console.WriteLine($"\nTotal Flights: {flightDict.Count}");
}

// Additional Feature (d): Flight Search by Origin/Destination - ISAAC LUM
void SearchFlightsByOriginDestination(Dictionary<string, Flight> flightDict)
{
    Console.Write("Enter Origin or Destination: "); // Prompt the user to input a search term (either origin or destination)
    string searchTerm = Console.ReadLine().Trim();
    var matchingFlights = flightDict.Values // Search for flights that match the search term in either origin or destination
        .Where(f => f.Origin.Contains(searchTerm) || f.Destination.Contains(searchTerm))
        .OrderBy(f => f.ExpectedTime);

    Console.WriteLine($"{"Flight Number",-15}{"Airline Name",-20}{"Origin",-20}{"Destination",-20}{"Expected Time",-20}{"Status",-15}"); //output results found
    foreach (var flight in matchingFlights)
    {
        string airlineName = flight.FlightNumber.Split(' ')[0];
        Console.WriteLine($"{flight.FlightNumber,-15}{airlineName,-20}{flight.Origin,-20}{flight.Destination,-20}{flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm tt"),-20}{flight.Status,-15}");
    }
}