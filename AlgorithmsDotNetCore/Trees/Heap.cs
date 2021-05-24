namespace AlgorithmsDotNetCore.Trees {
	abstract class AbstractHeap {
		private int capacity;
		private int size;

		public int[] Elements { get; set; }

		public AbstractHeap() {
			capacity = 8;
			size = 0;
			Elements = new int[capacity];
		}

		public int LeftChildIndex(int index) {
			return index * 2 + 1;
		}

		public int RightChildIndex(int index) {
			return (index + 1) * 2;
		}

		public int ParentIndex(int index) {
			return index / 2 + 1;
		}

		public bool HasLeftChild(int index) {
			return LeftChildIndex(index) < size;
		}

		public bool HasRightChild(int index) {
			return RightChildIndex(index) < size;
		}

		public override string ToString() {
			return string.Join(", ", Elements);
		}

		public void Add(int value) {
			if (size == capacity) {
				IncreaseHeapSize();
			}

			Elements[size] = value;
			HeapifyUp(size);
			size++;
		}

		public int Remove() {
			int result = Elements[0];

			Elements[0] = Elements[size - 1];
			size--;
			HeapifyDown();

			return result;
		}

		public abstract void HeapifyUp(int index);
		public abstract void HeapifyDown();

		private void IncreaseHeapSize() {
			capacity *= 2;
			int[] new_heap = new int[capacity];

			for (int i = 0; i < size; i++) {
				new_heap[i] = Elements[i];
			}
			Elements = new_heap;
		}
	}


	class MininumHeap : AbstractHeap {

		public override void HeapifyUp(int index) {
			while (index > 0) {
				int parent_index = ParentIndex(index);
				if (Elements[index] < Elements[parent_index]) {
					(Elements[index], Elements[parent_index]) = (Elements[parent_index], Elements[index]);
					index = parent_index;
				} else {
					break;
				}
			}
		}

		public override void HeapifyDown() {
			int index = 0;
			while (HasLeftChild(index)) {
				int smaller_child_index = LeftChildIndex(index);

				if (HasRightChild(index) && Elements[RightChildIndex(index)] < Elements[smaller_child_index]) {
					smaller_child_index = RightChildIndex(index);
				}

				if (Elements[smaller_child_index] < Elements[index]) {
					(Elements[smaller_child_index], Elements[index]) = (Elements[index], Elements[smaller_child_index]);
				} else {
					break;
				}
				index = smaller_child_index;
			}
		}
	}

	public class Heap {

		public void Run() {

		}
	}
}
