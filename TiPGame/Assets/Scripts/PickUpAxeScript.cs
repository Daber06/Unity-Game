using UnityEngine;

public class PickUpAxeScript : MonoBehaviour
{
    public Transform playerHand;  
    public float pickupRange = 1f;  
    public GameObject axe; 
    public bool hasAxe = false;

    void Start()
    {
        Debug.Log("Axe script starting!");
    }

    void Update()
    {
        
        float distanceToAxe = Vector3.Distance(playerHand.position, axe.transform.position);

        if (distanceToAxe <= pickupRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupAxe();
        }

    }

    void PickupAxe()
    {
        axe.transform.SetParent(playerHand);
        axe.transform.localPosition = Vector3.zero;  
        axe.transform.localRotation = Quaternion.identity; 

        axe.GetComponent<Collider>().enabled = false;

        hasAxe = true;
        Debug.Log("Axe picked up!");


    }
}
