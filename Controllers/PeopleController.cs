using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PersonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {

        private static List<People> ListOfPeople = new List<People>();
        

        [HttpGet()]
        public List<People> GetAll()
        {
            return ListOfPeople;
        }

        [HttpGet("filter-via-firstname/{name}")]
        public List<People> GetViaFirstName(string name)
        {
            List<People> filteredList = new List<People>();
            foreach(var person in ListOfPeople)
            {
                if(person.FirstName == name)
                {
                    filteredList.Add(person);
                }
            }
            return filteredList;
        }

        [HttpGet("filter-via-lastname/{name}")]
        public List<People> GetViaLastName(string name)
        {
            List<People> filteredList = new List<People>();
            foreach (var person in ListOfPeople)
            {
                if (person.LastName == name)
                {
                    filteredList.Add(person);
                }
            }
            return filteredList;
        }

        [HttpGet("filter-via-age/{age}")]
        public List<People> GetViaAge(int age)
        {
            List<People> filteredList = new List<People>();
            foreach (var person in ListOfPeople)
            {
                if (person.Age == age)
                {
                    filteredList.Add(person);
                }
            }
            return filteredList;
        }

        [HttpPost()]
        public HttpResponseMessage Post([FromBody] People value)
        {
            ListOfPeople.Add(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost("populate")]
        public HttpResponseMessage PostExamples()
        {
            ListOfPeople.Add(PeopleFactory.ValerioCaporali);
            ListOfPeople.Add(PeopleFactory.MauroCotoletta);
            ListOfPeople.Add(PeopleFactory.CristianoOrologius);
            ListOfPeople.Add(PeopleFactory.DiegoKaiman);
            ListOfPeople.Add(PeopleFactory.ValerioSettimius);
            ListOfPeople.Add(PeopleFactory.DiegoSettimius);
            ListOfPeople.Add(PeopleFactory.GiorgioCaporali);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete("{fiscalCode}")]
        public HttpResponseMessage Delete(string fiscalCode)
        {
            People peopleToRemove = new People();
            foreach (var person in ListOfPeople)
            {
                if (person.FiscalCode == fiscalCode)
                {
                    peopleToRemove = person;
                }
            }
            if (peopleToRemove.FiscalCode != fiscalCode)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            } else
            {
                ListOfPeople.Remove(peopleToRemove);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            
            
        }
    }
}