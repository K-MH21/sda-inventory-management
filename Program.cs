﻿using System;

namespace InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var waterBottle = new Item("Water Bottle", 10, new DateTime(2025, 1, 1));
            var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2025, 2, 1));
            var notebook = new Item("Notebook", 5, new DateTime(2025, 3, 1));
            var pen = new Item("Pen", 20, new DateTime(2025, 4, 1));
            var tissuePack = new Item("Tissue Pack", 30, new DateTime(2025, 5, 1));
            var chipsBag = new Item("Chips Bag", 25, new DateTime(2025, 6, 1));
            var sodaCan = new Item("Soda Can", 8, new DateTime(2025, 7, 1));
            var soap = new Item("Soap", 12, new DateTime(2025, 8, 1));
            var shampoo = new Item("Shampoo", 40, new DateTime(2025, 9, 1));
            var toothbrush = new Item("Toothbrush", 50, new DateTime(2025, 10, 1));
            var coffee = new Item("Coffee", 20);
            var sandwich = new Item("Sandwich", 15);
            var batteries = new Item("Batteries", 10);
            var umbrella = new Item("Umbrella", 5);
            var sunscreen = new Item("Sunscreen", 8);

            Console.WriteLine("==== Testing ====");
            Console.WriteLine("Item Class");
            Console.WriteLine("1. Correct Behaviour");
            Console.WriteLine($"{waterBottle.Name == "Water Bottle"}");
            Console.WriteLine($"{waterBottle.Quantity == 10}");
            Console.WriteLine($"{waterBottle.CreatedDate == new DateTime(2025, 1, 1)}");

            Console.WriteLine("2. Exceptions");
            // Empty Name
            try
            {
                var invalidItem = new Item("", 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.Contains("Name cannot be empty"));
            }

            // Negative Quantity
            try
            {
                var invalidItem = new Item("Invalid Item", -5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.Contains("Quantity cannot be negative"));
            }

            Console.WriteLine("================");
            Console.WriteLine("Store class");

            var store = new Store(999);

            store.AddItem(waterBottle);
            store.AddItem(chocolateBar);

            // Adding duplicate item
            try
            {
                store.AddItem(new Item("Water Bottle", 5));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.Contains("Item exists"));
            }

            // Get current volume
            Console.WriteLine(store.GetCurrentVolume() == 25);

            // Find item by name
            var foundItem = store.FindItemByName("Chocolate Bar");
            Console.WriteLine(foundItem == chocolateBar);

            // Sort items by name in ascending order
            store.SortByNameAsc();

            // Since sorting doesn't return a value, I need to see it manually
            foreach (
                var item in new[]
                {
                    store.FindItemByName("Chocolate Bar"),
                    store.FindItemByName("Water Bottle"),
                }
            )
            {
                Console.WriteLine(item.Name);
            }

            // Delete an item
            store.DeleteItem(waterBottle);

            // Check if item is deleted by trying to find it
            try
            {
                store.FindItemByName("Water Bottle");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message.Contains("Item not found"));
            }

            // Delete a non-existing item
            try
            {
                store.DeleteItem(waterBottle);
                Console.WriteLine("Non-existing item deleted successfully"); // This should not be printed
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message.Contains("Item not found"));
            }
            Console.WriteLine("==== Test Level 2 | Capacity");
            Store store2 = new Store(20);

            store2.AddItem(waterBottle);
            try
            {
                store2.AddItem(chocolateBar);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message.Contains("Cannot add more items: capacity is full."));
            }

            store2.DeleteItem(waterBottle);
            store2.AddItem(chocolateBar);
            Console.WriteLine(store2.FindItemByName(chocolateBar.Name) == chocolateBar);

            Console.WriteLine("Check ordering\n new item --> water bottle --> Chocolate Bar");
            var store3 = new Store(999);
            store3.AddItem(waterBottle);
            store3.AddItem(chocolateBar);
            store3.AddItem(new Item("New Item", 23));
            var sortedStore3 = store3.SortByDate(SortOrder.ASC);
            foreach (var item in sortedStore3)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("== Now in reverse ==");
            sortedStore3 = store3.SortByDate(SortOrder.DESC);
            foreach (var item in sortedStore3)
            {
                Console.WriteLine(item.Name);
            }

            store = new Store(300);

            store.AddItem(waterBottle);
            store.AddItem(chocolateBar);
            store.AddItem(notebook);
            store.AddItem(pen);
            store.AddItem(tissuePack);
            store.AddItem(chipsBag);
            store.AddItem(sodaCan);
            store.AddItem(soap);
            store.AddItem(shampoo);
            store.AddItem(toothbrush);
            store.AddItem(coffee);
            store.AddItem(sandwich);
            store.AddItem(batteries);
            store.AddItem(umbrella);
            store.AddItem(sunscreen);

            var groupByDate = store.GroupByDate();
            foreach (var group in groupByDate)
            {
                Console.WriteLine($"{group.Key} Items:");
                foreach (var item in group.Value)
                {
                    Console.WriteLine(
                        $" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}"
                    );
                }
            }
        }
    }
}
