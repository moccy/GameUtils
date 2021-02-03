using Lyut.BehaviourTree.Nodes;

namespace Lyut.BehaviourTree
{
    public class BehaviourTree
    {
        public Node Root { get; set; }

        public BehaviourTree() { }

        public BehaviourTree(Node root)
        {
            Root = root;
        }

        public NodeStatus Execute()
        {
            return Root.Execute();
        }
    }
}
