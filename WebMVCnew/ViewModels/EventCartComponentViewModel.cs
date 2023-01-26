namespace WebMVCnew.ViewModels
{
    public class EventCartComponentViewModel
    {
        public int ItemsInCart { get; set; }
        public decimal TotalCost { get; set; }
        public string Disabled => (ItemsInCart == 0) ? "is-disabled" : "";
    }
}
