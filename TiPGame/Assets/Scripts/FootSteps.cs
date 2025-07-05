using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource footstepsSound;
    private float stepTimer = 999f;
    private float jumpCooldown = 0f; // Cooldown timer for jump

    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        bool isJumping = Input.GetKey(KeyCode.Space);

        // Start cooldown when jumping
        if (isJumping)
        {
            jumpCooldown = 1.5f; 
        }

        if (isMoving && jumpCooldown <= 0f)
        {
            float interval = Input.GetKey(KeyCode.LeftShift) ? 0.25f : 0.5f;
            float pitch = Input.GetKey(KeyCode.LeftShift) ? 2f : 1.2f;

            stepTimer += Time.deltaTime;

            if (stepTimer >= interval)
            {
                footstepsSound.pitch = pitch;
                footstepsSound.Play();
                stepTimer = 0f;
            }
        }

        // Decrease the cooldown over time
        jumpCooldown -= Time.deltaTime;
    }
}
