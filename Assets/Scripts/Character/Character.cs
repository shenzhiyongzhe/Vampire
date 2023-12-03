using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public abstract class Character : MonoBehaviour
    {

        [SerializeField] CharacterData characterData;
        Sprite sprite;
        RuntimeAnimatorController controller;
        Animator animator;
        int hp;
        int attackPower;
        int defencePower;
        int moveSpeed;


        protected virtual void Initialize()
        {
            hp = characterData.HealthPoint;
            attackPower = characterData.AttackPower;
            defencePower = characterData.DefencePower;
            moveSpeed = characterData.MoveSpeed;
        }

        public Sprite Sprite => sprite;
        public int HP => hp;
        public int AttackPower => attackPower;
        public int DefencePower => defencePower;
        public int MoveSpeed => moveSpeed;

        public virtual void GetHurt(int damage)
        {
            if (hp <= damage)
            {
                hp = 0;
                Die();
            }
            else
            {
                hp -= damage;
            }
        }

        public CharacterData.CharacterType GetCharacterType()
        {
            return characterData.Character_Type;
        }

        public abstract void Die();

    }

}