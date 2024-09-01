namespace InventoryManagement
{
    public class Item
    {
        private string _name = string.Empty;
        private int _quantity;
        private DateTime _createdDate;
        public string Name
        {
            get { return _name; }
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
            get { return _quantity; }
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
            get { return _createdDate; }
            set
            { /*         Should I implement this condition?

                 if (DateTime.Compare(value, DateTime.Now) == 1)
                 {
                     throw new ArgumentException("Date cannot be from the past");
                 }
                 */
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
