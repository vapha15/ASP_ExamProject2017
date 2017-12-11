using System.Collections.Generic;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SerialNumbersContext : ISerialNumberContext
    {
        private int Numbers = 101;
        public List<SerialNumbers> listSerialNumbers { get; set; }

        public SerialNumbersContext()
        {
            listSerialNumbers = new List<SerialNumbers>();
        }

        //creates a new serialnumberlist with numbers from 1-100..this method is only loaded one time in the life cyklus of this application. when all numbers have been used, ic can be loaded again

        public void CreateNewSerialNumberList()
        {
            SerialNumbers newSerialNumbers;
            for (int i = 1; i < Numbers; i++)
            {
                newSerialNumbers = new SerialNumbers(i);
                listSerialNumbers.Add(newSerialNumbers);
            }


        }


        //return the serialnumberList
        public List<SerialNumbers> GetSerialNumbersList()
        {

            return listSerialNumbers;
        }

    }
}
