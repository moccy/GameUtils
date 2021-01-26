namespace BehaviourTree.Nodes.Decorator
{
    public abstract class DecoratorNode : Node
    {
        public Node Child { get; protected set; }

        protected DecoratorNode(Node child)
        {
            Child = child;
        }
    }
}
