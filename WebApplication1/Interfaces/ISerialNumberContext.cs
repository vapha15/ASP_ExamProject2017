
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ISerialNumberContext
    {

        void CreateNewSerialNumberList();
        List<SerialNumbers> GetSerialNumbersList();
    }
}