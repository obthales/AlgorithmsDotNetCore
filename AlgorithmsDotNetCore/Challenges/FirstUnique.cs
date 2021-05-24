using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace AlgorithmsDotNetCore.Challenges {
	class FirstUnique {
		private Dictionary<char, (int FirstAppearence, int Count)> char_count;

		private void CountCharaters(string input) {
			char_count = new Dictionary<char, (int, int)>();

			for (int i = 0; i < input.Length; i++) {
				AddToCharCount(input[i], i);
			}
		}

		private void AddToCharCount(char c, int position) {
			int first_appearence = position;
			int count = 1;
			
			if (char_count.ContainsKey(c)) {
				(first_appearence, count) = char_count[c];
				count++;
			}
			char_count[c] = (first_appearence, count);
		}

		private (char?, int?) RetrieveFirstUniqueFromCounted() {
			char? first_unique = null;
			int? first_unique_index = null;

			foreach (var item in char_count) {
				if (item.Value.Count == 1 && item.Value.FirstAppearence < (first_unique_index ?? int.MaxValue)) {
					first_unique = item.Key;
					first_unique_index = item.Value.FirstAppearence;
				}
			}

			return (first_unique, first_unique_index);
		}

		private (char?, int?) FindFirstUnique(string input) {
			CountCharaters(input);
			return RetrieveFirstUniqueFromCounted();
		}

		public void Run() {
			while(true) {
				Console.WriteLine("Enter a character sequence and we will list the first unique: ");
				string input = Console.ReadLine();
				
				(var first_unique, var first_unique_index) = FindFirstUnique(input);
				if (first_unique.HasValue) {
					Console.WriteLine($"The frist unique character was '{first_unique.Value}' and was found at position {first_unique_index.Value}.");
					Console.WriteLine(input);
					string blank_sapces = new String(' ', first_unique_index.Value);
					Console.WriteLine($"{blank_sapces}^");
				} else {
					Console.WriteLine("There was no unique character in the sequence.");
				}
				Console.WriteLine();
			}
		}
	}
}
