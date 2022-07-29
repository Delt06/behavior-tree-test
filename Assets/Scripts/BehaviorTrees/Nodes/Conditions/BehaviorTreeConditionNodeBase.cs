namespace BehaviorTrees.Nodes.Conditions
{
    public abstract class BehaviorTreeConditionNodeBase<TContext> : BehaviorTreeNodeBase<TContext>
    {
        public sealed override EvaluationStatus Evaluate(TContext context) =>
            Condition(context) ? EvaluationStatus.Success : EvaluationStatus.Failure;

        protected abstract bool Condition(TContext context);
    }
}