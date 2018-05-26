using System;

namespace diploma3.utils.tree {

	public class BST
	{
		private BST_Node _root;

		public void Add(double weight, double value)
		{
			_root = BST_Node.Insert(_root, value, weight);
		}

		public double GetLowerOrEqual(double weight)
		{
			return BST_Node.GetLowerOrEqual(_root, weight);
		}

		private sealed class BST_Node {
			private int _height;
			private BST_Node _left;
			private BST_Node _right;

			private readonly double _weight;
			private readonly double _value;

			private BST_Node(double weight, double value) {
				_weight = weight;
				_value = value;
				_height = 0;
				_left = null;
				_right = null;
			}

			public static BST_Node Insert(BST_Node node, double value, double weight) // вставка ключа k в дерево с корнем p
			{
				if (node == null)
				{
					return new BST_Node(weight, value);
				}
				if (weight < node._weight) {
					node._left = Insert(node._left, value, weight);
				} else {
					node._right = Insert(node._right, value, weight);
				}
				return Balance(node);
			}

			public static double GetLowerOrEqual(BST_Node node, double weight)
			{
				while (true)
				{
					if (node._weight > weight)
					{
						if (node._left != null)
						{
							node = node._left;
							continue;
						}
					}
					else if (node._right != null)
					{
						node = node._right;
						continue;
					}
					return node._value;
				}
			}

			private static int Height(BST_Node node) {
				return node == null ? 0 : node._height;
			}

			private static int BalanceFactor(BST_Node node) {
				return Height(node._right) - Height(node._left);
			}

			private static void ResetHeight(BST_Node node) {
				node._height = Math.Max(Height(node._left), Height(node._right)) + 1;
			}

			private static BST_Node Balance(BST_Node node) // балансировка узла p
			{
				ResetHeight(node);
				if (BalanceFactor(node) == 2) {
					if (BalanceFactor(node._right) < 0) {
						node._right = RotateRight(node._right);
					}
					return RotateLeft(node);
				}
				if (BalanceFactor(node) == -2) {
					if (BalanceFactor(node._left) > 0) {
						node._left = RotateLeft(node._left);
					}
					return RotateRight(node);
				}
				return node; // балансировка не нужна
			}

			private static BST_Node RotateLeft(BST_Node node) {
				BST_Node node0 = node._right;
				node._right = node0._left;
				node0._left = node;
				ResetHeight(node);
				ResetHeight(node0);
				return node0;
			}

			private static BST_Node RotateRight(BST_Node node) {
				BST_Node node0 = node._left;
				node._left = node0._right;
				node0._right = node;
				ResetHeight(node);
				ResetHeight(node0);
				return node0;
			}
		}
	}
}
