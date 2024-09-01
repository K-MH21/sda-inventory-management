namespace InventoryManagement
{
    public class Item
    {
        private string name { set; get; }
        private int quantity { set; get; }
        private DateTime createdDate { set; get; }

        public Item(string name, int quantity)
            : this(name, quantity, DateTime.Now) { }

        public Item(string name, int quantity, DateTime createdDate)
        {
            this.name = name;
            this.quantity = quantity;
            this.createdDate = createdDate;
        }
    }
}
