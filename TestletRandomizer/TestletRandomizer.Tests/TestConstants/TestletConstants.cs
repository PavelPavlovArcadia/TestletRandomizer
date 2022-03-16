using System.Collections.Generic;
using TestletRandomizer.Model;

namespace TestletRandomizer.Tests.TestConstants
{
    public static class TestletConstants
    {
        public static Testlet TestletWithNullItems => new Testlet("TestletWithNullItems", null);

        public static Testlet TestletWithEmptyItems => new Testlet("TestletWithNullItems", new List<Item>());

        public static Testlet TestletWithWrongAmountOfItems =>
            new Testlet("TestletWithNullItems", new List<Item>
            {
                new Item { ItemId = "item1", ItemType = ItemTypeEnum.Pretest }
            });

        public static Testlet TestletWithWrongAmountOfPretestItems =>
            new Testlet("TestletWithNullItems", new List<Item>
            {
                new Item { ItemId = "item1", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item2", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item3", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item4", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item5", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item6", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item7", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item8", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item9", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item10", ItemType = ItemTypeEnum.Pretest }
            });

        public static Testlet TestletWithWrongAmountOfOperationalItems =>
            new Testlet("TestletWithNullItems", new List<Item>
            {
                new Item { ItemId = "item1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item2", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item3", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item4", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item5", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item6", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item7", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item8", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item9", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item10", ItemType = ItemTypeEnum.Operational }
            });

        public static Testlet ValidTestlet =>
            new Testlet("TestletWithNullItems", new List<Item>
            {
                new Item { ItemId = "item1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item2", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item3", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item4", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item5", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item6", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item7", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item8", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "item9", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "item10", ItemType = ItemTypeEnum.Pretest }
            });
    }
}