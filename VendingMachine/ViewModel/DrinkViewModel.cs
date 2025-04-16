namespace test_task.ViewModel
{
    public class DrinkViewModel
    {
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsSelected { get; set; }
    }
}