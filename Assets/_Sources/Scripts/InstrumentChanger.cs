using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentChanger : MonoBehaviour
{
    [SerializeField] private ButtonInstrumentChanger[] _btns;

    public void DeselectBtns()
    {
        foreach (var btn in _btns)
        {
            //btn.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            DOTween.Sequence().Append(btn.transform.DOScale(Vector2.one, .3f));
        }
    }  
}
