using System.Collections.Generic;
using System.Linq;
using Guards;
using Kledex.Domain;

namespace MyLunch.Domain.Menu
{
    public class MenuOption : ValueObject
    {
        public string Title { get; private set; }
        public bool IsRequired { get; private set; }
        public int MaxSelections { get; private set; }
        public List<MenuOptionItem> Items { get; private set; }
        public List<MenuOptionItem> DefaultItems { get; private set; }

        public MenuOption(string title, bool isRequired, int maxSelections, List<MenuOptionItem> items, List<MenuOptionItem> defaultItems)
        {
            Guard.ArgumentNotNullOrEmpty(() => title);
            Guard.ArgumentNotNullOrEmpty(() => items);
            Guard.ArgumentIsGreaterThan(() => maxSelections, 0);
            Guard.ArgumentIsLowerOrEqual(() => maxSelections, items.Count);
            Guard.ArgumentNotNull(() => defaultItems);
            Guard.ArgumentCondition(() => defaultItems, list => list.All(i => items.Contains(i)));

            Title = title;
            IsRequired = isRequired;
            MaxSelections = maxSelections;
            Items = items;
            DefaultItems = defaultItems;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Title;
        }
    }

    public class MenuOptionItem : ValueObject
    {
        public string Name { get; private set; }
        public bool IsAvailable { get; private set; }
        public double Price { get; private set; }

        public MenuOptionItem(string name, bool isAvailable, double price)
        {
            Guard.ArgumentNotNullOrEmpty(() => name);
            Guard.ArgumentIsGreaterOrEqual(() => price, 0);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
}
