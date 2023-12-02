using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] songs;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if an instance of this script already exists
        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();
        if (musicPlayers.Length > 1)
        {
            Destroy(gameObject);  // Destroy duplicate instances
        }
        else
        {
            DontDestroyOnLoad(gameObject);  // Don't destroy when loading a new scene
            DontDestroyOnLoad (audioSource);// Don't destroy when loading a new scene
            PlayRandomSong();
            
        }
    }

    private void Update()
    {
        //Cheak if the audio is completed playing and play next song
        if (!audioSource.isPlaying)
        {
            PlayRandomSong();
        }
    }
    void PlayRandomSong()
    {
        //select random song and play
        if (songs.Length > 0)
        {
            int randomIndex = Random.Range(0, songs.Length);
            audioSource.clip = songs[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No songs assigned!");
        }
    }
}
