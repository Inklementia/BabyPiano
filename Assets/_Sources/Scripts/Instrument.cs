using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    [SerializeField] protected InstrumentType InstrumentType;
    // all keys
    [SerializeField] protected Note[] Notes;

    private InstrumentHandler _instrumentHandler;

    private void Awake()
    {
        _instrumentHandler = GetComponentInParent<InstrumentHandler>();
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
           // Debug.Log(note.Name);

        }
       
    }
    public InstrumentType GetInstrumentType()
    {
        return InstrumentType;
    }
    public AudioSource GetLongSound(int keyNumber)
    {
        return _instrumentHandler.CurrentInstrument.Notes[keyNumber - 1].SourceForLongSound;
    }

    public AudioSource GetShortSound(int keyNumber)
    {
        return _instrumentHandler.CurrentInstrument.Notes[keyNumber - 1].SourceForShortSound;
    }
}
