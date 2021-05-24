using System;
using System.Linq;

namespace AlgorithmsDotNetCore.Sorting {
	class QuickSort {
		int total_swaps = 0;
        Random rand = new Random();

        void Sort(int[] numbers, int start, int end) {
            if (start == end) {
                return;
            }

            int pivot_index = rand.Next(start, end);
            var pivot = numbers[pivot_index];
            Console.WriteLine($"Pivot: {pivot}");

            var sorted_numbers = new int[numbers.Length];
            int sorted_lower_index = start;
            int sorted_greater_index = end;
            Console.WriteLine("Temporary sorted numbers array:");
            for (int i=start; i <= end; i++) {
                if (numbers[i] < pivot) {
                    sorted_numbers[sorted_lower_index] = numbers[i];
                    sorted_lower_index++;
                } else if (numbers[i] > pivot) {
                    sorted_numbers[sorted_greater_index] = numbers[i];
                    sorted_greater_index--;
                }
                total_swaps++;
                Console.WriteLine(string.Join(", ", sorted_numbers));
            }
            sorted_numbers[sorted_lower_index] = pivot;
            for (int i=start; i <= end; i++) {
                numbers[i] = sorted_numbers[i];
            }
            Console.WriteLine($"Sorted numbers: {string.Join(", ", numbers)}");
            Console.WriteLine();

            if (start < sorted_greater_index - 1) {
                Sort(numbers, start, sorted_lower_index - 1);
            }
            if (sorted_lower_index + 1 < end) {
                Sort(numbers, sorted_lower_index + 1, end);
            }
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
