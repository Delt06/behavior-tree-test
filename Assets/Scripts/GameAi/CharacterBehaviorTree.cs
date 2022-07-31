using BehaviorTrees;
using BehaviorTrees.Nodes;
using Characters;
using GameAi.Nodes;
using ResourceSystem;
using UnityEngine;
using static BehaviorTrees.BehaviorTreeFactory<Characters.CharacterContext>;

namespace GameAi
{
    public class CharacterBehaviorTree : BehaviorTreeBase<CharacterContext>
    {
        private readonly ResourceRepository _resourceRepository;

        public CharacterBehaviorTree(ResourceRepository resourceRepository) => _resourceRepository = resourceRepository;

        protected override IBehaviorTreeNode<CharacterContext> CreateTree() =>
            Selector(
                Sequence(
                    new MoveTowardsClosestResourceNode(_resourceRepository),
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