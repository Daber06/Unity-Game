using UnityEngine;
using System.Collections;

public class AxeSwing : MonoBehaviour
{
    public Transform playerHand; 
    public float swingDuration = 0.15f; 
    public float returnDuration = 0.1f; 
    public Vector3 startRotationEuler = new Vector3(0, 0, 0); 
    public Vector3 swingRotationEuler = new Vector3(80f, 45f, 0f);

    private bool isSwinging = false;
    private bool canDealDamage = false; 
    private PickUpAxeScript pickUpAxeScript; 

    void Start()
    {
      
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            pickUpAxeScript = player.GetComponent<PickUpAxeScript>();
        }
    }

    void Update()
    {
        if (pickUpAxeScript != null && pickUpAxeScript.hasAxe && !isSwinging && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Swing());
        }
    }

    IEnumerator Swing()
    {
        isSwinging = true;
        canDealDamage = true; 

        Quaternion startRotation = Quaternion.Euler(startRotationEuler);
        Quaternion swingRotation = Quaternion.Euler(swingRotationEuler);

        float elapsed = 0f;

        
        while (elapsed < swingDuration)
        {
            float t = elapsed / swingDuration; 
            float easedT = t * t; 
            transform.localRotation = Quaternion.Slerp(startRotation, swingRotation, easedT);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = swingRotation;

  
        yield return new WaitForSeconds(0.05f);
        canDealDamage = false;

    
        elapsed = 0f;
        while (elapsed < returnDuration)
        {
            float t = elapsed / returnDuration; 
            float easedT = 1 - Mathf.Pow(1 - t, 2); 
            transform.localRotation = Quaternion.Slerp(swingRotation, startRotation, easedT);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = startRotation;

        isSwinging = false;
    }

private void OnCollisionEnter(Collision collision)
{
    if (canDealDamage)
    {
        if (collision.gameObject.CompareTag("MetalPole"))
        {
            MetalBarDamage metalBar = collision.gameObject.GetComponent<MetalBarDamage>();
            if (metalBar != null)
            {
                metalBar.TakeDamage();
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealthBar enemyHealth = collision.gameObject.GetComponent<EnemyHealthBar>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(25f); 
            }
        }
    }
}
}