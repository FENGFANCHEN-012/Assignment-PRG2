


using System.Net.NetworkInformation;
using System.Xml.Linq;

public  class Flight
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
    public abstract double CalculateFees()
    {

    }
    
    public override string ToString()
    {
        return base.ToString();
    }

}






public class NORMFlight : Flight
{    

    public NORMFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status) :base( flightNumber, origin, destination, expectedTime, status)
    {

    }

    public override double CalculateFees()
    {
        return
    }
    public override string ToString()
    {
        return base.ToString();
    }
}
public class CFFTFlight : Flight
{
    private double requestFee;
    public double RequestFee { set; get; }
    public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status) : base(flightNumber, origin, destination, expectedTime, status) 
    {
        RequestFee= requestFee;
    }
    public override double CalculateFees() { 

    }
    public override string ToString()
    {
        return base.ToString();
    }
}

public class LWTTFlight : Flight
{
    private double requestFee;
    public double RequestFee { set; get; }
    public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status) : base(flightNumber, origin, destination, expectedTime, status)
    {
        RequestFee = requestFee;
    }
    public override double CalculateFees()
    {

    }
    public override string ToString()
    {
        return base.ToString();
    }
}

public class DDJBFlight : Flight
{
    private double requestFee;
    public double RequestFee { set; get; }
    public DDJBFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status) : base(flightNumber, origin, destination, expectedTime, status)
    {
        RequestFee = requestFee;
    }
    public override double CalculateFees()
    {

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
    public string Name { get;set; }
    public bool AddFlight(Flight flights)
    {

    }

    public double CalculateFees()
    {
        return 
    }
    public bool RemoveFlight()
    {
        return 
    }
    
    
    public AirLine(string name, string code, Dictionary<string, Flight> flights)
    {
        Name = name;
        Code = code;
        Flights = flights;
    }
    public override string ToString()
    {
        return base.ToString();
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
    private Dictionary<string, AirLine> airLines;
        private Dictionary<string, AirLine> flights;
    private Dictionary<string,BoardingGate> boardingGate;
    private Dictionary<string, double> gateFees;
    public string TerminalName { get; set; }
    public Dictionary<string, AirLine> AirLines { get; set; }
    public Dictionary<string, AirLine> Flights { get; set; }
    public Dictionary<string, BoardingGate> BoardingGate { get; set; }
    public Dictionary<string, double> GateFees { get; set; }

    public bool AddAirLine(AirLine airLine)
    {
        return
    }
    public bool AddBoardingGate(BoardingGate boardingGate) { 
        return 
    }
    public AirLine GetAirLineFromFlight(Flight flight)
    {
        return 
    }
    public void PrintAirLineFees()
    {

    }

    public Terminal(string terminalName)
    {
        TerminalName = terminalName;
        AirLines = new Dictionary<string, AirLine>();
        Flights = new Dictionary<string, AirLine>();
        BoardingGate = new Dictionary<string, BoardingGate>();
        GateFees = new Dictionary<string, double>();
    }

    public override string ToString()
    {
        return base.ToString();
    }

}