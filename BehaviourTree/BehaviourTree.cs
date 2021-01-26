using BehaviourTree.Nodes;

namespace BehaviourTree
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
