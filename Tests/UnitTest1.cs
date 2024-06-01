using csharp;
using Xunit;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void QualityAllvaysPositive()
    {
        var ZeroQualityElementInput = new List<Item>()
        {
            new Item() { Name = "TestName", Quality = 0, SellIn = 22}
        }; 
        var sut = new GildedRose(ZeroQualityElementInput);
        
        sut.UpdateQuality();
        

        Assert.True(ZeroQualityElementInput.All(ex => ex.Quality >= 0));

    }
}