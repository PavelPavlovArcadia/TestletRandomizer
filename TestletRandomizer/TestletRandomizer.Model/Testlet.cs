using System.Collections.Generic;

namespace TestletRandomizer.Model
{
    public class Testlet
    {
        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }

        public string TestletId { get; set; }

        public List<Item> Items { get; }
    }
}