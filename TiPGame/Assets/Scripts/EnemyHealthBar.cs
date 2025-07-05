using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public float healthAmount = 100f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(25f);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        Debug.Log("Enemy took damage, remaining health: " + healthAmount);

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Or play death animation, etc.
    }
}
