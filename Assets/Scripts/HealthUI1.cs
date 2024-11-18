using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthUI1 : MonoBehaviour
{
    public string prefabTag = "Enemy";
    private Health healthScript;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthScript == null)
        {
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);
            if(spawnedPrefab != null ) 
            {
                healthScript = spawnedPrefab.GetComponent<Health>();
            }

        }

    }
    public void DamgeButton()
    {
        if (healthScript != null)
        {

            healthScript.TakeDamage(10);
        
        }

    }

    public void HealButton()
    {
        if (healthScript != null)
        {
            healthScript.RestoreHealth(10);
        }
    }

}
