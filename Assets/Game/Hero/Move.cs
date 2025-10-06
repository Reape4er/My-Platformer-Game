using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer sprite;
    private BoxCollider2D boxcollider2d;
    public Animator animator;
    private float HorizontalMove = 0f;

    public float speed = 1f;
    public float jumpForce = 8f;
    public bool jumped = false;

    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        boxcollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsGrounded", isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            //animator.SetBool("IsJumped", true);
        }
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        if (HorizontalMove < 0f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (HorizontalMove > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rigidBody2D.velocity.y);
        rigidBody2D.velocity = targetVelocity;
        CheckGround();
    }
    private void CheckGround()
    { 
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(boxcollider2d.bounds.center.x, boxcollider2d.bounds.center.y - boxcollider2d.bounds.extents.y), boxcollider2d.size.x / 2);
        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
