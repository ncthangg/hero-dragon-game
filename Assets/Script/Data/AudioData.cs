using System;
using UnityEngine;

[Serializable]
public class AudioData
{
    public string name;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;
}
