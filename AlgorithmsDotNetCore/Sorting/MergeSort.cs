using System;
using System.Linq;

namespace AlgorithmsDotNetCore.Sorting {
    class MergeSort {
        int total_swaps = 0;

        private void Sort(int[] numbers, int start, int end) {
            if (start != end) {
                int half = (start + end) / 2;
                Sort(numbers, start, half);
                Sort(numbers, half + 1, end);
            }

            Console.WriteLine($"Ordering values from {start} to {end}:");
            Console.WriteLine(string.Join(", ", numbers));
            for (int i=start; i < end; i++) {
                if (numbers[i] > numbers[i + 1]) {
                    (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
                    total_swaps++;
                    Console.WriteLine(string.Join(", ", numbers));
                    for (int j = i; j > start && numbers[j - 1] > numbers[j]; j--) {
                        (numbers[j], numbers[j - 1]) = (numbers[j - 1], numbers[j]);
                        total_swaps++;
                        Console.WriteLine(string.Join(", ", numbers));
                    }
                }
            }
            Console.WriteLine();
        }

        public void Run() {
            var numbers = Enumerable.Range(1, 10).OrderByDescending(x => x).ToArray();
            Console.WriteLine($"Initial values: {string.Join(", ", numbers)}");
            Sort(numbers, 0, numbers.Length - 1);
            Console.WriteLine($"Final values: {string.Join(", ", numbers)}");
            Console.WriteLine($"Total number of swaps: {total_swaps}");
        }
    }
}
