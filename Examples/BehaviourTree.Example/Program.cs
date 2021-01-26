using System;
using BehaviourTree.Nodes;
using BehaviourTree.Nodes.Decorator;

namespace BehaviourTree.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            var tree = new BehaviourTree(
                new RepeatUntilFailNode(
                    new LeafNode(() =>
                    {
                        var rng = new Random();
                        Console.WriteLine($"I've counted to {++count}!");
                        return rng.Next(0, 100) == 50 ? NodeStatus.Failure : NodeStatus.Success;
                    })));

            tree.Execute();
        }
    }
}
