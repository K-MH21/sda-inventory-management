namespace InventoryManagement
{
    public class Item
    {
        private string _name = string.Empty;
        private int _quantity;
        private DateTime _createdDate;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }
                _quantity = value;
            }
        }

        public DateTime CreatedDate
        {
            get => _createdDate;
            set
            {
                if (DateTime.Compare(value.ToUniversalTime(), DateTime.Now.ToUniversalTime()) >= 0)
                {
                    throw new ArgumentException("Date cannot be from the past");
                }

                _createdDate = value;
            }
        }

        public Item(string name, int quantity)
            : this(name, quantity, DateTime.Now) { }

        public Item(string name, int quantity, DateTime createdDate)
        {
            Name = name;
            Quantity = quantity;
            CreatedDate = createdDate;
        }
    }
}
