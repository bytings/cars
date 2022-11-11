using cars.Data;
using cars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace cars.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CarsDbContext _context;
        public IEnumerable<Cars> Cars { get; set; } = Enumerable.Empty<Cars>();

        [BindProperty]
        public Cars Car { get; set; }

        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int GuessValue { get; set; } = 0;
        public string Result { get; set; }
        public bool? control { get; set; }

        private List<Cars> listOfCars = new(){
                new Cars { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                new Cars { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
                new Cars { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
                new Cars { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
                new Cars { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 }
            };
        public IndexModel(CarsDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //Cars = _context.Cars;
            
            Cars = listOfCars;

            Options = Cars.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.Id.ToString(),
                                     Text = a.Make
                                 }).ToList();
            control = null;
        }

        public void OnPost()
        {
            if(GuessValue <= Car.Price + 5000 && GuessValue >= Car.Price - 5000)
            { 
                Result = "Great Job, you WIN!";
                control = true;
            }
            else
            {
                Result = "sorry, not this time...";
                control = false;
            }
            
        }      
    }
}