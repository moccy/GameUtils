using System;
using System.Collections.Generic;
using System.Linq;

namespace Lyut.BehaviourTree.Nodes.Composite
{
    public class RandomSequencerNode : SequenceNode
    {
        public RandomSequencerNode(IEnumerable<Node> children) : base(Shuffle(children).OrderBy(x => 0)) { }

        private static IEnumerable<T> Shuffle<T>(
            IEnumerable<T> source)
        {
            var rng = new Random();
            var buffer = source.ToList();
            for (var i = 0; i < buffer.Count; i++)
            {
                var j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}
