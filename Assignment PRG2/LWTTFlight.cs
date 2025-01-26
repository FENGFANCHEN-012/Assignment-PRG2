using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S12345678
// Student Name   : Michael Jordan
// Partner Name   : Scottie Pippen
//==========================================================


namespace Assignment_PRG2
{
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
            return 1;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
