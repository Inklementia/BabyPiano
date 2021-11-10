using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInstrumentChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private InstrumentType _instrumentType;
    [SerializeField] private InstrumentHandler _instrumentManager;
    [SerializeField] private InstrumentChanger _changer;
    public bool ActiveInstrumentBtn { get; private set; }
    private ButtonInstrumentChanger prevBtn;
    private void Start()
    {
        if(_instrumentManager.CurrentInstrument.GetInstrumentType() == _instrumentType)
        {
            SetActiveInstrumentButtonVisual();
        }
    }
    private void SetActiveInstrumentButtonVisual()
    {
        var mySequence = DOTween.Sequence();
        //gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        DOTween.Sequence().Append(transform.DOScale(new Vector2(1.3f, 1.3f), .3f)).Append(transform.DOScale(new Vector2(1.2f, 1.2f), .3f));
     
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _instrumentManager.SetCurrentInstrument(_instrumentType);
        Debug.Log("Cyrrent type: "+_instrumentManager.CurrentInstrument.GetInstrumentType());
        _changer.DeselectBtns();
        SetActiveInstrumentButtonVisual();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
       
    }
}
