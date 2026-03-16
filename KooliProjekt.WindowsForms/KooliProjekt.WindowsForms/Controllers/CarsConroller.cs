using Microsoft.AspNetCore.Mvc; 
[ApiController] 
[Route("api/[controller]")] 
public class CarsController : ControllerBase 
{ 
static List<Car> cars = new List<Car>(); 
[HttpGet] 
public IEnumerable<Car> Get() 
{ 
} 
return cars; 
[HttpPost] 
public void Post(Car car) 
{ 
} 
cars.Add(car); 
 
    [HttpPut("{id}")] 
    public void Put(int id, Car car) 
    { 
        var existing = cars.FirstOrDefault(x => x.Id == id); 
        if (existing != null) 
        { 
            existing.Model = car.Model; 
            existing.Year = car.Year; 
        } 
    } 
 
    [HttpDelete("{id}")] 
    public void Delete(int id) 
    { 
        var car = cars.FirstOrDefault(x => x.Id == id); 
        if (car != null) 
            cars.Remove(car); 
    } 
} 
