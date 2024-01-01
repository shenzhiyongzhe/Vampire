
using System.Collections;
using TMPro;
using UnityEngine;


public class Enemy : Character
{
    PlayerMove player;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        Initialize();
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.sprite = Sprite;
        player = PlayerMove.Instance;
    }
    void Update()
    {
        if (!Anim.GetBool("isDead"))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            if (player.transform.position.x - transform.position.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().GetHurt(AttackPower);
        }

        if (collision.CompareTag("Weapon"))
        {
            GetHurt((int)Mathf.Ceil(collision.GetComponent<Weapon>().AttackPower * Player.Instance.DamageBuff));
        }

    }

    public override void GetHurt(int damage)
    {
        base.GetHurt(damage);
        Anim.SetTrigger("takeHit");
        StartCoroutine(FloatingDamage(damage));
    }
    public override IEnumerator Die()
    {
        Anim.SetBool("isDead", true);
        DropCrystal();
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.6f);

        gameObject.GetComponent<Collider2D>().enabled = true;
        Anim.SetBool("isDead", false);
        gameObject.SetActive(false);
        ObjectPool.ReturnObject(GetCharacterType(), gameObject);
    }

    IEnumerator FloatingDamage(int damage)
    {
        GameObject damageText = ObjectPool.GetObject("damage");
        TextMeshPro textMesh = damageText.GetComponent<TextMeshPro>();
        RectTransform rectTransform = damageText.GetComponent<RectTransform>();

        textMesh.text = damage.ToString();

        rectTransform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, rectTransform.position.z);

        damageText.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        ObjectPool.ReturnObject("damage", damageText);
        damageText.SetActive(false) ;
    }

    void DropCrystal()
    {
        float rand = Random.value;
        //if (rand > luck)
        //{
            GameObject crystal = ObjectPool.GetObject(CrystalData.CrystalType.BlueCrystal);
            crystal.transform.position = transform.position;
            crystal.SetActive(true);

        //}
    }

    private IEnumerator Despeed()
    {
        MoveSpeed *= 0.2f;
        yield return new WaitForSeconds(2f);
        MoveSpeed *= 5f;
    }
    public void AddDebuff_Despeed()
    {
        StartCoroutine(Despeed());
    }
}
