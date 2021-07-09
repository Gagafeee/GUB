using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public AudioMixerGroup soundEffectMixer;
    public AudioMixerGroup soundMusicMixer;
    public static AudioManager instance;
    public AudioMixer audioMixer;
    public AudioClip menuMusique;
    public AudioClip creditMusique;
    public bool FirstLevel = true;




private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            var audiomanager = GameObject.FindGameObjectWithTag("AudioManager");
            Destroy(audiomanager);
            Debug.LogWarning("Patched !");
            
        }

        instance = this;
        
    }


    public void SelectPlaylist(string scene)
    {
        if (FirstLevel)
        {
            switch (scene)
            {
                case "MainMenu":
                    audioSource.clip = menuMusique;
                    audioSource.Play();
                    Debug.Log("Playing1");
                    return;
                case "Credits":
                    audioSource.clip = creditMusique;
                    audioSource.Play();
                    Debug.Log("Playing2");
                    return;
            }

            for (var i = 0; i < 10; i++)
            {
                if (SceneManager.GetActiveScene().name != "Level" + i) continue;
                audioSource.clip = playlist[0];
                audioSource.Play();
                Debug.Log("Playing3");
                return;
            }

            Debug.LogError("AudioManager Doesn't work !");
        }
        Debug.Log("Ignoring audio");


    Debug.LogError("AudioManager Doesn't work [PlaylistSelect]");
    }

    private void Update()
    {
        if (audioSource.isPlaying) return;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            audioSource.clip = menuMusique;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().name == "Credits")
        {
            Debug.LogError("Musique is down");
        }
        
        if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "Credits")
        {
           PlayNextSong(); 
        }
        
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGo = new GameObject("TempAudio");
        tempGo.transform.position = pos;
        AudioSource audioSource = tempGo.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGo, clip.length);
        return audioSource;
    }
}