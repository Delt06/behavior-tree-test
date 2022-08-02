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
        private const float ReachThreshold = 0.25f;
        private readonly ResourceRepository _resourceRepository;

        public CharacterBehaviorTree(ResourceRepository resourceRepository) => _resourceRepository = resourceRepository;

        protected override IBehaviorTreeNode<CharacterContext> CreateTree() =>
            Selector(
                FreeResources(),
                CollectClosestResource(),
                Finish()
            );

        private IBehaviorTreeNode<CharacterContext> CollectClosestResource() =>
            Sequence(
                new MoveTowardsRandomResourceNode(_resourceRepository, ReachThreshold),
                Stop()
            );

        private static IBehaviorTreeNode<CharacterContext> FreeResources() =>
            Sequence(new CharacterResourcesAreFullConditionNode(),
                new MoveTowardsPosition(Vector3.zero, ReachThreshold),
                Stop(),
                Wait(2f, 3f),
                new FreeResourcesNode()
            );

        private static IBehaviorTreeNode<CharacterContext> Finish()
        {
            return Sequence(
                new DebugLogNode<CharacterContext>(_ => "Finished work. Destroying..."),
                new DestroyCharacterNode()
            );
        }

        private static SetDirectionNode Stop() => new(Vector2.zero);
    }
}