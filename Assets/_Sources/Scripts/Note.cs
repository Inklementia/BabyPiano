using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Note
{
    public string Name;
    public AudioClip LongSound;
    public AudioClip ShortSound;

    public AudioMixerGroup Output;
    public AudioSource SourceForLongSound { get; set; }
    public AudioSource SourceForShortSound { get; set; }
}
