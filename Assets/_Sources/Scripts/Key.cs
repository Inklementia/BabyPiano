using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Key : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private AudioSource _longSound;
    private AudioSource _shortSound;
    private AudioSource _currentSound;
    private Image _keyImage;

    private bool _pointerDown;

    private bool _entered;
    private bool _exited;

    private bool _playLongSound;
    private bool _isLongSoundPlaying;
    private float _pointerDownTimer;
    private float _enterExitTimer;


    [SerializeField] private InstrumentHandler _instrumentHandler;
    [SerializeField] private float _requiredHoldTimerForLongSound = .2f;
    [SerializeField] private int _keyNumber;
    [SerializeField] private Sprite[] _keySprites = new Sprite[2]; //0 normal, 1 pressed

    private void Awake()
    {
        _keyImage = GetComponent<Image>();
    }
    private void Start()
    {
        _longSound = _instrumentHandler.CurrentInstrument.GetLongSound(_keyNumber );
        _shortSound = _instrumentHandler.CurrentInstrument.GetShortSound(_keyNumber);
        
    }
    private void Update()
    {
        if (_entered)
        {
            //Debug.Log(_enterExitTimer);
            _enterExitTimer += Time.deltaTime;
            if(_enterExitTimer < _requiredHoldTimerForLongSound && _exited)
            {
                _currentSound = _shortSound;
                _currentSound.Play();
                ResetKey();
            }
            else if (_enterExitTimer >= _requiredHoldTimerForLongSound && !_isLongSoundPlaying && !_exited)
            {
                StartCoroutine(PlayLongSound());
               
            }else if(_enterExitTimer >= _requiredHoldTimerForLongSound && _exited)
            {
                ResetKey();
            }
                //
         
        }
    }
    private IEnumerator PlayLongSound()
    {
        _isLongSoundPlaying = true;
        _currentSound = _longSound;
        _longSound.Play();
        Debug.Log(_longSound.name + _longSound.isPlaying);
        yield return new WaitForSeconds(_longSound.clip.length);
        _isLongSoundPlaying = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _keyImage.sprite = _keySprites[1];
        //_pointerDownTimer += Time.deltaTime;
        _entered = true;
        Debug.Log("enter: " + _keyNumber);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _exited = true;
        Debug.Log("exit: " + _keyNumber);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pointerDown = true;
        //_pointerDownTimer += Time.deltaTime;
        //Debug.Log("down: " + _keyNumber + " " + _pointerDownTimer);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _pointerDown = false;
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    _keyImage.sprite = _keySprites[1];
    //    _pointerDown = true;
    //    //Debug.Log("note: "+ _longSound.name);

    //    //PlayKeyVisual();

    //    _pointerDownTimer += Time.deltaTime;
    //    if (_pointerDownTimer < _requiredHoldTimerForLongSound)
    //    {
    //        _currentSound = _shortSound;
    //    }
    //    else
    //    {
    //        _currentSound = _longSound;
    //    }

    //    _currentSound.Play();
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{

    //    ResetKey();
    //    //Debug.Log("pointer up");
    //}


    private void ResetKey()
    {
        _keyImage.sprite = _keySprites[0];
        // _currentSound = null;
        _entered = false;
        _exited = false;
        _enterExitTimer = 0f;

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
