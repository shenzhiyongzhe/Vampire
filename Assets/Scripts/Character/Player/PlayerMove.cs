using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private InputController inputController;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed;

    Vector3 move;
    public Vector3 moveDirection => move;
    public Vector2 lastDirection;

    private static PlayerMove instance;
    public static PlayerMove Instance => instance;

    void Awake()
    {
        inputController = new InputController();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastDirection = Vector2.right;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        move = inputController.Player.Move.ReadValue<Vector2>();
        transform.position += move * moveSpeed * Time.deltaTime;
        if(move.x != 0 || move.y != 0)
        {
            animator.SetBool("isMove", true);
            if(move.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else {
                spriteRenderer.flipX = true;
            }
            lastDirection = move;
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }

    private void OnEnable()
    {
        inputController.Player.Enable();
    }
    private void OnDisable()
    {
        inputController.Player.Disable(); 
    }

    


}
