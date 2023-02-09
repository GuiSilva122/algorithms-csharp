Console.WriteLine("Hello, World!");


int[] array = new int[] { 3, 5, -4, 8, 11, 1, -1, 6 };
int targetSum = 10;

var result = TwoSum.Solution1(array, targetSum);

Console.WriteLine(result);

/// <summary>
/// Algorithm 1
/// </summary>
public class TwoSum
{
    // O(1) space, O(n²) time
    public static int[] Solution1(int[] array, int targetSum)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] + array[j] == targetSum)
                    return new int[] { array[i], array[j] };
            }
        }
        return new int[0];
    }

    // O(n) space, O(n) time
    public static int[] Solution2(int[] array, int targetSum)
    {
        HashSet<int> hash = new HashSet<int>();

        for (int i = 0; i < array.Length; i++)
        {
            int potentialMatch = targetSum - array[i];
            if (hash.Contains(potentialMatch))
                return new int[] { array[i], potentialMatch };
            else
                hash.Add(array[i]);
        }
        return new int[0];
    }

    // O(1) space, O(n log n) time
    public static int[] Solution3(int[] array, int targetSum)
    {
        Array.Sort(array);
        int left = 0, right = array.Length - 1;
        while (left < right)
        {
            int sum = array[left] + array[right];
            if (sum == targetSum)
                return new int[] { array[left], array[right] };
            else if (sum > targetSum)
            {
                right--;
            }
            else
            {
                left++;
            }
        }
        return new int[0];
    }
}