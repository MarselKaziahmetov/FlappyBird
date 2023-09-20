using UnityEngine;

class AudioHandler: MonoBehaviour
{
    public static AudioHandler Instance { get; private set; }

    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private AudioSource backgroundSound;
    [SerializeField] private AudioSource deathSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        ChangeVolume();
    }

    public void ChangeVolume()
    {
        if (PlayerPrefs.HasKey("VolumeLevel"))
        {
            float volumeLevel = PlayerPrefs.GetFloat("VolumeLevel");
            scoreSound.volume = volumeLevel;
            backgroundSound.volume = volumeLevel;
            deathSound.volume = volumeLevel;
        }
    }

    public void ScoreSoundPlay()
    {
        scoreSound.Play();
    }

    public void ScoreSoundPause()
    {
        scoreSound.Pause();
    }
 
    public void BackgroundSoundPlay()
    {
        backgroundSound.Play();
    }

    public void BackgroundSoundPause()
    {
        backgroundSound.Stop();
    }
    
    public void DeathSoundPlay()
    {
        deathSound.Play();
    }

    public void DeathSoundPause()
    {
        deathSound.Pause();
    }
}