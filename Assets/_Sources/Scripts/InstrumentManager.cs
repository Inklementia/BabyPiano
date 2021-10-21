using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class InstrumentManager : MonoBehaviour
{
    public Instrument[] _instruments;

    public Instrument CurrentInstrument;

 

    private void Start()
    {
        SetCurrentInstrument(InstrumentType.Piano);
    }

    public void OnKeyPress(int index)
    {
        var note = CurrentInstrument.Notes[index - 1].Source;
        Debug.Log(CurrentInstrument.InstrumentType +": "+ note.name + " is played");
        note.Play();

    }


    public void SetCurrentInstrument(InstrumentType selectedInstrumentType)
    {
        foreach (Instrument ins in _instruments)
        {
            if(ins.InstrumentType == selectedInstrumentType)
            {
                CurrentInstrument = ins;
                Debug.Log(CurrentInstrument.InstrumentType);
            }
        }
    }

}
