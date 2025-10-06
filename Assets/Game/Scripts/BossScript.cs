using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Animator animator;
    public Transform castPoint;
    public Transform attackPoint;
    public LayerMask playerLayers;
    //private Collider2D[] hitPlayers;
    public GameObject spellPrefab;
    private Vector3 playerPosition;

    public float castRange = 10f;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public float castRate = 1f;
    private float nextAttackTime = 0f;

    public int attackDamage = 40;
    public int spellDamage = 20;

    private void Start()
    {
        animator.SetFloat("MultiplierAttackSpeed",  1f * attackRate);
    }
    private void FixedUpdate()
    {
        Collider2D[] casthitPlayers = Physics2D.OverlapCircleAll(castPoint.position, castRange, playerLayers);
        Collider2D[] attackhitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        if (casthitPlayers.Length != 0 && casthitPlayers[0].GetComponent<Transform>().position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        if (Time.time >= nextAttackTime)
        {
            if (attackhitPlayers.Length != 0)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else if (casthitPlayers.Length != 0)
            {
                animator.SetTrigger("Cast");
                nextAttackTime = Time.time + 1f / castRate;
            }
        }
    }
    public void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        if (hitPlayers.Length != 0)
        {
            hitPlayers[0].GetComponent<CharacterState>().TakeDamage(attackDamage);
        }
    }
    
    public void Cast()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(castPoint.position, castRange, playerLayers);
        if (hitPlayers.Length != 0)
        {
            playerPosition = hitPlayers[0].GetComponent<Transform>().position;
            playerPosition.x += 0.2f;
            playerPosition.y += 1.8f;
            GameObject spell = Instantiate(spellPrefab, playerPosition, hitPlayers[0].GetComponent<Transform>().rotation);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(castPoint.position, castRange);
    }
}
