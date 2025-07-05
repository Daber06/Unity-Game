using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 

public class LightZoneTrigger : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; 
    public AudioSource lightZoneSound; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (postProcessVolume != null)
            {
                var colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
                colorGrading.postExposure.value = 0f; // Reset to normal lighting
            }

            if (lightZoneSound != null && !lightZoneSound.isPlaying) 
            {
                lightZoneSound.Play(); 
            }
        }
    }
}
