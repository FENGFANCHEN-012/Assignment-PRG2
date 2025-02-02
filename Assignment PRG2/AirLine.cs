using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10268902
// Student Name   : CHEN FENGFAN
// Partner Name   : Samuel Tay
//==========================================================


namespace Assignment_PRG2
{
    public class AirLine
    {
        private string name;
        private string code;
        private Dictionary<string, Flight> flights;
        public string Code { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public string Name { get; set; }
        public bool AddFlight(Flight flights)
        {
            
            Flights.Add(flights.FlightNumber, flights);
            return true;
        }

        public double CalculateFees()
        {
            return 1;
        }
        public bool RemoveFlight()
        {
            return false;
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
}
