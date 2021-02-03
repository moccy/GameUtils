namespace Lyut.BehaviourTree.Nodes
{
    public abstract class Node
    {
        public NodeStatus Status { get; set; } = NodeStatus.Stopped;

        public abstract NodeStatus Execute();
    }
}
