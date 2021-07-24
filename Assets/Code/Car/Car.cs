using Assets.Code.Upgrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Car
{
    class Car : IUpgradableCar
    {
        private readonly float _defaultSpeed;

        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        public float Speed 
        {
            get;set;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}
