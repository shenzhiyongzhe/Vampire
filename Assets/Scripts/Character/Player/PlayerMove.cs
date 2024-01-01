using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Player player;
    private float moveSpeed;

    [SerializeField] GameObject resumeWindow;
    [SerializeField] GameObject gmMenu;

    Vector3 moveInput;


    public bool IsFacingRight { get; private set; } = true;

    public static PlayerMove Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveSpeed = player.MoveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (!animator.GetBool("isDead"))
            rb.velocity = moveSpeed * moveInput;
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetBool("isMove", true);
            if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                IsFacingRight = true;
            }
            else if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                IsFacingRight = false;
            }
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }

    public void OpenQuitMenu()
    {
        if (resumeWindow.activeSelf)
        {
            resumeWindow.SetActive(false);
        }
        else
        {
            resumeWindow.SetActive(true);
        }
    }

    public void OpenGM()
    {
        if (gmMenu.activeSelf)
        {
            gmMenu.SetActive(false);
        }
        else { gmMenu.SetActive(true); }
    }

}
