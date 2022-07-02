using System;
using System.Collections.Generic;

namespace House_Robber_III
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(4);
      root.left = new TreeNode(1);
      root.right = new TreeNode(5);
      root.right.left = new TreeNode(1);
      root.right.right = new TreeNode(2);
      Solution s = new Solution();
      var answer = s.Rob(root);
      Console.WriteLine(answer);
    }
  }

  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val)
    {
      this.val = val;
    }
  }

  public class Solution
  {
    // Time O(N)
    // Space O(1)
    public int Rob(TreeNode root)
    {
      var (withRoot, withoutRoot) = DFS(root);
      return Math.Max(withRoot, withoutRoot);
    }

    private (int, int) DFS(TreeNode root)
    {
      if (root == null) return (0, 0);

      var (leftWithRoot, leftWithoutRoot) = DFS(root.left);
      var (rightWithRoot, rightWithoutRoot) = DFS(root.right);

      // If we consider taking root, as per the question we can not consider next childs
      // so root + from left subtree without left root + from right subtree without right root 
      var withRoot = root.val + leftWithoutRoot + rightWithoutRoot;
      // When we dont take root
      // so max loot would be max(left) + max(right)
      var withoutRoot = Math.Max(leftWithRoot, leftWithoutRoot) + Math.Max(rightWithRoot, rightWithoutRoot);

      return (withRoot, withoutRoot);
    }
  }
}
