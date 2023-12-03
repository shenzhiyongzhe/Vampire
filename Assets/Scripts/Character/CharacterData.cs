
using UnityEngine;

namespace Assets.Scripts.Character
{
    [CreateAssetMenu(fileName ="Character Data", menuName ="Scriptable Object/Character Data")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private RuntimeAnimatorController _controller;
        [SerializeField] CharacterType _characterType;
        [SerializeField] int _healthPoint;
        [SerializeField] int _attackPower;
        [SerializeField] int _defencePower;
        [SerializeField] int _moveSpeed;

        public Sprite Sprite => _sprite;
        public RuntimeAnimatorController Controller => _controller;
        public CharacterType Character_Type => _characterType;
        public int HealthPoint => _healthPoint;
        public int AttackPower => _attackPower;
        public int DefencePower => _defencePower;
        public int MoveSpeed => _moveSpeed;
        public enum CharacterType
        {
            FlyingEye,
            Mushroom,
            Knight,
            Bandit
        }
    }
}