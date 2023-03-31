//.......................................2.1.......................................
//1
//using System;
//using System.Linq;
//
// namespace ConsoleApplication1
// {
//
//     class Program
//     {
//         static void Main()
//         {
//             string J = "ab";
//             string S = "aabbccd";
//             int res = S.Count(x => J.Contains(x));
//             Console.WriteLine("Количество символов из S в J: " + res);
//         }
//     }
// }


//2
// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// class Program
// {
//     static void Main()
//     {
//         int[] candidates1 = { 2, 5, 2, 1, 2 };
//         int target1 = 5;
//         List<List<int>> result1 = CombinationSum(candidates1, target1);
//         Console.WriteLine(string.Join("\n", result1.Select(x => $"[{string.Join(",", x)}]")));
//
//         int[] candidates2 = { 10, 1, 2, 7, 6, 1, 5 };
//         int target2 = 8;
//         List<List<int>> result2 = CombinationSum(candidates2, target2);
//         Console.WriteLine(string.Join("\n", result2.Select(x => $"[{string.Join(",", x)}]")));
//     }
//
//     static List<List<int>> CombinationSum(int[] candidates, int target)
//     {
//         Array.Sort(candidates);
//         return CombinationSumHelper(candidates, target, 0);
//     }
//
//     static List<List<int>> CombinationSumHelper(int[] candidates, int target, int start)
//     {
//         List<List<int>> result = new List<List<int>>();
//         if (target == 0)
//         {
//             result.Add(new List<int>());
//             return result;
//         }
//         for (int i = start; i < candidates.Length && candidates[i] <= target; i++)
//         {
//             if (i > start && candidates[i] == candidates[i - 1]) continue;
//             foreach (List<int> combination in CombinationSumHelper(candidates, target - candidates[i], i + 1))
//             {
//                 combination.Insert(0, candidates[i]);
//                 result.Add(combination);
//             }
//         }
//         return result;
//     }
// }


//3
// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// class Program
// {
//     static void Main()
//     {
//         int[] nums = { 1, 2, 3, 4 };
//         Console.WriteLine(SameNumbers(nums));
//         int[] nums2 = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
//         Console.WriteLine(SameNumbers(nums2));
//         int[] nums3 = { 1, 3, 2, 4, 3, 2, 1 };
//         Console.WriteLine(SameNumbers(nums3));
//     }
//
//     static bool SameNumbers(int[] nums)
//     {
//         bool res = nums.GroupBy(x => x).Any(g => g.Count() > 1);
//         return res;
//     }
// }







