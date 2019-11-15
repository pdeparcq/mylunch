using System.Collections.Generic;
using Guards;
using Kledex.Domain;

namespace MyLunch.Domain.Menu
{
    public class Tag : ValueObject
    {
        public string Text { get; private set; }

        public Tag(string text)
        {
            Guard.ArgumentNotNullOrEmpty(() => text);

            Text = text.ToLower();
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Text;
        }
    }
}
