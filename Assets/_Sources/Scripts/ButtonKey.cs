using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonKey : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private InstrumentManager _instrumentManager;
    private AudioSource _note;
    private bool _keyDown;
    private float _keyDownTimer;

    public float requiredHoldTimer = 1;
    public UnityEvent onLongClick;

    

    private void Start()
    {
        _note = _instrumentManager.CurrentInstrument.Notes[0].Source;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        _keyDown = true;
        _note.Play();
        Debug.Log("key down");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("key up");
    }

    private void Update()
    {
        if (_keyDown)
        {
            _keyDownTimer += Time.deltaTime;
            if (_keyDownTimer > requiredHoldTimer)
            {
            
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                Reset();
            }

          
            _note.pitch = _keyDownTimer / requiredHoldTimer;

        }
        //if (Input.GetKeyDown("2"))
        //{
        //    targetPitch = 10f;
        //}

        //if (Input.GetKeyUp("2"))
        //{
        //    targetPitch = 0f;
        //}
        //_note.pitch = Mathf.Lerp(_note.pitch, targetPitch, incrementPitch * Time.deltaTime);

    }

    private void Reset()
    {
        _note.pitch = _keyDownTimer / requiredHoldTimer;
        _keyDown = false;
        _keyDownTimer = 0f;

        //_note.pitch = 1;
    }

}
