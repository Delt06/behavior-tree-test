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
            Sequence(
                new SetDirectionNode(Vector2.up),
                Wait(1f),
                new SetDirectionNode(Vector2.down),
                Wait(1f),
                Selector(
                    Sequence(
                        Random(0.5f),
                        new SetDirectionNode(Vector2.right)
                    ),
                    new SetDirectionNode(Vector2.left)
                ),
                Wait(1f)
            );
    }
}