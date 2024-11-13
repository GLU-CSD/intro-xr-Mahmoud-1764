using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthbarfill;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void UpdateHealthBar()
    {
        healthbarfill.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0,maxHealth);
        UpdateHealthBar();
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
}
