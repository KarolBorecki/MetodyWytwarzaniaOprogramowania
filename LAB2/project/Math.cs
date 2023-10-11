using System;

namespace Math.Services
{
    public class MathService
    {
        public bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }
            throw new NotImplementedException("Not fully implemented.");
        }

        public bool IsDivideableBy2(int number)
        {
            return number %2 == 0;
        }
    }
}