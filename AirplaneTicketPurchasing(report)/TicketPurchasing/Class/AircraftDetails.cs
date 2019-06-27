using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchasing.Class
{
    class AircraftDetails
    {
        private int id;
        private string cabin;
        private double price;
        private int status;

        public AircraftDetails(string cabin, double price, int status)
        {
            this.id = 0;
            this.cabin = cabin;
            this.price = price;
            this.status = status;
        }

        public AircraftDetails(int id, string cabin, double price, int status)
        {
            this.id = id;
            this.cabin = cabin;
            this.price = price;
            this.status = status;
        }

        public int ID { get { return id; } set { id = value; } }
        public string Cabin { get { return cabin; } set { cabin = value; } }
        public double Price { get { return price; } set { price = value; } }
        public int Status { get { return status; } set { status = value; } }
    }
}
