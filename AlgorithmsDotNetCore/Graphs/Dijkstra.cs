using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNetCore.Graphs {
	public class Dijkstra {
		Graph graph;
		int total_cost = int.MaxValue;
		IEnumerable<string> path;

		void GoToDestination(string current_node, string destination, int current_cost, IEnumerable<string> current_path) {
			var updated_path = current_path.Append(current_node);

			if (current_node == destination) {
				if (current_cost < total_cost) {
					total_cost = current_cost;
					path = current_path;
				}
				return;
			}

			foreach(var node in graph[current_node]) {
				if (!current_path.Contains(node.Key)) {
					GoToDestination(node.Key, destination, current_cost + node.Value, updated_path);
				}
			}
		}

		public void Run() {
			graph = GraphBuilder.BuildGraph();
			var start = "a";
			var end = "e";
			GoToDestination(start, end, 0, new List<string>());

			Console.WriteLine("Graph:");
			Console.WriteLine(graph.ToString());
			Console.WriteLine($"Path: {string.Join(" -> ", path)}");
			Console.WriteLine($"Total cost: {total_cost}");
		}
	}
}
