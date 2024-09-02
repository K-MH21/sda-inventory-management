namespace InventoryManagement
{
    public class Store
    {
        private List<Item> _inventoryItems;
        private int _capacity,
            _currentLoad;

        public Store(int capacity)
        {
            _capacity = capacity;
            _inventoryItems = new List<Item>(_capacity);
            _currentLoad = 0;
        }

        public void AddItem(Item item)
        {
            if (_inventoryItems.Any(existingItem => existingItem.Name == item.Name))
            {
                throw new ArgumentException("Item exists");
            }

            _currentLoad += item.Quantity;
            if (_capacity <= _currentLoad)
            {
                _currentLoad -= item.Quantity;
                throw new InvalidOperationException("Cannot add more items: capacity is full.");
            }

            _inventoryItems.Add(item);
        }

        public void DeleteItem(Item item)
        {
            if (!_inventoryItems.Remove(item))
            {
                throw new InvalidOperationException("Item not found");
            }
            _currentLoad -= item.Quantity;
        }

        public int GetCurrentVolume()
        {
            int volume = 0;
            foreach (Item item in _inventoryItems)
            {
                volume += item.Quantity;
            }
            return volume;
        }

        public Item FindItemByName(string name)
        {
            Item? item = _inventoryItems.FirstOrDefault(item => item.Name.Equals(name));

            if (item == null)
            {
                throw new InvalidOperationException("Item not found");
            }

            return item;
        }

        public void SortByNameAsc()
        {
            _inventoryItems.Sort((x, y) => x.Name.CompareTo(y.Name));
        }

        public List<Item> SortByDate(SortOrder order)
        {
            switch (order)
            {
                case SortOrder.DESC:
                    return _inventoryItems.OrderByDescending(x => x.CreatedDate).ToList();
                case SortOrder.ASC:
                    return _inventoryItems.OrderBy(x => x.CreatedDate).ToList();
            }
            throw new Exception("Error");
        }

        public Dictionary<string, List<Item>> GroupByDate()
        {
            Dictionary<string, List<Item>> groups = [];
            groups.Add(
                "New Arrival", // These should be -3, but made them +3 to test this function
                _inventoryItems.FindAll(item => item.CreatedDate >= DateTime.Now.AddMonths(3))
            );

            groups.Add(
                "Old",
                _inventoryItems.FindAll(item => item.CreatedDate < DateTime.Now.AddMonths(3))
            );
            return groups;
        }
    }
}
