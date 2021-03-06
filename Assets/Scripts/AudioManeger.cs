using UnityEngine;
using UnityEngine.Audio;
public class AudioManeger : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManeger instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
