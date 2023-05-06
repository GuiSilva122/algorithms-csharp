namespace LeetCode.Heap
{
    public class HeapFurthestBuilding
    {
        // Min Heap
        // O(N log N) time, O(N) space
        public int FurthestBuildingV1(int[] heights, int bricks, int ladders)
        {
            var ladderAllocations = new PriorityQueue<int, int>();
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                // If this is actually a "jump down", skip it.
                if (climb <= 0)
                    continue;
                
                ladderAllocations.Enqueue(climb, climb);
                // If we haven't gone over the number of ladders, nothing else to do.
                if (ladderAllocations.Count <= ladders)
                    continue;
                // Otherwise, we will need to take a climb out of ladder_allocations
                bricks -= ladderAllocations.Dequeue();
                // If this caused bricks to go negative, we can't get to i + 1
                if (bricks < 0)
                    return i;
            }
            // If we got to here, this means we had enough materials to cover every climb.
            return heights.Length - 1;
        }

        // Max Heap
        // O(N log N) time, O(N) space
        public int FurthestBuildingV2(int[] heights, int bricks, int ladders)
        {
            var brickAllocations = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                if (climb <= 0)
                {
                    continue;
                }
                // Otherwise, allocate a ladder for this climb.
                brickAllocations.Enqueue(climb, climb);
                bricks -= climb;
                // If we've used all the bricks, and have no ladders remaining, then 
                // we can't go any further.
                if (bricks < 0 && ladders == 0)
                    return i;
                // Otherwise, if we've run out of bricks, we should replace the largest
                // brick allocation with a ladder.
                if (bricks < 0)
                {
                    bricks += brickAllocations.Dequeue();
                    ladders--;
                }
            }
            // If we got to here, this means we had enough materials to cover every climb.
            return heights.Length - 1;
        }

        // Binary Search for Final Reachable Building
        // O (N log^2 N) time, O(N) space
        public int FurthestBuildingV3(int[] heights, int bricks, int ladders)
        {
            // Do a binary search on the heights array to find the final reachable building.
            int lo = 0;
            int hi = heights.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo + 1) / 2;
                if (IsReachable(mid, heights, bricks, ladders))
                    lo = mid;
                else
                    hi = mid - 1;
            }
            return hi; // Note that return lo would be equivalent.
        }

        private bool IsReachable(int buildingIndex, int[] heights, int bricks, int ladders)
        {
            var climbs = new List<int>();
            for (int i = 0; i < buildingIndex; i++)
            {
                int h1 = heights[i];
                int h2 = heights[i + 1];
                if (h2 <= h1)
                    continue;
                
                climbs.Add(h2 - h1);
            }
            climbs.Sort();

            foreach (int climb in climbs)
            {
                if (climb <= bricks)
                    bricks -= climb;
                else if (ladders >= 1)
                    ladders -= 1;
                else
                    return false;
            }
            return true;
        }

        // Improved Binary Search for Final Reachable Building
        // O(N log N) time, O(N) space
        public int FurthestBuildingV4(int[] heights, int bricks, int ladders)
        {
            // Make a sorted list of all the climbs.
            var sortedClimbs = new List<int[]>();
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int climb = heights[i + 1] - heights[i];
                if (climb <= 0)
                    continue;
                sortedClimbs.Add(new int[] { climb, i + 1 });
            }
            sortedClimbs.Sort(Comparer<int[]>.Create((a, b) => a[0] - b[0]));
            // Now do the binary search, same as before.
            int lo = 0;
            int hi = heights.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo + 1) / 2;
                if (IsReachable(mid, sortedClimbs, bricks, ladders))
                    lo = mid;
                else
                    hi = mid - 1;
            }
            return hi; // Note that return lo would be equivalent.
        }

        private bool IsReachable(int buildingIndex, List<int[]> climbs, int bricks, int ladders)
        {
            foreach (int[] climbEntry in climbs)
            {
                // Extract the information for this climb
                int climb = climbEntry[0];
                int index = climbEntry[1];
                // Check if this climb is within the range.
                if (index > buildingIndex)
                    continue;
                // Allocate bricks if enough remain; otherwise, allocate a ladder if
                // at least one remains.
                if (climb <= bricks)
                    bricks -= climb;
                else if (ladders >= 1)
                    ladders -= 1;
                else
                    return false;
            }
            return true;
        }
    }
}