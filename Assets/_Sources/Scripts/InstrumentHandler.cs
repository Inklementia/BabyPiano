using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class InstrumentHandler : MonoBehaviour
{
    [SerializeField] private Instrument[] _instruments;

    public Instrument CurrentInstrument { get; private set; }

    private void Awake()
    {
        SetCurrentInstrument(InstrumentType.Piano);
    }

    public void SetCurrentInstrument(InstrumentType selectedInstrumentType)
    {
        foreach (Instrument ins in _instruments)
        {
            if(ins.GetInstrumentType() == selectedInstrumentType)
            {
                CurrentInstrument = ins;
                Debug.Log(CurrentInstrument.GetInstrumentType());
            }
        }
    }

}
