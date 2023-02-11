namespace AlgoExpert
{
    internal class SortedSquaredArray
    {
        // O(n) time, O(n) space
        public static int[] GetSortedSquaredArray(int[] array)
        {
            var sortedArray = new int[array.Length];

            int left = 0;
            int right = array.Length - 1;
            int sortedIndex = array.Length - 1;

            while (left <= right)
            {
                int leftValue = array[left] * array[left];
                int rightValue = array[right] * array[right];

                if (leftValue > rightValue)
                {
                    sortedArray[sortedIndex--] = leftValue;
                    left++;
                }
                else
                {
                    sortedArray[sortedIndex--] = rightValue;
                    right--;
                }
            }
            return sortedArray;
        }

        // O(nlogn) time | O(n) space
        public int[] GetSortedSquaredArray2(int[] array)
        {
            var sortedArray = new int[array.Length];

            for(int i = 0; i < array.Length; i++)            
                sortedArray[i] = array[i] * array[i];

            Array.Sort(sortedArray);
            return sortedArray;
        }

        public static void TestSolution()
        {
            int[] array = new int[] { 1, 2, 3, 5, 6, 8, 9 };
            var result = GetSortedSquaredArray(array);
        }
    }
}
