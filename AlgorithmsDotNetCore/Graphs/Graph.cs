using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDotNetCore.Graphs {
	public class Graph {
		public Dictionary<string, Dictionary<string, int>> Nodes;

		public Graph() => Nodes = new Dictionary<string, Dictionary<string, int>>();

		public Dictionary<string, int> this [string key]{
			get => Nodes[key];
			set => Nodes[key] = value;
		}

		public override string ToString() {
			var sb = new StringBuilder();
			foreach (var node in Nodes) {
				sb.Append($"{node.Key}  => ");
				foreach (var connection in node.Value) {
					sb.Append($"({connection.Key}, {connection.Value}) ");
				}
				sb.AppendLine();
			}

			return sb.ToString();
		}
	}

	public class GraphBuilder {
		public static Graph BuildGraph() {
			Graph graph = new Graph();
			graph["a"] = new Dictionary<string, int>() {
				["b"] = 1,
				["c"] = 2,
			};
			graph["b"] = new Dictionary<string, int>() {
				["d"] = 4,
				["e"] = 7,
			};
			graph["c"] = new Dictionary<string, int>() {
				["d"] = 2,
			};
			graph["d"] = new Dictionary<string, int>() {
				["e"] = 1,
			};

			return graph;
		}
	}
}
