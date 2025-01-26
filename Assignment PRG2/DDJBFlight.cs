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

    public class DDJBFlight : Flight
    {
        private double requestFee;
        public double RequestFee { set; get; }
        public DDJBFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status) : base(flightNumber, origin, destination, expectedTime, status)
        {
            RequestFee = requestFee;
        }
        public  double CalculateFees()
        {
            return 1;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
