
using System.Collections;
using TMPro;
using UnityEngine;


public class Enemy : Character
{
    PlayerMove player;

    SpriteRenderer spriteRenderer;

    bool isCoroutin;

    void Awake()
    {
        Initialize();
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.sprite = Sprite;
        player = PlayerMove.GetInstance();
    }
    void Update()
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
        StartCoroutine(FloatingDamage(damage));
    }
    public override void Die()
    {
        Anim.SetBool("isDead", true);
        ObjectPool.ReturnObject(GetCharacterType(), gameObject);
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
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
        yield return new WaitForSeconds(0.1f);

        ObjectPool.ReturnObject("damage", damageText);
    }

    IEnumerator WaitSecond(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

}
