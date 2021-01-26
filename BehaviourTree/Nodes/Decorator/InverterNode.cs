using System;

namespace BehaviourTree.Nodes.Decorator
{
    /// <summary>
    /// An inverter node will return the opposite status it's child returns after executing.
    /// </summary>
    public class InverterNode : DecoratorNode
    {
        public InverterNode(Node child) : base(child) { }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;
            var childStatus = Child.Execute();

            Status = childStatus switch
            {
                NodeStatus.Failure => NodeStatus.Success,
                NodeStatus.Success => NodeStatus.Failure,
                NodeStatus.Running => NodeStatus.Stopped,
                NodeStatus.Stopped => NodeStatus.Running,
                _ => throw new ArgumentOutOfRangeException()
            };

            return Status;
        }
    }
}
