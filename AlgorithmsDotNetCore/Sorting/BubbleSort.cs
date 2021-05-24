using System;
using System.Linq;

namespace AlgorithmsDotNetCore.Sorting {
    class BubbleSort {
        int total_swaps = 0;

        void Sort(int[] numbers) {
            if (numbers is null || numbers.Length == 0) {
                Console.WriteLine("Invalid parameters.");
                return;
            }


            bool all_sorted = false;
            int step_number = 0;
            while (!all_sorted) {
                all_sorted = true;
                step_number++;
                Console.WriteLine($"Step {step_number}:");
                for (int i=1; i < numbers.Length; i++) {
                    if (numbers[i-1] > numbers[i]) {
                        (numbers[i-1], numbers[i]) = (numbers[i], numbers[i-1]);
                        all_sorted = false;
                        total_swaps++;
                        Console.WriteLine(string.Join(", ", numbers));
                    }
                }

            }
        }

        public void Run() {
            var numbers = Enumerable.Range(1, 10).OrderByDescending(x => x).ToArray();
            Console.WriteLine($"Initial values: {string.Join(", ", numbers)}");
            Sort(numbers);
            Console.WriteLine($"Final values: {string.Join(", ", numbers)}");

            Console.WriteLine($"Total number of swaps: {total_swaps}");
        }
    }
}
