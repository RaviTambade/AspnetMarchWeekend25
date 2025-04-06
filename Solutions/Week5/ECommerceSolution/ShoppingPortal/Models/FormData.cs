namespace ShoppingPortal.Models
{
    public class FormData
    {
        public string SelectedItem { get; set; }
        public string SelectedOption { get; set; }
        public List<string> SelectedPreferences { get; set; } = new List<string>();
    }
}
