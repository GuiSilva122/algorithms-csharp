using System.Collections.Generic;
using System.Linq;

namespace AlgoMania
{
    public static class KMostFrequentElement
    {
        /*Dado um array que nunca é vazio, retorne os K elementos mais frequentes do mesmo.
        Exemplos
        Entrada: [1, 1, 1, 3, 3, 5, 6, 7, 8, 9, 10] -> K = 2

        Saída: [1, 3]
        Explicação: Os 2 números mais frequentes são 1 e 3.
        */

        //O(n log n)
        public static List<int> kMostFrequentElementV1(List<int> numbers, int k)
        {
            Dictionary<int, int> hash = new();
            //O(n)
            foreach (int num in numbers)
            {
                if (!hash.ContainsKey(num))
                    hash[num] = 0;
                hash[num] += 1;
            }

            var result = hash
                .OrderByDescending(x => x.Value) //O(n log n)
                .ToDictionary(x => x.Key, x => x.Value)
                .Keys
                .Take(k) //O(k)
                .ToList();

            return result;
        }

        //O(n log k) (With Heap, not implemented here because .Net does not have an built in Heap data structure)
        
        //O(n)
        public static List<int> kMostFrequentElementV3(List<int> numbers, int k)
        {
            Dictionary<int, int> hash = new();
            //O(n)
            foreach (int num in numbers)
            {
                if (!hash.ContainsKey(num))
                    hash[num] = 0;
                hash[num] += 1;
            }

            //O(n)
            Dictionary<int, List<int>> frequency = new();
            foreach (var item in hash)
            {
                if (!frequency.ContainsKey(item.Value))
                    frequency[item.Value] = new List<int>();
                
                frequency[item.Value].Add(item.Key);
            }

            //O(n)
            List<int> result = new();
            foreach (int number in Enumerable.Range(0, numbers.Count + 1).Reverse())
                if (frequency.ContainsKey(number))
                    result.AddRange(frequency[number]);

            result = result
                .Take(k)
                .ToList();

            return result;
        }
    }
}