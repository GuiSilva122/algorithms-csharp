namespace AlgoExpert
{
    internal class SubSequence
    {
        // O(1) space, O(n) time
        public static bool ValidateSubSequence(int[] array, int[] sequence)
        {
            int indexArray = 0;
            int indexSequence = 0;
            while (indexSequence < sequence.Length && indexArray < array.Length)
            {
                if (sequence[indexSequence] == array[indexArray])
                {
                    indexArray++;
                    indexSequence++;
                }
                else
                {
                    indexArray++;
                }
            }
            return (indexSequence == sequence.Length && indexArray == array.Length);;
        }

        // O(1) space, O(n) time
        public static bool ValidateSubSequence2(List<int> array, List<int> sequence)
        {
            int sequenceIndex = 0;
            foreach (var val in array)
            {
                if (sequenceIndex == sequence.Count)
                    break;
                if (sequence[sequenceIndex] == val)
                    sequenceIndex++;
            }
            return sequenceIndex == sequence.Count;
        }

        public static void TestSolution()
        {
            int[] array = new int[] { 5, 1, 22, 25, 6, -1, 8, 10 };
            int[] sequence = new int[] { 1, 6, -1, 10 };

            var result = ValidateSubSequence(array, sequence);
        }
    }
}
