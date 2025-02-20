using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager instance;
    private static AudioSource AudioSource;
    private static SoundEffectLibrary soundEffectLibrary;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            AudioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void Play(string soundName)
    {
        AudioClip audioClips = soundEffectLibrary.GetRandomClip(soundName);
        if(audioClips != null)
        {
            AudioSource.PlayOneShot(audioClips);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
}
