using UnityEngine;
using UnityEngine.AI;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionForce = 500f;       // Kracht van de explosie
    public float explosionRadius = 5f;        // Radius van de explosie
    public float explosionDamage = 50f;       // Hoeveelheid schade die de explosie veroorzaakt

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Zorg dat vijanden de tag "Enemy" hebben
        {
            Explode();
            Destroy(gameObject); // Verwijder het object na de explosie
        }
    }

    void Explode()
    {
        // Vind alle objecten in de buurt van de explosie
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            // NavMeshAgent uitschakelen voor vijanden die getroffen zijn door de explosie
            NavMeshAgent agent = nearbyObject.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.enabled = false;
            }

            // Schade toebrengen aan vijanden binnen de explosie-radius
            Health healthScript = nearbyObject.GetComponent<Health>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(explosionDamage); // Breng de explosieschade toe aan de vijand
            }

            // Explosiekracht toevoegen aan objecten met een Rigidbody
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}