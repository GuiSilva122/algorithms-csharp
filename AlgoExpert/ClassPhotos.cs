namespace AlgoExpert
{
    internal class ClassPhotos
    {
        public static bool GetIsClassPhotosAllowed(List<int> redShirtHeights, List<int> blueShirtHeights)
        {
            int init = 0, end = redShirtHeights.Count - 1;
            var (lesserHeights, greaterHeights) = GetOrderedHeights(redShirtHeights, blueShirtHeights);

            if (init == end)
            {
                if (lesserHeights[init] < greaterHeights[init])
                    return true;
                return false;
            }

            while (init < end)
            {
                if (lesserHeights[init] < greaterHeights[init] && lesserHeights[end] < greaterHeights[end])
                {
                    init++;
                    end--;
                }
                else
                    return false;
            }
            return true;
        }

        public static (List<int> lesserHeights, List<int> greaterHeights) GetOrderedHeights(List<int> redShirtHeights, List<int> blueShirtHeights)
        {
            if (redShirtHeights[0] < blueShirtHeights[0])
                return (redShirtHeights, blueShirtHeights);
            return (blueShirtHeights, redShirtHeights);
        }

        public static void TestSolution()
        {
            var blueShirtHeights = new List<int> { 5, 4 };
            var redShirtHeights = new List<int> { 5, 6 };

            var result = GetIsClassPhotosAllowed(redShirtHeights, blueShirtHeights);
        }
    }
}
