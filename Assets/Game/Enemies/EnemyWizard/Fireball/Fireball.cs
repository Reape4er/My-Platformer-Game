using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public EnemyWizard enemyWizard;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterState>().TakeDamage(enemyWizard.attackDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Enemies")
        {
            Destroy(gameObject);
        }
    }
}
