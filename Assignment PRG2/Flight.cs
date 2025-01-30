


using System.Net.NetworkInformation;
using System.Xml.Linq;


//==========================================================
// Student Number : S12345678
// Student Name   : Michael Jordan
// Partner Name   : Scottie Pippen
//==========================================================


namespace Assignment_PRG2
{
    public abstract class Flight : IComparable<Flight>
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
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
        }
        public virtual double CalculateFees()
        {
            return 1;
        }
        public int CompareTo(Flight other)
        {
            return this.ExpectedTime.CompareTo(other.ExpectedTime);
        }

        public override string ToString()
        {
            return $"{FlightNumber}\n{Origin}\n{Destination}\n{ExpectedTime}";


        }

    }
}







    
  








    

   