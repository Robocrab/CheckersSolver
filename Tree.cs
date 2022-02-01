using System.Collections.Generic;

namespace CheckersSolver
{
	public class Tree
	{
		public Node Origin { get; private set; }
        public Tree(bool whiteGo)
        {
            Origin = new Node(new MoveInfo(), whiteGo, null);
        }
        public bool WhiteCertainlyWin() {
            return WhiteCertainlyWin(Origin);
        }
        bool WhiteCertainlyWin(Node CurrentNode)
        {
            if (CurrentNode.Children.Count == 0)
            {
                return (bool)CurrentNode.whiteHaveWon;
            }
            else if (CurrentNode.whiteGo)
            {
                bool result = false;
                foreach (Node node in CurrentNode.Children)
                {
                    result = result || WhiteCertainlyWin(node);
                }
                return result;
            }
            else
            {
                bool result = true;
                foreach (Node node in CurrentNode.Children)
                {
                    result = result && WhiteCertainlyWin(node);
                }
                return result;
            }
        }
	}
    
	public class Node
    {
        public List<Node> Children = new List<Node>();
        public Node parent { get; private set; }
        public bool? whiteHaveWon;
        /*{
            get
            {
                if (Children.Count == 0)
                {
                    return whiteHaveWon;
                }
                else
                {
                    throw new Exception("Attempted to get bool value of a non-leaf node.");
                }
            }
            set
            {
                if (Children.Count == 0)
                {
                    whiteHaveWon = value;
                }
                else
                {
                    throw new Exception("Attempted to set bool value of a non-leaf node.");
                }
            }
        }*/
        public MoveInfo move { get; private set; }
        public bool whiteGo { get; private set; }
        public Node(MoveInfo move, bool whiteGo, Node parent, bool? whiteHaveWon = null)
        {
            this.move = move;
            this.whiteHaveWon = whiteHaveWon;
            this.whiteGo = whiteGo;
            this.parent = parent;
        }
        public Node AddChild(MoveInfo move ,bool? whiteHaveWon = null)
        {
            Node childNode = new Node(move,!whiteGo, this, whiteHaveWon);
            Children.Add(childNode);
            return childNode;
        }
    }
    public struct MoveInfo
    {
        int X;
        int Y;
        MoveType moveType;
        bool left;
        public MoveInfo(int X, int Y, MoveType moveType, bool left)
        {
            this.X = X;
            this.Y = Y;
            this.moveType = moveType;
            this.left = left;
        }
    }
    public enum MoveType
    {
        MOVE,
        CAPTURE
    }
}