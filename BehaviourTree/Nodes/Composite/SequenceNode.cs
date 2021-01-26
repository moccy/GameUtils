using System.Linq;

namespace BehaviourTree.Nodes.Composite
{
    /// <summary>
    /// A sequence node is a composite node that must execute it's children in a specified order.
    /// If any of the children fail, the sequence fails. If all the children succeed, so does the sequence.
    /// </summary>
    public class SequenceNode : CompositeNode
    {
        public SequenceNode(IOrderedEnumerable<Node> children) : base(children) { }

        public override NodeStatus Execute()
        {
            Status = NodeStatus.Running;
            Status = Children.Any(child => child.Execute() == NodeStatus.Failure)
                ? NodeStatus.Failure
                : NodeStatus.Success;
            return Status;
        }
    }
}
