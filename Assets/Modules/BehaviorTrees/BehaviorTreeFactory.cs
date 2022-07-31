using Modules.BehaviorTrees.Nodes;
using Modules.BehaviorTrees.Nodes.Composite;
using Modules.BehaviorTrees.Nodes.Utility;

namespace Modules.BehaviorTrees
{
    public static class BehaviorTreeFactory<TContext>
    {
        public static IBehaviorTreeNode<TContext> Selector(params IBehaviorTreeNode<TContext>[] nodes) =>
            new BehaviorTreeSelectorNode<TContext>(nodes);

        public static IBehaviorTreeNode<TContext> Sequence(params IBehaviorTreeNode<TContext>[] nodes) =>
            new BehaviorTreeSequenceNode<TContext>(nodes);

        public static IBehaviorTreeNode<TContext> Wait(float seconds) =>
            new WaitNode<TContext>(seconds);

        public static IBehaviorTreeNode<TContext> Random(float probability) =>
            new RandomChanceNode<TContext>(probability);
    }
}