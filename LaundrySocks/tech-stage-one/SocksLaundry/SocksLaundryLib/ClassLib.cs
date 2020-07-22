using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SocksLaundryLib
{
    public class ClassLib
    {

        //Do not delete or edit this method, you can only modify the block
        public int GetMaximumPairOfSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            // You can edit from here down 
            // get clean pairs
            var cleanPairs = GetDuplicate(cleanPile);
            var cleanPairSum = cleanPairs.Sum(a => a.Count);
            var cleanPileFromPairs = cleanPairs.SelectMany(a => a.Items).ToList();

            var leftOfNeatPile = RemoveItemsFromItems(cleanPileFromPairs, cleanPile.ToList());
            //recommended socks to wash 
            //var neatPileInDirtyPile = dirtyPile.ToList().Intersect(leftOfNeatPile).ToList();  //recommended socks to wash  and pair up
            var neatPileInDirtyPile = dirtyPile.ToList().Where(a => leftOfNeatPile.Contains(a)).ToList(); //recommended socks to wash  and pair up
            var leftOfDirtyPile = RemoveItemsFromItems(neatPileInDirtyPile, dirtyPile.ToList()); //alternatives socks if washing machine can accomodate more 
             if (noOfWashes <= 0) return cleanPairSum;
             if (noOfWashes <= neatPileInDirtyPile.Count())
             {
               var selectToWash =   neatPileInDirtyPile.Take(noOfWashes).ToList();
               selectToWash.AddRange(leftOfNeatPile);
               var wash = WashPilesOrPair(selectToWash);
               return GetSockPair(wash) +cleanPairSum; 
             }
             else
             {
                neatPileInDirtyPile.AddRange(leftOfNeatPile);
                leftOfDirtyPile.AddRange(neatPileInDirtyPile);
                var duplicatesOnly = GetDuplicate(leftOfDirtyPile.ToArray());
                var items = duplicatesOnly.SelectMany(a => a.Items);
                var wash = WashPilesOrPair(items.Take(noOfWashes).ToList());
                return GetSockPair(wash) + cleanPairSum;
             }
          
        }

        /**
         * You can create various helper methods
         * */ 

         List<DuplicatePairs> GetDuplicate(int[] ar)
        {
            Array.Sort(ar);

            int noOfPair = 0,  i=0; 
            List<DuplicatePairs> pairs = new List<DuplicatePairs>();
            // var currentItem = "";
            while (i < ar.Length)
            {
                //check for out of range 
                var range = i + 1;
                if (range < ar.Length)
                {
                    if (ar[i] == ar[i + 1])
                    {
                        var currentPair = pairs.Find(a => a.Item == ar[i]);
                        if (currentPair == null)
                        {
                            // add new current pair 
                            pairs.Add(new DuplicatePairs()
                            {
                                Item = ar[i], 
                                Count = 1,
                                Items = new List<int>(){ar[i],ar[i]} // its a pair
                            });

                        }
                        else
                        {
                            currentPair.Count++; 
                           currentPair.Items.AddRange(new List<int>(){ar[i],ar[i]}); // its a pair
                        }
                        //set duplicate pair
                        noOfPair += 1;
                        //set i to the next index
                        i = i + 1 + 1;

                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    break;
                }
              
            }
    
            return pairs;
        }

        List<int> GetPair(int[] ar)
        {
            List<DuplicatePairs> pilesOrPairs = new List<DuplicatePairs>();
            List<int> pair = new List<int>();
            foreach (var i in ar)
            {
                var current = pilesOrPairs.Find(a => a.Item == i);
                if (current == null)
                {
                    pilesOrPairs.Add(new DuplicatePairs()
                    {
                        Item = i,
                        Count = 1,
                        Items = new List<int>(i)
                        
                    });
                    pair.Add(i);
                }
                else
                {
                    if (current.Count < 2)
                    {
                        pair.Add(i);
                        current.Count++;
                        current.Items.Add(i);
                    }
                    continue;
                   
                }


            }
            return pair;
          
        }
        List<DuplicatePairs> WashPilesOrPair(List<int> piles)
        {
            List<DuplicatePairs> pilesOrPairs = new List<DuplicatePairs>();
            piles.Sort();
            foreach (var pile in piles)
            {
                var current = pilesOrPairs.Find(a => a.Item == pile);
                if (current == null)
                {
                    pilesOrPairs.Add(new DuplicatePairs()
                    {
                        Item = pile,
                        Count = 1
                    });
                }
                else
                {
                    current.Count++;
                }

            }

            return pilesOrPairs;
        }

        int GetSockPair(List<DuplicatePairs> duplicatePairses)
        {
            var selectPairs = duplicatePairses.Where(a =>  a.Count >=2).ToList();
            var pairs = selectPairs.Sum(a=>a.Count/2);

            return pairs;
        }

        List<int> RemoveItemsFromItems(List<int> items1, List<int> items2)
        {

            foreach (var item1 in items1)
            {
                items2.Remove(item1);
             
            }

            return items2;
        }
        
    }

    class DuplicatePairs
    {
        public int Item { get; set; }
        public int Count { get; set; }

        public List<int> Items { get; set; }

    }
}
