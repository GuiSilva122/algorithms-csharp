namespace LeetCode._75
{
    public class Graph_FloodFill
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var color = image[sr][sc];
            if (color != newColor)
                DeepFirstSearch(image, sr, sc, color, newColor);
            return image;
        }

        private void DeepFirstSearch(int[][] image, int row, int column, int color, int newColor)
        {
            if (image[row][column] == color)
            {
                image[row][column] = newColor;
                if (row - 1 >= 0) DeepFirstSearch(image, row - 1, column, color, newColor);
                if (column - 1 >= 0) DeepFirstSearch(image, row, column - 1, color, newColor);
                if (row + 1 < image.Length) DeepFirstSearch(image, row + 1, column, color, newColor);
                if (column + 1 < image[row].Length) DeepFirstSearch(image, row, column + 1, color, newColor);
            }
        }

        public int MaxNumberOfBalloons(string text)
        {
            int bCount = 0, aCount = 0, lCount = 0, oCount = 0, nCount = 0;
            foreach (var c in text)
            {
                _ = c switch
                {
                    'b' => bCount++,
                    'a' => aCount++,
                    'l' => lCount++,
                    'o' => oCount++,
                    'n' => nCount++,
                    _ => 0
                };
            }
            lCount /= 2;
            oCount /= oCount;
            return Math.Min(bCount, Math.Min(aCount, Math.Min(lCount, Math.Min(oCount, nCount))));
        }
    }
}
