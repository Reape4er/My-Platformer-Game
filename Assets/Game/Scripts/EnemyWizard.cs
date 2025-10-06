using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider;
    public Transform attackPoint;
    public GameObject fireballPrefab;
    public LayerMask playerLayers;

    public float fireballForce = 20f;
    public float attackRange = 10f;
    public float attackRate = 0.5f;
    public int attackDamage = 20;
    private float nextAttackTime = 0f;

    void Start()
    {
        animator.SetFloat("MultiplierAttackSpeed", 1 + 1f / attackRate);
    }
    void FixedUpdate()
    {
        if (detectEnemy() && Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Fire");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    bool detectEnemy()
    {
        RaycastHit2D raycastHitLeft = Physics2D.Raycast(boxCollider.bounds.center, Vector2.left, attackRange, playerLayers);
        RaycastHit2D raycastHitRight = Physics2D.Raycast(boxCollider.bounds.center, Vector2.right, attackRange, playerLayers);
        
        if (raycastHitLeft.collider != null)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (raycastHitRight.collider != null)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        return raycastHitLeft.collider != null || raycastHitRight.collider != null;
    }

    void attack()
    {
        GameObject fireball = Instantiate(fireballPrefab, attackPoint.position, attackPoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(attackPoint.right * fireballForce * -1, ForceMode2D.Impulse);
    }
}
