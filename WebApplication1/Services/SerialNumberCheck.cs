using System.Collections.Generic;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SerialNumberCheck : ISerialNumberChecker
    {
        private List<SerialNumbers> listNumber;


        public SerialNumberCheck()
        {
            listNumber = new List<SerialNumbers>();

            insertNumberToList();

        }

        public bool SerialNumberValidation(SerialNumbers number)
        {

            return listNumber.Contains(number);

        }

        public void insertNumberToList()
        {

            if (listNumber.Count == 0)
            {
                for (int i = 0; i < 100; i++)
                {

                    listNumber[i] = new SerialNumbers(i + 1);
                }
            }
            else
            {
                return;
            }

        }



    }
}
