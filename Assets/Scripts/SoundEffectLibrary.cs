using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private soundEffectGroup[] soundEffectGroups;
    private Dictionary<string, List<AudioClip>> soundDictionary;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        InitializeDictionary();
    }
    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioClip>>();
        foreach (soundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.audioClips;
        }
        
    }
    public AudioClip GetRandomClip(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundDictionary[name];
            if (audioClips.Count > 0)
            {
                return audioClips[Random.Range(0, audioClips.Count)];
            }    
        }
        return null;
    }

    [System.Serializable]
    public struct soundEffectGroup
    {
        public string name;
        public List<AudioClip> audioClips;
    }
}