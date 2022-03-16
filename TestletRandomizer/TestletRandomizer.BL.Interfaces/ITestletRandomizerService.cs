using System.Collections.Generic;
using TestletRandomizer.Model;

namespace TestletRandomizer.BL.Interfaces
{
    public interface ITestletRandomizerService
    {
        IList<Item> RandomizeTestletItems(IList<Item> testletItems);
    }
}