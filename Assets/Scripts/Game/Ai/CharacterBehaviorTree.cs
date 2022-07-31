using Game.Ai.Nodes;
using Game.Characters;
using Game.ResourceSystem;
using Modules.BehaviorTrees;
using Modules.BehaviorTrees.Nodes;
using UnityEngine;
using static Modules.BehaviorTrees.BehaviorTreeFactory<Game.Characters.CharacterContext>;

namespace Game.Ai
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