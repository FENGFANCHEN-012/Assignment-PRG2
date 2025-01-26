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
    public class BoardingGate
    {
        private string getName;
        private bool supportsCFFT;
        private bool supportsDDJB;
        private bool supportsLWTT;
        private Flight flight;
        public string GetName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }

        public Flight Flight { set; get; }

        public BoardingGate(string name, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT, Flight flight)
        {
            GetName = name;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
            Flight = flight;
        }


        public double CalculateFees()
        {
            return 1;
        }
        public override string ToString()
        {
            return base.ToString();
        }


    }

}
