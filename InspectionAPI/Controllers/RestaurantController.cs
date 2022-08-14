using InspectionAPI.Data;
using InspectionAPI.Models;
using InspectionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AccountsService accountsService;
        public RestaurantController(DataContext db, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, AccountsService accountsService)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            this.accountsService = accountsService;
        }

        //Restaurant/GetAllRestaurants
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            //returns with a list of all the restaurants
            var result = _db.Restaurants.ToList();
            return Ok(result);
        }

        //Restaurant/GetRestaurantById
        [HttpGet]
        [Route("{restaurantId}")]
        public IActionResult GetRestaurantById(int restaurantId)
        {
            //returns with a list of all the restaurants
            var result = _db.Restaurants.Where(r => r.Id == restaurantId).FirstOrDefault();
            return Ok(result);
        }

        //Restaurant/GetRestaurantById
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetRestaurantByUserId(string userId)
        {
            //returns with a list of all the restaurants
            var result = _db.Restaurants.Where(r => r.UserId == userId).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost]
        //[Authorize(Roles = "Owner")]
        public IActionResult RegisterRestaurant([FromBody] Restaurant restaurant)
        {
            //TODO: check if User has Owner or Admin UserType
            //TODO: check if restaurant already exists
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddFood([FromBody] Food food)
        {
            /*var restaurant = _db.Restaurants.Where(r => r.Id == food.RestaurantId).FirstOrDefault();
            Food _food = new Food()
            {
                Name = food.Name,
                Price = food.Price,
                PreparationTime = food.PreparationTime,
                Allergenes = food.Allergenes,
                DiscountMultiplier = food.DiscountMultiplier
            };
            restaurant.Foods = new List<Food>();
            restaurant.Foods.Add(_food);*/
            _db.Foods.Add(food);
            _db.SaveChanges();
            return Ok();
        }

        //Restaurant/GetAllFoods
        [HttpGet]
        public IActionResult GetAllFoods()
        {
            //returns with a list of all the restaurants
            var result = _db.Foods.ToList();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Restaurant restaurant)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(Restaurant restaurant)
        {
            return NoContent();
        }
    }
}
