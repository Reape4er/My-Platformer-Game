using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public int damage = 20;
    public bool kills = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemies")
        if (kills)
            {
                collision.gameObject.GetComponent<CharacterState>().animator.SetBool("IsDead",true);
            }
        else
            {
                collision.gameObject.GetComponent<CharacterState>().TakeDamage(damage);
            }
        
    }
}