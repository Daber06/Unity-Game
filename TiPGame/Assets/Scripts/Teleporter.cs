using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public GameObject player;

    void OnTriggerEnter(Collider other) 
    {
            Debug.Log("hej");
        if (other.CompareTag("Player"))
        {
            Debug.Log("hej");
            player.SetActive(false);
            player.transform.position = destination.position;  
            player.SetActive(true);
        }
    }
}