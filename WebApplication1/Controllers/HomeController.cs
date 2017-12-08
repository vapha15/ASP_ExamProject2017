using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Services;




namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        //private List<Persons> listPerson = new List<Persons>();
        //  private string XMLFileName = "C:\\Users\\Nam\\documents\\visual studio 2017\\Projects\\WebApplication1\\WebApplication1\\Files\\PersonListXML.xml";

        private readonly PersonListContext _personContext;
        private readonly SerialNumbersContext _serialNumbersContext;
        private readonly XMLSerialization _XMLSerializer;


        public HomeController()
        {
            _personContext = new PersonListContext();
            _XMLSerializer = new XMLSerialization();

            _serialNumbersContext = new SerialNumbersContext();




        }
        public IActionResult Index()
        {

            return View();
        }



        public IActionResult Formula()
        {
            ViewData["Header"] = "Welcome to Person Registration Form.";
            ViewData["Info"] = "Please enter your info";

            return View();
        }

        public IActionResult Succes()
        {
            ViewData["Header"] = "Submission succeded.";


            return View();
        }


        [HttpPost]
        public IActionResult Submit(WebApplication1.Models.Persons viewModel)
        {


            if (ModelState.IsValid)
            {
                var newPerson = new Persons
                {
                    FirstName = viewModel.FirstName,
                    SurName = viewModel.SurName,
                    Email = viewModel.Email,
                    BirthDay = viewModel.BirthDay,
                    SerialNumber = viewModel.SerialNumber,
                    Phone = viewModel.Phone
                };


                _serialNumbersContext.CreateNewSerialNumberList();
                var serialNumberList = _serialNumbersContext.GetSerialNumbersList();


                _XMLSerializer.Serialize(serialNumberList, _XMLSerializer.GetXMLSerialNumberListFileName());

                var personXMLList = _XMLSerializer.GetXMLPersonListFileName();
                // listPerson.AddRange(_XMLSerializer.Deserialize(XMLFileName));
                _personContext.GetPersonList().AddRange(_XMLSerializer.Deserialize<Persons>(personXMLList));


                _personContext.AddPersonToList(newPerson);


                var personList = _personContext.GetPersonList();
                var XMLPersonListFileName = _XMLSerializer.GetXMLPersonListFileName();
                //_XMLSerializer.Serialize(_personContext.GetPersonList(), XMLFileName);
                _XMLSerializer.Serialize(personList, XMLPersonListFileName);
                return RedirectToAction("Succes", "Home");

            }

            return View("Formula");

        }


        public IActionResult List()
        {

            ViewData["Header"] = "The submission list";

            // listPerson.AddRange(_XMLSerializer.Deserialize(XMLFileName));
            var XMLPersonListFileName = _XMLSerializer.GetXMLPersonListFileName();
            _personContext.GetPersonList().AddRange(_XMLSerializer.Deserialize<Persons>(XMLPersonListFileName));
            return View(_personContext.GetPersonList());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
