using Microsoft.AspNetCore.Mvc; 
 using MyApi.Data; 
 using MyApi.Models; 
  
  namespace MyApi.Controllers
{ 
     [ApiController]
      [Route("api/[controller]")] 
     public class CarsController : ControllerBase 
     { 
         //    GET kõik 
         [HttpGet] 
         public ActionResult<IEnumerable<Car>> GetCars()
         { 
             return Ok(CarRepository.Cars); 
         } 
  
         //    GET ühe järgi 
         [HttpGet("{id}")] 
         public ActionResult<Car> GetCar(int id)
         { 
             var car = CarRepository.Cars.FirstOrDefault(c => c.Id == id); 
                 
             if (car == null) 
return NotFound(); 
  
             return Ok(car); 
         }

		//    POST (lisa)
		[HttpPost] 
         public ActionResult<Car> AddCar(Car car)
         { 
             car.Id = CarRepository.Cars.Max(c => c.Id) + 1; 
             CarRepository.Cars.Add(car); 
  
             return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car); 
         } 
  
         //    PUT (uuenda) 
         [HttpPut("{id}")] 
         public IActionResult UpdateCar(int id, Car updatedCar)
         { 
             var car = CarRepository.Cars.FirstOrDefault(c => c.Id == id);                  
             if (car == null) 
return NotFound(); 
  
             car.Make = updatedCar.Make;
			car.Model = updatedCar.Model; 
             car.Year = updatedCar.Year; 
  
             return NoContent(); 
         } 
  
         //    DELETE (kustuta) 
         [HttpDelete("{id}")] 
         public IActionResult DeleteCar(int id)
         { 
             var car = CarRepository.Cars.FirstOrDefault(c => c.Id == id); 
                 
             if (car == null) 
return NotFound(); 
  
             CarRepository.Cars.Remove(car); 
             return NoContent(); 
         } 
     } 
 } 