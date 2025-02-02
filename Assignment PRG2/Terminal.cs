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
        private Dictionary<string, Flight> flights;
        private Dictionary<string, BoardingGate> boardingGate;
        private Dictionary<string, double> gateFees;

        public string TerminalName { get; set; }
        public Dictionary<string, AirLine> AirLines { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public Dictionary<string, BoardingGate> BoardingGate { get; set; }
        public Dictionary<string, double> GateFees { get; set; }

        public Terminal(string terminalName, Dictionary<string, AirLine> air, Dictionary<string, Flight> flight, Dictionary<string, BoardingGate> gate, Dictionary<string, double> fee)
        {
            TerminalName = terminalName;
            AirLines = air;
            Flights = flight;
            BoardingGate = gate;
            GateFees = fee;
        }

        public bool AddAirLine(AirLine airLine)
        {
            if (airLine == null)
            {
                return false;
            }

            string airlineCode = airLine.Name;
            if (AirLines.ContainsKey(airlineCode))
            {
                return false;
            }

            AirLines.Add(airlineCode, airLine);
            return true;
        }

        public bool AddBoardingGate(BoardingGate boardingGate)
        {
            if (boardingGate == null)
            {
                return false;
            }

            string gateNumber = boardingGate.GetName;
            if (BoardingGate.ContainsKey(gateNumber))
            {
                return false;
            }

            BoardingGate.Add(gateNumber, boardingGate);
            return true;
        }

        public AirLine GetAirLineFromFlight(Flight flight)
        {
            if (flight == null)
            {
                return null;
            }

            string airlineCode = flight.FlightNumber;
            if (AirLines.ContainsKey(airlineCode))
            {
                return AirLines[airlineCode];
            }

            return null;
        }

        public void PrintAirLineFees()
        {
           
        }

        public override string ToString()
        {
            return $"Terminal Name: {TerminalName}, Airlines: {AirLines.Count}, Flights: {Flights.Count}, Boarding Gates: {BoardingGate.Count}";
        }
    }
}
