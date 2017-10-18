using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class TestController : ApiController
    {
        List<Car> cars = new List<Car>()
        {
            new Car() {  Brand = "Opel",Name="Astra", HorsePowers = 100 },
            new Car() {  Brand = "Opel",Name="Antera", HorsePowers = 150 },
            new Car() {  Brand = "VW",Name="Golf", HorsePowers = 120 }
        };

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }


        public IHttpActionResult GetCar(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("Name must have a value");

            var car = cars.Where(x => x.Name == id).FirstOrDefault();
            if (car == null) return NotFound();

            return Ok(car);
        }
    }
}

