namespace BIWebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TreeNodeId { get; set; } // Foreign key
    }
}
