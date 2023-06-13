using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutsceneaudio : MonoBehaviour
{
    public AudioClip[] audioClips;  // Array of audio clips
    public Image[] images;          // Array of images
    public float imageDuration = 2f; // Duration of each image display
    public float audioDelay = 1f;    // Delay before playing each audio clip

    private AudioSource audioSource;
    private int currentImageIndex = 0;
    private int currentAudioIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayCutscene());
    }

    private System.Collections.IEnumerator PlayCutscene()
    {
        while (currentImageIndex < images.Length)
        {
            // Display the current image
            images[currentImageIndex].gameObject.SetActive(true);

            // Play the audio clip with a delay
            if (currentAudioIndex < audioClips.Length)
            {
                audioSource.clip = audioClips[currentAudioIndex];
                audioSource.PlayDelayed(audioDelay);
                currentAudioIndex++;
            }

            // Wait for the image duration
            yield return new WaitForSeconds(imageDuration);

            // Hide the current image
            images[currentImageIndex].gameObject.SetActive(false);

            // Move to the next image
            currentImageIndex++;
        }

        // Reset the current indices
        currentImageIndex = 0;
        currentAudioIndex = 0;
    }
}
