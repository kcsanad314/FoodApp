namespace InspectionAPI.Models
{
    public class Status
    {
        public int Id { get; set; }

        [StringLenght(20)]
        public string StatusOption { get; set; } = string.Empty;
    }
}
