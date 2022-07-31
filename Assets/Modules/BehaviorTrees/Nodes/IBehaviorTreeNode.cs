namespace Modules.BehaviorTrees.Nodes
{
    public interface IBehaviorTreeNode<in TContext>
    {
        EvaluationStatus Evaluate(TContext context);
        void ResetState(TContext context);
    }
}