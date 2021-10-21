using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instrument : MonoBehaviour
{
    public InstrumentType InstrumentType;
    // white keys
    public Note[] Notes;


    private void Awake()
    {
        // audio clips to AudioSource component
        foreach (Note note in Notes)
        {
            note.Source = gameObject.AddComponent<AudioSource>();
            note.Source.clip = note.Clip;

            note.Source.outputAudioMixerGroup = note.Output;
        }


    }
}
