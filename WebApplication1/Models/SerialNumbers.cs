using System;

namespace WebApplication1.Models
{
    [Serializable]
    public class SerialNumbers
    {
        public int Number { get; set; }
        public int ThisNumberUsed { get; set; }

        public SerialNumbers(int number)
        {
            Number = number;

        }

        public SerialNumbers()
        {
        }
    }
}
