using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PersonListContext
    {

        private List<Persons> list { get; set; }

        public PersonListContext()
        {
            list = new List<Persons>();
        }

        //add person to the personList
        public void AddPersonToList(Persons newPerson)
        {
            if (newPerson != null)
            {
                list.Add(newPerson);
            }



        }

        //returns the personlist
        public List<Persons> GetPersonList()
        {

            return list;
        }


    }
}
