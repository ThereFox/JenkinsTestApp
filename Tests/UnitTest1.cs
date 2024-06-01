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

    [Fact]
    public void LegendaryItemNotModificated()
    {
        //arrange
        var initData = new List<Item>()
        {
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
        };
        var sut = new GildedRose(initData);
        
        //act
        sut.UpdateQuality();
        
        //assert
        Assert.True(initData.All(_ => _.Quality == 80));
    }

    [Fact]
    public void WorkWithConjuredItems()
    {
        //arrange
        var initItem = new List<Item>()
        {
            new Item() { Name = "Conjured", Quality = 10, SellIn = 10}
        };
        var sut = new GildedRose(initItem);
        
        //act
        sut.UpdateQuality();
        
        //assert
        Assert.True(initItem[0].Quality == 8);
        
    }
    
}