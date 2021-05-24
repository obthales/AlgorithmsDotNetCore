namespace AlgorithmsDotNetCore.Trees {
	class Tree {
		public Node Root { get; set; }
		private int height;

		public void BuildTree(int[] numbers) {
			height = 0;

			foreach(int number in numbers) {
				AddNode(Root, number, Root);
			}
		}

		private void AddNode(Node node, int value, Node parent) {
			if (node == null) {
				node = new Node() { Value = value, Parent = parent };
				return;
			}

			if (value < node.Value) {
				AddNode(node.LeftChild, value, node);
				node.LeftDeph++;
			} else {
				AddNode(node.RightChild, value, node);
				node.RightDeph++;
			}
		}

		private void RebalanceSubtree(Node node) {
			if (node.LeftDeph > node.RightDeph + 1) {
				if (node.Parent == null) {
					// Node is root
					
				} else if (node.Parent.Value > node.Value) {
					// Node is left child
					var new_parent_node = node.LeftChild.RightChild;
					node.Parent.LeftChild = new_parent_node;
					node.LeftChild.RightChild = new_parent_node.LeftChild;
					new_parent_node.LeftChild = node.LeftChild;
					node.LeftChild = new_parent_node.RightChild;
					new_parent_node.RightChild = node;
				} else {
					// Node is right child
				}
			}
			if (node.LeftDeph + 1 > node.LeftDeph) {

			}
		}

		public void PrintTree() {

		}
	}
}
