using System;

namespace BehaviourTree.Nodes
{
    public class LeafNode : Node
    {
        public Func<NodeStatus> Task { get; }

        public LeafNode(Func<NodeStatus> task)
        {
            Task = task;
        }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;
            Status = Task.Invoke();
            return Status;
        }
    }
}
