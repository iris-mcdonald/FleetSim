using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetSim.Objects
{
    public class Car : Vehicle, ICar
    {
        private string _modelYear;
        public string ModelYear
        {
            get => _modelYear; set => _modelYear = value;
        }

        private string _model;
        public string Model
        {
            get => _model; set => _model = value;
        }

        public override int Mileage//overrides virtual base class Vehicle property
        {
            get
            {
                return _mileage;

            }

            set
            {
                if (value > 100000)
                {
                    RebuildEngine(value);
                    value = 0;
                                        
                }

                else
                    if ((value - LastServicedMileage) > 30000)
                {
                    TuneUp(value);
                    UpdateServicedDate();
                }

                _mileage = value;
            }
        }

        public override string LastServicedDate
        {
            get
            {
                return _lastServicedDate;
            }
            set
            {
                _lastServicedDate = value;
            }
        }
        private bool _engineRebuilt;
        public bool EngineRebuilt
        {
            get => _engineRebuilt; set => _engineRebuilt = value;
        }
        
        //following are the Class Car constructors; they are overloaded
        public Car()
        {

        }

        public Car(string _modelName)
        {

        }

        public Car(string _modelName, string _carColor)
        {
        }

        public void RebuildEngine(int miles)//implements the ICar method
        {
            LastServicedMileage = 0;
            EngineRebuilt = true;
            UpdateServicedDate();
            /*Console.WriteLine("Vehicle " + ModelYear + " " + Model +
                                " engine rebuilt at " + LastServicedMileage
                                 + " Miles " + miles + " on date: " + LastServicedDate);*/

        }

        public void UpdateServicedDate()
        {
            DateTime now = DateTime.Now;
            string date1 = (now.ToString("M/dd/yyyy h:mm:ss.fff.tt"));
            LastServicedDate = date1;
        }

        
    }
}

