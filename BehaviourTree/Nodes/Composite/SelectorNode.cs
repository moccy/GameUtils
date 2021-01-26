using System.Linq;

namespace BehaviourTree.Nodes.Composite
{
    public class SelectorNode : CompositeNode
    {
        public SelectorNode(IOrderedEnumerable<Node> children) : base(children) { }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;
            Status = Children.Any(child => child.Execute() == NodeStatus.Success)
                ? NodeStatus.Success
                : NodeStatus.Failure;
            return Status;
        }
    }
}
