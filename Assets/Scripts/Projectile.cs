using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Zoek Health component van target met GetComponent
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            // Roep TakeDamage functie aan om schade toe te passen
            targetHealth.TakeDamage(damage);
        }

        // Instantieer explosie-effect (bijvoorbeeld een deeltje)
        // Zorg ervoor dat je een explosie prefab hebt (bijv. een deeltje of animatie)
        // Als je een prefab hebt voor een explosie, kun je de volgende regel gebruiken:
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Vernietig het projectiel object
        Destroy(gameObject);
    }

    // Voeg een public veld toe om een explosie-effect in te stellen via de Inspector
    public GameObject explosionEffect;
}
