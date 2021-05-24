using System;
using System.Linq;

namespace AlgorithmsDotNetCore.Challenges {
	
	class ExpressionNode {
		private ExpressionNode left_child;
		private ExpressionNode right_child;
		
		public string Value { get; set; }

		public ExpressionNode LeftChild {
				get { return left_child; } 
			set {
				left_child = value;
				if (value != null) {
					left_child.Parent = this;
				}
			}
		}

		public ExpressionNode RightChild {
			get { return right_child; }
			set {
				right_child = value;
				if (value != null) {
					right_child.Parent = this;
				}
			}
		}

		public ExpressionNode Parent { get; set; }

		public ExpressionNode(string value = null) {
			Value = value;
		}

		public double Evaluate() {
			try {
				return double.Parse(Value);
			} catch (FormatException) {
			}

			double left = LeftChild?.Evaluate() ?? 0;
			double right = RightChild?.Evaluate() ?? 0;

			return Value switch
			{
				"+" => left + right,
				"-" => left - right,
				"*" => left * right,
				"/" => left / right,
				_ => throw new FormatException("Unrecognized operator"),
			};
		}
	}

	class ExpressionEvaluator {
		ExpressionNode root;
		string[] OperatorPrecedence_1 = { "*", "/" };
		string[] OperatorPrecedence_2 = { "+", "-" };

		void BuildExpressionTree(string expression) {
			root = null;
			ExpressionNode current_node = null;

			string buffered_number = "";
			foreach (var c in expression.ToCharArray()) {
				if (c == ' ' || c == ',') continue;

				try {
					int.Parse(c.ToString());
					buffered_number += c;
				} catch	(FormatException) {
					if (c == '.') {
						buffered_number += c;
						continue;
					}
					if (buffered_number != string.Empty) {
						current_node = AddNode(current_node, buffered_number);
						buffered_number = string.Empty;
					}
					current_node = AddNode(current_node, c.ToString());
				}
			}
			if (buffered_number != string.Empty) {
				current_node = AddNode(current_node, buffered_number);
			}

			root = BalanceExpressionTree();
		}

		ExpressionNode AddNode(ExpressionNode current_node, string value) {
			ExpressionNode new_node = new ExpressionNode(value);
			
			root ??= new_node;

			if (current_node == null) {
				current_node = new_node;
			} else {
				new_node.Parent = current_node;
				current_node.RightChild = new_node;
				current_node = current_node.RightChild;
			}
			return current_node;
		}

		ExpressionNode BalanceExpressionTree() {
			ExpressionNode new_root = root;
			ExpressionNode current = root;
			while (current != null) {
				if (!IsNumber(current)) {
					if (IsNumber(current.Parent)) {
						MakeParentLeftChild(current);
						if (current.Parent == null) {
							new_root = current;
						}
					}
					if (current.Parent != null && OperatorPrecedence_1.Contains(current.Parent.Value)) {
						MakeParentLeftChild(current);
						if (current.Parent == null) {
							new_root = current;
						}
					}
				}

				current = current.RightChild;
			}

			return new_root;
		}

		bool IsNumber(ExpressionNode node) {
			bool result = false;
			try {
				double.Parse(node.Value);
				result = true;
			} catch (FormatException) {
			}

			return result;
		}

		void MakeParentLeftChild(ExpressionNode current) {
			var current_left_child = current.LeftChild;
			var current_grand_parent = current.Parent?.Parent;

			current.LeftChild = current.Parent;
			current.LeftChild.RightChild = current_left_child;

			if (current_grand_parent == null) {
				current.Parent = null;
			} else {
				current_grand_parent.RightChild = current;
			}
		}

		public void Run() {
			while (true) {
				Console.WriteLine("Type in an expression to be evaluated: ");
				var expression = Console.ReadLine();
				BuildExpressionTree(expression);
				Console.WriteLine($"Result of evaluated expression: {root.Evaluate()}");
				Console.WriteLine();
			}
		}
	}
}
