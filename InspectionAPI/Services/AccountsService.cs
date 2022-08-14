using InspectionAPI.Data;
using InspectionAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InspectionAPI.Services
{
    public class AccountsService
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _db;
        private IHttpContextAccessor _httpContextAccessor;
        public AccountsService(DataContext db, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public string getUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
