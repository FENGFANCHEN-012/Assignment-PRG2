


using System.Net.NetworkInformation;
using System.Xml.Linq;

public class Flight
{
    private string flightNumber;
    private string origin;
    private string destination;
    private DateTime expectedTime;
    private string status;
    public string FlightNumber { set; get; }
    public string Origin { set; get; }
    public string Destination { set; get; }
    public DateTime ExpectedTime { set; get; }
    public string Status { set; get; }

    public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
    {
        FlightNumber= flightNumber;
        Origin= origin;
        Destination= destination;
        ExpectedTime= expectedTime;
        Status= status;
    }
     public double CalculateFees()
    {
        return 
    }
    public override string ToString()
    {
        return base.ToString();
    }

}
public class AirLine
{
    private string name;
    private string code;
    private Dictionary<string, Flight> flights;
     public string Code { get; set; }
    public Dictionary<string, Flight> Flights { get; set; }

    
    public AirLine(string name, string code, Dictionary<string, Flight> flights)
    {
        Name = name;
        Code = code;
        Flights = flights;
    }
}
}
public class BoardingGate
{
    private string getName;
    private bool supportsCFFT;
    private bool supportsDDJB;
    private bool supportsLWTT;
    private Flight flight;
    public string Name { get; set; }
    public bool SupportsCFFT { get; set; }
    public bool SupportsDDJB { get; set; }
    public bool SupportsLWTT { get; set; }

    public Flight Flight { set; get; }

    public BoardingGate(string name,bool supportsCFFT, bool supportsDDJB, bool supportsLWTT,Flight flight)
    {
        Name= name;
        SupportsCFFT= supportsCFFT;
        SupportsDDJB= supportsDDJB;
        SupportsLWTT= supportsLWTT;
        Flight= flight;
    }
   

    public double CalculateFees()
    {
        return 
    }
    public override string ToString()
    {
        return base.ToString();
    }


}

public class Terminal
{
    private string terminalName;
    private Dictionary<string,AirLine>
}