using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private float healthPercentage;
    public void ChangeHealth(int currentHealth)
    {
        healthPercentage = (float) currentHealth / maxHealth;
        if (healthPercentage <= 0) { healthPercentage = 0; }
        transform.Find("Bar").localScale = new Vector3(healthPercentage, 1);
    }
}
