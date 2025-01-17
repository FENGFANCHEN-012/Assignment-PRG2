Console.WriteLine("=============================================\r\nWelcome to Changi Airport Terminal 5\r\n=============================================\r\n1. List All Flights\r\n2. List Boarding Gates\r\n3. Assign a Boarding Gate to a Flight\r\n4. Create Flight\r\n5. Display Airline Flights\r\n6. Modify Flight Details\r\n7. Display Flight Schedule\r\n0. Exit\r\nPlease select your option:\r\n1");
string answer = Console.ReadLine()!;


Dictionary<string,AirLine> airdic = new Dictionary<string,AirLine>();
Dictionary<string,Flight> flightdic = new Dictionary<string, Flight>();
Dictionary<string,BoardingGate> gatedic = new Dictionary<string,BoardingGate>();
string gate = "C:\\Users\\johny\\source\\repos\\Assignment PRG2\\Assignment PRG2\\data\\boardinggates.csv";
string airline = "C:\\Users\\johny\\source\\repos\\Assignment PRG2\\Assignment PRG2\\data\\airlines.csv";
string flight = "C:\\Users\\johny\\source\\repos\\Assignment PRG2\\Assignment PRG2\\data\\flights.csv";
List<string> flightdata = new List<string>(File.ReadLines(flight));
List<string> airdata = new List<string>(File.ReadLines(airline));
List<string> gatedata = new List<string>(File.ReadLines(gate));
foreach (string i in airdata)
{    
    if(airdata.IndexOf(i) == 0)
    {
        continue;
    }
    List<string> data = new List<string>(i.Split(","));
    airdic[data[1]] = new AirLine(data[0], data[1], flightdic);

}
foreach (string i in gatedata)
{
    if (airdata.IndexOf(i) == 0)
    {
        continue;
    }
    List<string> data = new List<string>(i.Split(","));
    foreach (var m in flightdic)
    {


        gatedic[data[1]] = new BoardingGate(data[0],Convert.ToBoolean(data[1]), Convert.ToBoolean(data[2]), Convert.ToBoolean(data[3]), m.Value);
    }
}

foreach (string i in flightdata)
{
    if (airdata.IndexOf(i) == 0)
    {
        continue;
    }
    List<string> data = new List<string>(i.Split(","));
    
    if (data[3] == "")
    {
        flightdic[data[0]] = new NORMFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
    }
    else if (data[3] == "CFFT")
    {
        flightdic[data[0]] = new CFFTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
    }
    else if (data[3] == "LWTT")
    {
        flightdic[data[0]] = new LWTTFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
    }
    else if (data[3] == "DDJB")
    {
        flightdic[data[0]] = new DDJBFlight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
    }


}
if (answer == "1")
{
    foreach(var i in flightdic)
    {

        foreach(var w in airdic)
        {
           if( w.Value.Code == i.Value.FlightNumber.Substring(0, 2))
            {
                Console.WriteLine($"{}");
            }
        }
    }
}