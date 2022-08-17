﻿using HackerHank;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace HackerRank
{
    public static class HackerRank
    {
        static void Main(string[] args)
        {
            var result = CalPoints(new string[] { "5", "2", "C", "D", "+" });
            CountingValleysTest();
        }

        public static int CalPoints(string[] ops)
        {
            List<int> results = new List<int>();
            int index = 0;

            for(int i = 0; i < ops.Length; i++)
            {
                if (ops[i] == "+")
                {
                    int value = results[index -1] + results[index - 2];
                    results.Add(value);
                    index++;
                }
                else if (ops[i] == "D")
                {
                    int value = results[index - 1] * 2;
                    results.Add(value);
                    index++;
                }
                else if (ops[i] == "C")
                {
                    index--;
                    results.RemoveAt(index);
                }
                else
                {
                    results.Add(Convert.ToInt32(ops[i]));
                    index++;
                }
            }
            return results.Sum();
        }

        public static void miniMaxSum(List<int> arr)
        {
            long lesserValue = arr[0];
            long greaterValue = 0;
            long sum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                sum += arr[i];
                if (arr[i] > greaterValue) greaterValue = arr[i];
                if (arr[i] < lesserValue) lesserValue = arr[i];
            }
            Console.WriteLine($"{sum - greaterValue} {sum - lesserValue}");
        }

        public static string timeConversion(string s)
        {
            DateTime dateTime = DateTime.ParseExact(s, "hh:mm:sstt", CultureInfo.InvariantCulture);
            return dateTime.TimeOfDay.ToString();
        }

        public static List<int> breakingRecords(List<int> scores)
        {
            int minimum = scores[0];
            int maximum = scores[0];
            int numberOfMaximumRecords = 0;
            int numberOfMinimumRecords = 0;

            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > maximum)
                {
                    maximum = scores[i];
                    numberOfMaximumRecords++;
                }
                else if (scores[i] < minimum)
                {
                    minimum = scores[i];
                    numberOfMinimumRecords++;
                }
            }
            return new List<int>() { numberOfMaximumRecords, numberOfMinimumRecords };
        }

        public static void CamelCaseOperations(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                var argParts = input.Split(';');
                var operation = argParts[0];
                var type = argParts[1];

                var transformedArg = TransformCamelCase(operation, type, argParts[2]);
                Console.Out.WriteLine(transformedArg);
            }
        }

        private static string TransformCamelCase(string operation, string type, string value)
        {
            if (operation == "S")
            {
                if (type == "M") value = value.Replace("()", "");
                value = String.Join(" ", Regex.Split(value, @"(?<!^)(?=[A-Z])")).ToLower();
                return value;
            }

            int startIndex = 1;
            if (type == "C") startIndex = 0;

            string[] wordsParts = ConvertWordParts(value, startIndex);
            value = String.Join("", wordsParts);

            if (type == "M") value += "()";

            return value;
        }

        private static string[] ConvertWordParts(string words, int startIndex)
        {
            var wordsParts = words.Split(' ');
            for (int i = startIndex; i < wordsParts.Length; i++)
                wordsParts[i] = Char.ToUpperInvariant(wordsParts[i][0]) + wordsParts[i].Substring(1);

            return wordsParts;
        }

        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int count = 0;
            Dictionary<int, int> hm = new Dictionary<int, int>();

            for (int i = 0; i < ar.Count; i++)
            {
                int key = ar[i] % k;
                int antKey = (k - key) % k;

                if (hm.ContainsKey(antKey)) 
                    count += hm[antKey];

                int tempKey = 0;
                hm.TryGetValue(key, out tempKey);
                hm[key] = tempKey + 1;
            }
            return count;
        }

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            var results = new List<int>(queries.Count);

            for (int i = 0; i < queries.Count; i++)
                results.Add(strings.Where(x => x == queries[i]).Count());
            
            return results;
        }

        public static int findMedian(List<int> arr)
        {
            arr.Sort();
            return arr[(int)(arr.Count() / 2) ];
        }

        //Given five positive integers, find the minimum and maximum values that can be calculated
        //by summing exactly four of the five integers. Then print the respective minimum and maximum values as
        //a single line of two space-separated long integers.
        //Example: arr = [1,3,5,7,9], the minimum sum is 16, the maximum sum is 24 
        static void miniMaxSum2(List<int> arr)
        {
            arr.Sort();
            long sumAux = arr[1] + (long)arr[2] + arr[3];
            Console.WriteLine($"{(arr[0] + sumAux)} {(sumAux + arr[4])}");     
        }

        //Given an array of integers, where all elements but one occur twice, find the unique element.
        //Example a = [1,2,3,4,3,2,1]
        //The unique element is 4.
        public static int lonelyinteger(List<int> a)
        {
            int loneValue = a[0];
            for (int i = 1; i < a.Count; i++)
                loneValue ^= a[i];
            return loneValue;
        }

        /*
        HackerLand University has the following grading policy:
        - Every student receives a grade in the inclusive range from 0 to 100.
        - Any grade less than 40 is a failing grade.

        Sam is a professor at the university and likes to round each student's grade according to these rules:
        - If the difference between the and the next multiple of 5 is less than 3, round grade up to the next multiple of 5.
        - If the value of grade is less than 38, no rounding occurs as the result will still be a failing grade.
        
        Examples:
        - grade = 84, round to  (85 - 84 is less than 3)
        - grade = 29, do not round(result is less than 40)
        - grade = 57, do not round(60 - 57 is 3 or higher)
        
        Given the initial value of  for each of Sam's  students, write code to automate the rounding process.
        */
        public static void gradingStudentsTest()
        {
            var grades = new List<int>() { 84, 29, 57 };
            gradingStudentsV1(grades);
        }
        public static List<int> gradingStudentsV1(List<int> grades)
        {
            var finalGrades = new List<int>(grades.Count);

            foreach (var grade in grades)
            {
                if (grade < 38)
                {
                    finalGrades.Add(grade);
                }
                else
                {
                    int nextFiveMultiple = 0;
                    int i = grade + 1;
                    while (nextFiveMultiple == 0)
                    {
                        if (i % 5 == 0) nextFiveMultiple = i;
                        i++;
                    }
                    if ((nextFiveMultiple - grade) < 3)
                        finalGrades.Add(nextFiveMultiple);
                    else
                        finalGrades.Add(grade);
                }
            }

            return finalGrades;
        }

        public static List<int> gradingStudentsV2(List<int> grades)
            => grades.Select(grade => grade >= 38 && grade % 5 >= 3 ? grade + (5 - (grade % 5)) : grade).ToList();

        public static void FlippingBitsTest()
        {
            Console.WriteLine(FlippingBits.flippingBits(1));
        }

        public static void DiagonalDifferenceTest()
        {
            var matrix = new List<List<int>>()
            {
                new List<int> { 11, 02, 04},
                new List<int> { 04, 05, 06 },
                new List<int> { 10, 08, -12 }
            };

            var otherMatrix = new List<List<int>>()
            {
                new List<int> { 1, 2, 3},
                new List<int> { 4, 5, 6 },
                new List<int> { 9, 8, 9 }
            };

            Console.WriteLine($"Absolute Diagonal difference: {DiagonalSquare.DiagonalDifference(matrix)}");
            Console.WriteLine($"Absolute Diagonal difference: {DiagonalSquare.DiagonalDifference(otherMatrix)}");
        }

        public static void CountingSortTest()
        {
            CountingSort.countingSort(new List<int> { 1, 1, 3, 2, 1 });
        }

        private static void CountingValleysTest()
        {
            string path = "UDDDUDUU";
            Console.WriteLine($"Counting Valleys input: {path}, expected output: 1, received output: {CountingValleys.countingValleys(8, path)}");
        }
    }
}
