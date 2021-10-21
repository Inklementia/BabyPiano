using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Note
{
    public string Name;
    public AudioClip Clip;
    public AudioMixerGroup Output;
    [HideInInspector] public AudioSource Source;
}
