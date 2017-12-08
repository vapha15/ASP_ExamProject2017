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

        public void AddPersonToList(Persons newPerson)
        {
            list.Add(newPerson);


        }

        public void AddAllPersonToList(List<Persons> list)
        {
            //list.Add(list)


        }


        public List<Persons> GetPersonList()
        {

            return list;
        }


    }
}
