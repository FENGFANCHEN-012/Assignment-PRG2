using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment_PRG2
{
   public class CFFTFlight : Flight
    {
        private double requestFee;
        public double RequestFee { set; get; }
        public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status) : base(flightNumber, origin, destination, expectedTime, status)
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
