using System;
using System.Collections.Generic;
using System.Linq;
using TestletRandomizer.BL.Constants;
using TestletRandomizer.BL.CustomExceptions;
using TestletRandomizer.BL.Extensions;
using TestletRandomizer.BL.Interfaces;
using TestletRandomizer.Model;

namespace TestletRandomizer.BL.Services
{
    public class TestletRandomizerService : ITestletRandomizerService
    {
        private readonly Random _random;

        public TestletRandomizerService()
        {
            _random = new Random();
        }

        public IList<Item> RandomizeTestletItems(IList<Item> testletItems)
        {
            VerifyTestletItemsStructure(testletItems);
            return GetRandomizedItems(testletItems, _random);
        }

        private void VerifyTestletItemsStructure(IList<Item> testletItems)
        {
            if (testletItems == null)
            {
                throw new ArgumentNullException(nameof(testletItems));
            }

            if (testletItems.Count == 0)
            {
                throw new TestletRandomizerException("Nothing to randomize. Testlet items list is empty");
            }

            var expectedTotalItemsCount = TestletRandomizerConstants.PRETEST_ITEMS_COUNT + TestletRandomizerConstants.OPERATIONAL_ITEMS_COUNT;
            if (testletItems.Count != expectedTotalItemsCount)
            {
                throw new TestletRandomizerException($"Wrong amount of items in testlet. There must be {expectedTotalItemsCount} items in total" +
                                                     $" but item list contains {testletItems.Count} items");
            }

            var itemsCountsByType = testletItems.GroupBy(item => item.ItemType).ToDictionary(x => x.Key, x => x.Count());

            itemsCountsByType.TryGetValue(ItemTypeEnum.Pretest, out var realPretestItemsCount);
            itemsCountsByType.TryGetValue(ItemTypeEnum.Operational, out var realOperationalItemsCount);

            if (realPretestItemsCount != TestletRandomizerConstants.PRETEST_ITEMS_COUNT)
            {
                throw new TestletRandomizerException($"There must be {TestletRandomizerConstants.PRETEST_ITEMS_COUNT} pretest items but found {realPretestItemsCount}");
            }

            if (realOperationalItemsCount != TestletRandomizerConstants.OPERATIONAL_ITEMS_COUNT)
            {
                throw new TestletRandomizerException($"There must be {TestletRandomizerConstants.OPERATIONAL_ITEMS_COUNT} operational items but found {realOperationalItemsCount}");
            }
        }

        private IList<Item> GetRandomizedItems(IList<Item> testletItems, Random random)
        {
            var shuffledArray = testletItems.ToArray();
            shuffledArray.Shuffle(random);
            var result = new Item[testletItems.Count];
            var itemIndex = 0;
            var pretestItemIndex = 0;

            foreach (var item in shuffledArray)
            {
                if (item.ItemType == ItemTypeEnum.Pretest && pretestItemIndex < TestletRandomizerConstants.STARTING_PRETEST_ITEMS_COUNT)
                {
                    result[pretestItemIndex] = item;
                    pretestItemIndex++;
                }
                else
                {
                    result[itemIndex + TestletRandomizerConstants.STARTING_PRETEST_ITEMS_COUNT] = item;
                    itemIndex++;
                }
            }
            return result;
        }
    }
}