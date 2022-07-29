using UnityEngine;

namespace GameAi
{
    public class CharacterAi : MonoBehaviour
    {
        [SerializeField] private CharacterContext _context;

        private CharacterBehaviorTree _behaviorTree;

        private void Start()
        {
            _behaviorTree = new CharacterBehaviorTree();
            _behaviorTree.Setup();
        }

        private void Update()
        {
            _behaviorTree.Update(_context);
        }
    }
}