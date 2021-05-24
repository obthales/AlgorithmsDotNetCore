using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDotNetCore.Graphs {
	public class BreadthFirstSearch {
		Graph graph;
		Queue<string> queue;
		ISet<string> visited_or_queued;

		bool HasPath(string current_node, string destination) {
			if (graph[current_node] == graph[destination]) {
				return true;
			}

			foreach (var node in graph[current_node]) {
				if (!visited_or_queued.Contains(node.Key)) {
					queue.Append(node.Key);
					visited_or_queued.Add(node.Key);
				}
			}
			return false;
		}

		public void Run() {
			graph = GraphBuilder.BuildGraph();
			queue = new Queue<string>();
			visited_or_queued = new HashSet<string>();

			var start = "a";
			var end = "e";
			queue.Append(start);

			var has_path = false;
			visited_or_queued.Add(start);
			while (queue.Count > 0 && !has_path) {
				has_path = HasPath(queue.Dequeue(), end);
			}

			Console.WriteLine("Graph:");
			Console.WriteLine(graph.ToString());
			if (has_path) {
				Console.WriteLine($"Node {start} has a path to node {end}.");
			} else {
				Console.WriteLine($"Node {start} DOES NOT have a path to node {end}.");
			}
		}
	}
}
