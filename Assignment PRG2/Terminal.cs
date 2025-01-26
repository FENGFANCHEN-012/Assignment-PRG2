using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//==========================================================
// Student Number : S12345678
// Student Name   : Samuel Tay
// Partner Name   : CHEN FENGFAN
//==========================================================


namespace Assignment_PRG2
{
    public class Terminal
    {
        private string terminalName;
        private Dictionary<string, AirLine> airLines;
        private Dictionary<string, AirLine> flights;
        private Dictionary<string, BoardingGate> boardingGate;
        private Dictionary<string, double> gateFees;
        public string TerminalName { get; set; }
        public Dictionary<string, AirLine> AirLines { get; set; }
        public Dictionary<string, AirLine> Flights { get; set; }
        public Dictionary<string, BoardingGate> BoardingGate { get; set; }
        public Dictionary<string, double> GateFees { get; set; }

        public bool AddAirLine(AirLine airLine)
        {
            return false;
        }
        public bool AddBoardingGate(BoardingGate boardingGate)
        {
            return false;
        }
        /// public AirLine GetAirLineFromFlight(Flight flight)
        ///{
        ///   return 
        ///}
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
}
  
