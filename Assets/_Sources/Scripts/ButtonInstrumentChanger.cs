using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInstrumentChanger : MonoBehaviour
{
    [SerializeField] private InstrumentType _instrumentType;
    [SerializeField] private InstrumentHandler _instrumentManager;

    public void ChangeCurrentInstrument()
    {
        Debug.Log(_instrumentType);
        //_instrumentManager.SetCurrentInstrument(_instrumentType);

    }
}
