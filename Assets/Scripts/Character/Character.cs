using System.Collections;
using UnityEngine;


public abstract class Character : MonoBehaviour
{

    [SerializeField] CharacterData characterData;
    Sprite sprite;
    RuntimeAnimatorController controller;
    Animator _animator;
    int hp;
    int attackPower;
    int defencePower;
    int moveSpeed;


    protected virtual void Initialize()
    {
        _animator = GetComponent<Animator>();
        hp = characterData.HealthPoint;
        attackPower = characterData.AttackPower;
        defencePower = characterData.DefencePower;
        moveSpeed = characterData.MoveSpeed;
    }
    public Animator Anim => _animator;
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
            StartDie();
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

    public abstract void StartDie();

}

