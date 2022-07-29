using BehaviorTrees;
using BehaviorTrees.Nodes;
using GameAi.Nodes;
using UnityEngine;
using static BehaviorTrees.BehaviorTreeFactory<CharacterContext>;

namespace GameAi
{
    public class CharacterBehaviorTree : BehaviorTreeBase<CharacterContext>
    {
        protected override IBehaviorTreeNode<CharacterContext> CreateTree() =>
            Selector(
                Sequence(
                    new MoveTowardsClosestResourceNode(),
                    new SetDirectionNode(Vector2.zero),
                    Wait(1f)
                ),
                Sequence(
                    new DebugLogNode<CharacterContext>(_ => "Finished work. Destroying..."),
                    new DestroyCharacterNode()
                )
            );
    }
}