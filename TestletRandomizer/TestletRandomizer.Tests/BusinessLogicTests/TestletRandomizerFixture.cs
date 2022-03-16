using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestletRandomizer.BL.Constants;
using TestletRandomizer.BL.CustomExceptions;
using TestletRandomizer.BL.Services;
using TestletRandomizer.Model;
using TestletRandomizer.Tests.TestConstants;

namespace TestletRandomizer.Tests.BusinessLogicTests
{
    [TestClass]
    public class TestletItemsRandomizationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItemListIsNull()
        {
            var testletRandomizerService = new TestletRandomizerService();
            testletRandomizerService.RandomizeTestletItems(TestletConstants.TestletWithNullItems.Items);
        }

        [TestMethod]
        [ExpectedException(typeof(TestletRandomizerException))]
        public void ItemListIsEmpty()
        {
            var testletRandomizerService = new TestletRandomizerService();
            testletRandomizerService.RandomizeTestletItems(TestletConstants.TestletWithEmptyItems.Items);
        }

        [TestMethod]
        [ExpectedException(typeof(TestletRandomizerException))]
        public void ItemListWrongLength()
        {
            var testletRandomizerService = new TestletRandomizerService();
            testletRandomizerService.RandomizeTestletItems(TestletConstants.TestletWithWrongAmountOfItems.Items);
        }

        [TestMethod]
        [ExpectedException(typeof(TestletRandomizerException))]
        public void ItemListWrongAmountOfPretestItems()
        {
            var testletRandomizerService = new TestletRandomizerService();
            testletRandomizerService.RandomizeTestletItems(TestletConstants.TestletWithWrongAmountOfPretestItems.Items);
        }


        [TestMethod]
        [ExpectedException(typeof(TestletRandomizerException))]
        public void ItemListWrongAmountOfOperationalItems()
        {
            var testletRandomizerService = new TestletRandomizerService();
            testletRandomizerService.RandomizeTestletItems(TestletConstants.TestletWithWrongAmountOfOperationalItems.Items);
        }

        [TestMethod]
        public void CorrectResultLength()
        {
            var testletRandomizerService = new TestletRandomizerService();
            var result = testletRandomizerService.RandomizeTestletItems(TestletConstants.ValidTestlet.Items);
            Assert.AreEqual(TestletConstants.ValidTestlet.Items.Count, result.Count);
        }


        [TestMethod]
        public void AllStartingItemsArePretests()
        {
            var testletRandomizerService = new TestletRandomizerService();
            var result = testletRandomizerService.RandomizeTestletItems(TestletConstants.ValidTestlet.Items);
            Assert.IsTrue(result.Take(TestletRandomizerConstants.STARTING_PRETEST_ITEMS_COUNT).All(x => x.ItemType == ItemTypeEnum.Pretest));
        }

        [TestMethod]
        public void NoDuplicatesInRandomizedList()
        {
            var testletRandomizerService = new TestletRandomizerService();
            var result = testletRandomizerService.RandomizeTestletItems(TestletConstants.ValidTestlet.Items);
            var initialItemIdList = TestletConstants.ValidTestlet.Items.Select(x => x.ItemId).OrderBy(id => id).ToList();
            var resultIdList = result.Select(x => x.ItemId).OrderBy(id => id).ToList();
            Assert.IsTrue(initialItemIdList.SequenceEqual(resultIdList));
        }


        [TestMethod]
        public void ItemsAreRandomizedDifferentlyInСonsequentCalls()
        {
            var testletRandomizerService = new TestletRandomizerService();
            var result1 = testletRandomizerService.RandomizeTestletItems(TestletConstants.ValidTestlet.Items);
            var result2 = testletRandomizerService.RandomizeTestletItems(TestletConstants.ValidTestlet.Items);
            var result1IdList = result1.Select(x => x.ItemId).ToList();
            var result2IdList = result2.Select(x => x.ItemId).ToList();
            Assert.IsTrue(!result1IdList.SequenceEqual(result2IdList));
        }
    }
}