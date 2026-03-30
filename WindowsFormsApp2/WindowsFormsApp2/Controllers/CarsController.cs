using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WindowsFormsApp2.Models;

namespace WindowsFormsApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { Id = 1, Brand = "BMW", Model = "320" },
            new Car { Id = 2, Brand = "Audi", Model = "A4" },
            new Car { Id = 3, Brand = "Mercedes", Model = "C200" },
            new Car { Id = 4, Brand = "Volkswagen", Model = "Passat" },
            new Car { Id = 5, Brand = "Toyota", Model = "Camry" },
            new Car { Id = 6, Brand = "Honda", Model = "Accord" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            car.Id = cars.Any() ? cars.Max(c => c.Id) + 1 : 1;
            cars.Add(car);
            return Ok(car);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Car updated)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();

            car.Brand = updated.Brand;
            car.Model = updated.Model;

            return Ok(car);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();

            cars.Remove(car);
            return Ok();
        }
    }
}