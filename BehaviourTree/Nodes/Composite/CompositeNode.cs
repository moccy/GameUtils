using System.Collections.Generic;

namespace Lyut.BehaviourTree.Nodes.Composite
{
    public abstract class CompositeNode : Node
    {
        public IEnumerable<Node> Children { get; protected set; }

        protected CompositeNode(IEnumerable<Node> children)
        {
            Children = children;
        }
    }
}
