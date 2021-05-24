using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlgorithmsDotNetCore.Challenges {
	class StringPermutations {

		private Dictionary<char, int> characters_to_permutate;

		private List<(string, int)> FindAllPermuations(string target, string permutation) {
			if (target == null || target.Length == 0 || permutation == null || permutation.Length == 0) {
				throw new InvalidDataException("Strings must not be empty");
			}

			characters_to_permutate = CountCharacters(permutation);

			List<(string, int)> permutations = new List<(string, int)>();
			int permutation_lenght = permutation.Length;
			for (int i = 0; i <= target.Length - permutation.Length; i++) {
				var substring = target.Substring(i, permutation_lenght);
				if (IsAPermutation(substring)) {
					permutations.Add((substring, i));
				}
			}

			return permutations;
		}
		private Dictionary<char, int> CountCharacters(string permutation) {
			var character_count = new Dictionary<char, int>();
			
			foreach (char c in permutation) {
				if (character_count.ContainsKey(c)) {
					character_count[c]++;
				} else {
					character_count[c] = 1;
				}
			}
			return character_count;
		}

		private bool IsAPermutation(string target) {
			bool result = true;
			var target_char_count = CountCharacters(target);

			foreach(var char_count in characters_to_permutate) {
				if (!target_char_count.ContainsKey(char_count.Key) || target_char_count[char_count.Key] != char_count.Value) {
					result = false;
					break;
				}
			}

			return result;
		}


		public void Run() {
			while(true) {
				Console.WriteLine("This program will search the first string A and within it find all permutations of the string B.");
				Console.WriteLine("Enter the first string (A):");
				var target = Console.ReadLine();
				Console.WriteLine("Enter the second string (B):");
				var permutation = Console.ReadLine();
				
				try {
					var permutations = FindAllPermuations(target, permutation);

					if (permutations.Count == 0) {
						Console.WriteLine("No permutations found.");
					} else {
						Console.WriteLine("Found the following permutations:");

						var separator = " - ";
						var initial_spacing = new string(' ', permutation.Length + separator.Length);

						Console.WriteLine(initial_spacing + target);
						foreach(var item in permutations) {
							var output = item.Item1 + separator + new string(' ', item.Item2) + new string('^', permutation.Length);
							Console.WriteLine(output);
						}
					}
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}
