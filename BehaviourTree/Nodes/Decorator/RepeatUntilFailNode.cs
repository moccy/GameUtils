namespace BehaviourTree.Nodes.Decorator
{
    /// <summary>
    /// This node executes it's child until it fails, at which point it returns successful.
    /// </summary>
    public class RepeatUntilFailNode : DecoratorNode
    {
        public RepeatUntilFailNode(Node child) : base(child) { }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;

            while (true)
            {
                if (Child.Execute() == NodeStatus.Failure) break;
            }

            Status = NodeStatus.Success;
            return Status;
        }
    }
}
