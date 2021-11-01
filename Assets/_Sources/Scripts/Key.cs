using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Key : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private AudioSource _longSound;
    private AudioSource _shortSound;
    private AudioSource _currentSound;

    private bool _pointerDown;
    private float _pointerDownTimer;

    [SerializeField] private InstrumentHandler _instrumentHandler;
    [SerializeField] private float _requiredHoldTimerForLongSound = .2f;
    [SerializeField] private int _keyNumber;

    private void Start()
    {
        _longSound = _instrumentHandler.CurrentInstrument.GetLongSound(_keyNumber );
        _shortSound = _instrumentHandler.CurrentInstrument.GetShortSound(_keyNumber);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _pointerDown = true;
        //Debug.Log("note: "+ _longSound.name);

        //PlayKeyVisual();

        _pointerDownTimer += Time.deltaTime;
        if (_pointerDownTimer < _requiredHoldTimerForLongSound)
        {
            _currentSound = _shortSound;
        }
        else
        {
            _currentSound = _longSound;
        }

        _currentSound.Play();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
     
        ResetKey();
        //Debug.Log("pointer up");
    }

    private void ResetKey()
    {
        _pointerDown = false;
        _pointerDownTimer = 0f;   
    }

    //private void PlayKeyVisual()
    //{
    //    ////KeySprite.color = new Color32(0, 0, 0, 100);
    //    //KeySprite.color = Color.Lerp(_originalColour, _colour, _timer);

    //    //_timer += Time.deltaTime;

    //    if (fadeStart < fadeTime)
    //    {
    //        fadeStart += Time.deltaTime * fadeTime;

    //        KeySprite.color = Color.Lerp(_originalColour, _colour, fadeStart);
    //    }
    //}


    //private void FadeNote()
    //{
    //    if (Note.isPlaying)
    //    {
    //        Note.volume -= Time.deltaTime;

    //        if (Note.volume <= 0)
    //            Note.Stop();
    //    }
    //}
}
