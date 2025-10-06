using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject EnemyBandit;
    public Transform attackPoint;
    public Transform detectionRange;
    public LayerMask playerLayers;

    public float attackRange = 0.5f;
    public float detectRange = 1f;
    public int attackDamage = 20;
    public float attackRate = 3f;
    private float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("MultiplierAttackSpeed", 1 + 1f * attackRate);
    }

    void FixedUpdate()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(detectionRange.position, detectRange, playerLayers);
        if (hitPlayers.Length != 0 && Time.time >= nextAttackTime)
        {
            if (hitPlayers[0].GetComponent<Transform>().position.x > EnemyBandit.GetComponent<Transform>().position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }    
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<CharacterState>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(detectionRange.position, detectRange);
    }
}
