using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ISerialNumberChecker
    {
        bool SerialNumberValidation(SerialNumbers number);
    }
}
