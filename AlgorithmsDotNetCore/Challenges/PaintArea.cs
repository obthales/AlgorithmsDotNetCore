using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace AlgorithmsDotNetCore.Challenges {
	class PaintArea {
		const char delimiter = '#';
		const char blank = ' ';
		const char null_char = '\0';

		static string class_name = MethodBase.GetCurrentMethod().DeclaringType.Name;
		string in_file = "Challenges/" + class_name + ".in";
		string out_file = "Challenges/" + class_name + ".out";

		char[,] ReadFromFile() {
			char[,] map;

			using (var file = new StreamReader(in_file)) {
				int lines = 0;
				int columns = 0;

				string text_line;
				while ((text_line = file.ReadLine()) != null) {
					lines++;
					columns = Math.Max(columns, text_line.Length);
				}
				map = new char[lines, columns];
			}

			using (var file = new StreamReader(in_file)) {
				int current_line = 0;
				string text_line;
				while ((text_line = file.ReadLine()) != null) {
					int current_column = 0;
					foreach (char c in text_line.ToCharArray()) {
						map[current_line, current_column] = c;
						current_column++;
					}
					current_line++;
				}
			}

			return map;
		}

		void FillMap(char[,] map) {
			char previous = blank;
			for (int i = 0; i < map.GetLength(0); i++) {
				for (int j = 0; j < map.GetLength(1); j++) {
					if (map[i, j] != delimiter && map[i, j] != blank && map[i, j] != null_char && map[i, j] != previous) {
						FillWithColour(map, i, j, map[i, j]);
					}
					previous = map[i, j];
				}
			}
		}

		void FillWithColour(char[,] map, int i, int j, char colour) {
			map[i, j] = colour;

			EvaluetePosition(map, i - 1, j, colour);
			EvaluetePosition(map, i + 1, j, colour);
			EvaluetePosition(map, i, j - 1, colour);
			EvaluetePosition(map, i, j + 1, colour);
		}

		void EvaluetePosition(char[,] map, int i, int j, char colour) {
			Console.WriteLine($"Evaluating {i}, {j} - Current colour: {colour}");
			if (i >= 0 && i < map.GetLength(0) && j >= 0 && j < map.GetLength(1)
					&& map[i, j] != delimiter && map[i, j] != null_char && map[i, j] == blank) {
				FillWithColour(map, i, j, colour);
			}
		}

		void WriteToFile(char[,] map) {
			using (var file = new StreamWriter(out_file)) {
				for (int i = 0; i < map.GetLength(0); i++) {
					for (int j = 0; j < map.GetLength(1); j++) {
						if (map[i, j] != null_char) {
							file.Write(map[i, j]);
						}
					}
					file.WriteLine();
				}
			}
		}

		public void Run() {
			var map = ReadFromFile();
			FillMap(map);
			WriteToFile(map);
		}
	}
}
