using UnityEngine;

public class DamagedBarDamage : MonoBehaviour
{
    private int hitCount = 0;  // Number of hits taken by the metal bar

    public void TakeDamage()
    {
        hitCount++;
        Debug.Log("Hit " + hitCount + " times.");

        // First hit: Change the bar to the dented version
        if (hitCount == 1)
        {
            RemoveBar();
        }
    }

    void RemoveBar()
    {
        Destroy(gameObject);
    }
}
