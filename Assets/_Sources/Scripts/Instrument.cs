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
            // creating audiosource for long sound
            note.SourceForLongSound = gameObject.AddComponent<AudioSource>();
            note.SourceForLongSound.clip = note.LongSound;

            note.SourceForLongSound.outputAudioMixerGroup = note.Output;

            // creating audiosource for short sound
            note.SourceForShortSound = gameObject.AddComponent<AudioSource>();
            note.SourceForShortSound.clip = note.ShortSound;

            note.SourceForShortSound.outputAudioMixerGroup = note.Output;
        }

    }


}
