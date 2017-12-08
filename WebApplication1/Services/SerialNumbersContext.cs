using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SerialNumbersContext
    {
        private int Numbers = 100;
        public List<SerialNumbers> listSerialNumbers { get; set; }

        public SerialNumbersContext()
        {
            listSerialNumbers = new List<SerialNumbers>();
        }

        public void CreateNewSerialNumberList()
        {
            SerialNumbers newSerialNumbers;
            for (int i = 0; i <Numbers ; i++)
            {
                newSerialNumbers = new SerialNumbers(i);
                listSerialNumbers.Add(newSerialNumbers);
            }
          

        }



        public List<SerialNumbers> GetSerialNumbersList()
        {

            return listSerialNumbers;
        }

    }
}
