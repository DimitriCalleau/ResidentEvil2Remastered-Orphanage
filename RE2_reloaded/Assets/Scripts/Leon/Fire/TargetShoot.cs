using UnityEngine;

public class TargetShoot : MonoBehaviour
{
    public float healthCurrent = 50f;

    public void TakeDamage(float amount)
    {
        healthCurrent -= amount;

        if (healthCurrent <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
