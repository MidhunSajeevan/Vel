using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    // Static variable to store volume across scenes
  
    private  float volume = 1.0f;

    // UI slider for volume control
  //  [SerializeField]
    private  Slider volumeSlider;

    private static  AudioSource volumeSource;
    private void Start()
    {
        // Load volume from PlayerPrefs (can be modified based on your saving mechanism)
        volume = PlayerPrefs.GetFloat("SavedVolume", 1.0f);

        volumeSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        volumeSource = GetComponent<AudioSource>();
        // Set the UI slider value to the loaded volume
        volumeSlider.value = volume;
    }

    public void SetVolume(float newVolume)
    {
        // Set volume and save it to PlayerPrefs
        volume = newVolume;
        PlayerPrefs.SetFloat("SavedVolume", volume);

        // Apply the volume (you might want to use AudioManager or similar)
        AudioListener.volume = volume;
    }
    private void Update()
    {
        if (volumeSource == null)
        {
            // Access the AudioSource safely
            volumeSource = GetComponent<AudioSource>();
            volumeSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        }
        else
        {
            volumeSource.volume = volumeSlider.value;
        }
        
    }
}
