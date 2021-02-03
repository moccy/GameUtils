namespace Lyut.BehaviourTree.Nodes.Decorator
{
    /// <summary>
    /// A repeater node will execute it's child for a specified number of times, or forever.
    /// </summary>
    public class RepeaterNode : DecoratorNode
    {
        public uint? MaxIterations { get; }

        public RepeaterNode(Node child) : base(child) { }
        public RepeaterNode(Node child, uint iterations) : base(child)
        {
            MaxIterations = iterations;
        }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;

            if (MaxIterations != null)
            {
                for (var i = 0; i < MaxIterations; i++)
                {
                    Child.Execute();
                }

                Status = NodeStatus.Success;
                return Status;
            }

            while (true)
            {
                Child.Execute();
            }
        }
    }
}
