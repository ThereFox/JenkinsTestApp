using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQuality(item);
            }
        }

        private void UpdateItemQuality(Item item)
        {
            if (isLegendaryItem(item))
            {
                return;
            }
            if (isSpoiledItem(item))
            {
                if (isCheese(item))
                {
                    IncrementQuality(item);
                }
                
                if (isSpeculativeProduct(item))
                {
                    RemoveQuality(item);
                }
            }
            if (isGrowingQualityItem(item))
            {
                GrowItemQuality(item);
                return;
            }
            if (hasQuality(item) == false)
            {
                return;
            }

            DecrementStats(item);

            if (isMagicItem(item))
            {
                DecrementQuality(item);
            }
            
        }

        private bool isMagicItem(Item item)
        {
            return item.Name == "Conjured";
        }
        
        private void DecrementStats(Item item)
        {
            DecrementQuality(item);
            DecrementSellTime(item);
        }

        private void DecrementQuality(Item item)
        {
            if (item.Quality == 0)
            {
                return;
            }

            item.Quality--;
        }

        private void DecrementSellTime(Item item)
        {
            if (item.SellIn == 0)
            {
                return;
            }

            item.SellIn--;
        }
        
        private void GrowItemQuality(Item item)
        {
            IncrementQuality(item);
            if (isSpeculativeProduct(item))
            {
                IncrementSpeculativeItemQuality(item);
            }
        }
        
        private void RemoveQuality(Item item)
        {
            if (item.Quality == 0)
            {
                return;
            }
            
            item.Quality = item.Quality - item.Quality;
            
        }
        
        private void IncrementSpeculativeItemQuality(Item item)
        {
            if (isHotSpeculate(item))
            {
                IncrementQuality(item);
            }

            if (isVeryHotSpeculate(item))
            {
                IncrementQuality(item);
            }
        }

        private bool isHotSpeculate(Item item)
        {
            return item.SellIn <= 10;
        }
        private bool isVeryHotSpeculate(Item item)
        {
            return item.SellIn <= 5;
        }
        
        private void IncrementQuality(Item item)
        {
            if (item.Quality == 50)
            {
                return;
            }

            item.Quality = item.Quality + 1;
        }
        
        private bool isSpoiledItem(Item item)
        {
            return item.SellIn < 0;
        }
        
        private bool isLegendaryItem(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool isGrowingQualityItem(Item item)
        {
            return isCheese(item) && isSpeculativeProduct(item);
        }
        
        private bool isCheese(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private bool isSpeculativeProduct(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool hasQuality(Item item)
        {
            return item.Quality > 0;
        }
    }
}