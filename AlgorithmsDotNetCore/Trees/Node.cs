namespace AlgorithmsDotNetCore.Trees {
	public class Node {
		public int Value { get; set; }

		private Node leftChild;
		private Node rightChild;

		public Node LeftChild {
			get { return leftChild; }
			set { 
				leftChild = value; 
				value.Parent = this; 
			} 
		}

		public Node RightChild {
			get { return rightChild; }
			set {
				rightChild = value;
				value.Parent = this;
			}
		}

		public int LeftDeph { get; set; }
		public int RightDeph { get; set; }
		public Node Parent { get; set; }
	}
}
