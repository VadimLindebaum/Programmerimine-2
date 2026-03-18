using MyApi.Models; 
  
  namespace MyApi.Data 
 { 
     public static class CarRepository 
     { 
         public static List<Car> Cars = new List<Car> 
         { 
             new Car { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2020 },
             new Car { Id = 2, Make = "BMW", Model = "X5", Year = 2022 },
             new Car { Id = 3, Make = "Honda", Model = "Civic", Year = 2019 }
		}; 
    } 
} 