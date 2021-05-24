using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;

namespace AlgorithmsDotNetCore.Challenges {
	class NumberConverter {
		(bool, string) IdentifyAndConvert(string input) {
			bool to_roman = false;
			string result = "";

			try {
				int.Parse(input);
				result = ConvertToRoman(input);
				to_roman = true;
			} catch (FormatException) {
				result = ConvertToArabic(input);
			}

			return (to_roman, result);
		}

		string ConvertToArabic(string input) {
			input = input.ToUpper();
			int result = 0;
			char previous = ' ';
			for (int i = 0; i < input.Length; i++) {
				char current = input[i];
				result += current switch
				{
				'M' => previous switch
				{
					'C' => 800, // Already added 100 before. Subtract 800 to get 900.
					_ => 100,
				},
				'D' => previous switch
				{
					'C' => 300, // Already added 100 before. Add 300 to get 400.
					_ => 500,
				},
				'C' => previous switch {
					'X' => 80, // Already added 10 before. Subtract 80 to get 90.
					_ => 100,
				},
				'L' => previous switch
				{
					'X' => 30, // Already added 10 before. Add 30 to get 40.
					_ => 50,
				},
				'X' => previous switch
				{
					'I' => 8, // Already added 1 before. Add 8 to get 9.
					_ => 10,
				},
				'V' => previous switch
				{
					'I' => 3, // Already added 1 before. Add 3 to get 4.
					_ => 5,
				},
				'I' => 1,
				_ => 0,
				};
				previous = current;
			}

			return result.ToString();
		}

		string ConvertToRoman(string input) {
			int int_value = int.Parse(input);
			if (int_value > 3999) {
				return "Impossoible to convert to roman. Maximum roman representation of a number is 3999.";
			}

			string result = "";
			for (int i = input.Length - 1, decimal_place = 1; i >= 0; i--, decimal_place++) {
				result = input[i] switch
				{
					'1' => decimal_place switch {
						1 => "I",
						2 => "X",
						3 => "C",
						4 => "M",
					},
					'2' => decimal_place switch
					{
						1 => "II",
						2 => "XX",
						3 => "CC",
						4 => "MM",
					},
					'3' => decimal_place switch
					{
						1 => "III",
						2 => "XXX",
						3 => "CCC",
						4 => "MMM",
					},
					'4' => decimal_place switch
					{
						1 => "IV",
						2 => "XL",
						3 => "CD",
					},
					'5' => decimal_place switch
					{
						1 => "V",
						2 => "L",
						3 => "D",
					},
					'6' => decimal_place switch
					{
						1 => "VI",
						2 => "LX",
						3 => "DC",
					},
					'7' => decimal_place switch
					{
						1 => "VII",
						2 => "LXX",
						3 => "DCC",
					},
					'8' => decimal_place switch
					{
						1 => "VIII",
						2 => "LXXX",
						3 => "DCCC",
					},
					'9' => decimal_place switch
					{
						1 => "IX",
						2 => "XC",
						3 => "CM",
					},
					_ => "",
				} + result;
			}

			return result;
		}

		public void Run() {
			while (true) {
				Console.WriteLine("Type a number you want to convert to/from roman:");
				var input = Console.ReadLine();
				(bool to_roman, string result) = IdentifyAndConvert(input);

				if (to_roman) {
					Console.WriteLine("The number you entered was arabic and was converted to roman numbers.");
				} else {
					Console.WriteLine("The number you entered was roman and was converted to arabic numbers.");
				}
				Console.WriteLine($"The result of the conversion is: {result}");
				Console.WriteLine();
			}
		}
	}
}
