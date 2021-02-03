using System;

namespace Lyut.BehaviourTree.Nodes
{
    public class BooleanNode : Node
    {
        public Func<bool> Task { get; }

        public BooleanNode(Func<bool> task)
        {
            Task = task;
        }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;
            Status = Task.Invoke() ? NodeStatus.Success : NodeStatus.Failure;
            return Status;
        }
    }
}
