namespace BehaviourTree.Nodes.Decorator
{
    /// <summary>
    /// An succeeder node will always return successful, regardless of its child's execution outcome.
    /// </summary>
    public class SucceederNode : DecoratorNode
    {
        public SucceederNode(Node child) : base(child) { }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;
            Child.Execute();
            Status = NodeStatus.Success;
            return Status;
        }
    }
}
