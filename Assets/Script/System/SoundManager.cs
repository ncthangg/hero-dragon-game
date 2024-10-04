using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Play Music by AudioClip
    /// </summary>
    // public static SoundManager instance { get; private set; }
    // private AudioSource source;

    // void Awake()
    // {
    //     instance = this;
    //     source = GetComponent<AudioSource>();
    // }
    // public void PlaySound(AudioClip _sound)
    // {
    //     source.PlayOneShot(_sound);
    // }


    /// <summary>
    /// Play Music by Name
    /// </summary>
    public List<AudioData> audios;
    void Awake()
    {
        foreach (var audio in audios)
        {
            var source = gameObject.AddComponent<AudioSource>();
            source.clip = audio.clip;
            audio.source = source;
        }
    }

    public void Play(string name)
    {
        var audio = audios.Find(a => a.name == name);

        if (audio != null)
            audio.source.Play();
    }

}
