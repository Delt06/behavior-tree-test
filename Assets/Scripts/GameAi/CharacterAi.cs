using Characters;
using ResourceSystem;
using UnityEngine;
using UnityEngine.Scripting;

namespace GameAi
{
    public class CharacterAi : MonoBehaviour
    {
        [SerializeField] private CharacterContext _context;

        private CharacterBehaviorTree _behaviorTree;

        private ResourceRepository _resourceRepository;

        [Preserve]
        public void Construct(ResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        private void Start()
        {
            _behaviorTree = new CharacterBehaviorTree(_resourceRepository);
            _behaviorTree.Setup();
        }

        private void Update()
        {
            _behaviorTree.Update(_context);
        }
    }
}