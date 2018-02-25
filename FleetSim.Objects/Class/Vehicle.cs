using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetSim.Objects
{
    public abstract class Vehicle : IVehicle
    {
        private Guid _vin;
        public Guid VIN
        {
            get
            {
                return _vin;
            }
            set
            {
                value = GetGuid();
                _vin = value;
            }
        }
        protected int _mileage;
        public virtual int Mileage//virtual so can override w/logic in Cars Class
        { get; set; }

        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        /*public static DateTime Today { get; }*///if just wanted current date w/no time
        protected string _lastServicedDate;
        public virtual string LastServicedDate
        { get; set; }

        private int _lastServicedMileage;
        public int LastServicedMileage
        {
            get
            {
                return _lastServicedMileage;
            }
            set
            {
                _lastServicedMileage = value;
            }
        }

        public void TuneUp(int miles)//implements IVehicle interface method
        {
            LastServicedMileage = miles;
            Console.WriteLine("Vehicle " + "model year " + "model " +
                        "VIN# " + VIN + " tuned up at" + LastServicedMileage
                             + " Miles" + " on date: ");
        }

        public Guid GetGuid()
        {
            Guid g;
            // Create a GUID.
            g = Guid.NewGuid();
            return g;
        }

        enum ColorChoice : byte
        {
            red = 1,
            white = 2,
            blue = 3
        }
    }

}

