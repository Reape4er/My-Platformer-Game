using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterState : MonoBehaviour
{
    public Animator animator;
    public KillScore killScore;
    public HealthBarScript healthBarScript;

    public int maxHealth;
    public int currentHealth;
    public bool Invulnerability = false;
    public float invulnerabilityTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarScript.maxHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (Time.time >= invulnerabilityTime)
        {
            Invulnerability = false;
        }
        else
        {
            Invulnerability = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0 && Invulnerability == false)
        {
            currentHealth -= damage;
            healthBarScript.ChangeHealth(currentHealth);

            animator.SetTrigger("Hurt");
        }
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Player")
            {
                gameObject.GetComponent<Combat>().enabled = false;
                gameObject.GetComponent<Move>().enabled = false;
            }
            animator.SetBool("IsDead", true);
        }
    }

    public void die()
    {
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            Debug.Log("mission restart because you died");
        }
        if (gameObject.tag == "Enemies")
        {
            killScore.addScore();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
