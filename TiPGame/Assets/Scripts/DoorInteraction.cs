using UnityEngine;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    public Transform teleportTarget; 
    public GameObject player;         

    private bool isPlayerNear = false;    
    private bool isTeleporting = false;  
    private bool hasLogged = false;      

    void Update()
    {
        if (isPlayerNear && !hasLogged)
        {
            Debug.Log("Player is near the door. Waiting for input...");
            hasLogged = true;  
        }

        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.C) && !isTeleporting)
            {
                Debug.Log("C key pressed. Starting teleport...");
                StartCoroutine(TeleportPlayer());
            }
        }
    }

    IEnumerator TeleportPlayer()
    {
    isTeleporting = true;

    Debug.Log("Starting teleportation...");

    Debug.Log("Player position: " + player.transform.position);
    Debug.Log("Teleporting player to: " + teleportTarget.position);
    
    CharacterController cc = player.GetComponent<CharacterController>();
    if (cc != null)
    {
        cc.enabled = false;
        player.transform.position = teleportTarget.position;

        player.transform.localScale *= 1.2f;

        cc.enabled = true;  
    }
    else
    {
        player.transform.position = teleportTarget.position;
}

    Debug.Log("Player position after teleport: " + player.transform.position);

    yield return null;

    isTeleporting = false;  
    Debug.Log("Teleportation finished.");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player entered trigger area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            hasLogged = false; 
            Debug.Log("Player left trigger area.");
        }
    }
}
