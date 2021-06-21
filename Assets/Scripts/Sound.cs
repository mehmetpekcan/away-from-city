using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
