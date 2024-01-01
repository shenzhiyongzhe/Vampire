using System.Collections;
using UnityEngine;


public abstract class Character : MonoBehaviour
{

    [SerializeField] CharacterData characterData;
    protected Animator Anim { get; private set; }
    protected Sprite Sprite { get; private set; }
    public int HP { get; set;}
    public int AttackPower { get; set; }
    public int DefendencePower { get; set; } = 0;
    public float MoveSpeed { get; set; } = 5f;
    public float DamageBuff { get; set; } = 1f;
    public virtual void Initialize()
    {
        Anim = GetComponent<Animator>();
        HP = characterData.HealthPoint;
        AttackPower = characterData.AttackPower;
        DefendencePower = characterData.DefencePower;
        MoveSpeed = characterData.MoveSpeed;
    }


    public virtual void GetHurt(int damage)
    {
        if (HP + DefendencePower <= damage)
        {
            HP = 0;
            StartCoroutine(Die());
        }
        else
        {
            HP -= damage;
        }

    }

    public CharacterData.CharacterType GetCharacterType()
    {
        return characterData.Character_Type;
    }

    public abstract IEnumerator Die();

}

