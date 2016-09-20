using System;

// TODO: add unit tests for GeneratePrimeNumber and IsPrime.
namespace PrimeNumbersApp
{
    public class PrimeNumberEventArgs : EventArgs
    {
        public PrimeNumberEventArgs(int number)
        {
            PrimeNumber = number;
        }

        public int PrimeNumber { get; set; }
    }

    public class PrimeGenerator
    {
        public event EventHandler<PrimeNumberEventArgs> PrimeNumberGenerated;

        public int GeneratePrimeNumber(int number)
        {
            while (!IsPrime(number))
            {
                number++;
            }
            PrimeNumberEventArgs args = new PrimeNumberEventArgs(number);
            OnThresholdReached(args);
            return number;
        }

        protected virtual void OnThresholdReached(PrimeNumberEventArgs e)
        {
            EventHandler<PrimeNumberEventArgs> handler = PrimeNumberGenerated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public bool IsPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
