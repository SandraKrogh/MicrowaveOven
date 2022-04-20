using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;

        private bool IsOn = false;
        private int powerValue_;

        public PowerTube(IOutput output, int powerValue)
        {
            myOutput = output;
            powerValue_ = powerValue;
            //CookingTime test
        }

        public void TurnOn(int power)
        {
            if (power < 1 || powerValue_ < power)
            {
                throw new ArgumentOutOfRangeException("power", power, "Must be between 1 and powerValue (incl.)");
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}