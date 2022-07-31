namespace Modules.BehaviorTrees.Nodes
{
    public abstract class BehaviorTreeNodeBase<TContext> : IBehaviorTreeNode<TContext>
    {
        public abstract EvaluationStatus Evaluate(TContext context);

        public virtual void ResetState(TContext context) { }
    }
}