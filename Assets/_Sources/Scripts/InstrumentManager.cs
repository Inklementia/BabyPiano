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
