using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    public BossScript bossScript;
    public LayerMask playerLayers;
    public void hit()
    {
        //RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, 1f, playerLayers);
        Vector2 boxsize = new Vector2(2, 2);
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, boxsize, 0, Vector2.down, 3, playerLayers);
        if (raycastHit.collider != null)
        {
            raycastHit.collider.GetComponent<CharacterState>().TakeDamage(bossScript.spellDamage);
        }
        Destroy(gameObject, 0.5f);
    }
}
