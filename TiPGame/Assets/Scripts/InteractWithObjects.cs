using UnityEngine;

public class InteractWithObjects : MonoBehaviour
{
    public float pickUpRange = 2f;
    public Transform playerHand;
    public AudioSource audioSource;
    public GameObject voiceBox;
    public bool hasPlayedAudio = false;

    void Update(){
        float distanceToVoiceBox = Vector3.Distance(playerHand.position, voiceBox.transform.position);
        if (distanceToVoiceBox <= pickUpRange && Input.GetKeyDown(KeyCode.C))
        {
            VoiceBox();
        }
    }
    void VoiceBox(){
        audioSource.enabled = true;
        audioSource.Play();
        hasPlayedAudio = true;
    }

}
