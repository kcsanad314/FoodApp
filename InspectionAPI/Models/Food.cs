using System.ComponentModel.DataAnnotations;

namespace InspectionAPI.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PreparationTime { get; set; }
        public string Allergenes { get; set; }
        public double DiscountMultiplier { get; set; } = 1;
        public int FoodCategoryId { get; set; } 
    }
}
