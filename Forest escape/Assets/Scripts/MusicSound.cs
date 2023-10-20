using UnityEngine;

public class MusicSound : MonoBehaviour
{
    public AudioClip[] musicTracks;
    public AudioSource audioSource;
    private int currentTrack = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        int randomTrack = Random.Range(0, musicTracks.Length);
        audioSource.clip = musicTracks[randomTrack];
        audioSource.Play();
    }
}
