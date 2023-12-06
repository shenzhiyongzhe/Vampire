
using System.Collections;
using TMPro;
using UnityEngine;


public class Enemy : Character
{
    PlayerMove player;

    SpriteRenderer spriteRenderer;

    float luck;

    //bool isDead = false;

    void Awake()
    {
        Initialize();
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.sprite = Sprite;
        player = PlayerMove.GetInstance();
        luck = 0.5f;
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
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().HP -= AttackPower;
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
        ObjectPool.ReturnObject(GetCharacterType(), gameObject);
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        gameObject.GetComponent<Collider2D>().enabled = true;
        Anim.SetBool("isDead", false);
        gameObject.SetActive(false);

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
        Debug.Log("return txt to poo;");
    }

    void DropCrystal()
    {
        float rand = Random.value;
        if (rand > luck)
        {
            GameObject crystal = ObjectPool.GetObject(CrystalData.CrystalType.BlueCrystal);
            crystal.transform.position = transform.position;
            crystal.SetActive(true);

        }
    }
}
