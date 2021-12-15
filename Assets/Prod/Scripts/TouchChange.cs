using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchChange : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Image _image;
    public Sprite NumSprite;
    public Sprite LetterSprite;

    private static bool NumActive = true;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _sprite = TryGetComponent(out SpriteRenderer renderer) ? renderer : null;
        _image = TryGetComponent(out Image image) ? image : null;
        if (_sprite) _sprite.sprite = NumActive ? NumSprite : LetterSprite;
        if (_image) _image.sprite = NumActive ? NumSprite : LetterSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) 
                || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Keypad7)
                || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad9))
            {
                NumActive = true;
                if (_sprite) _sprite.sprite = NumSprite;
                if (_image) _image.sprite = NumSprite;

            }
            else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V) ||
                     Input.GetKeyDown(KeyCode.D)
                     || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.E) ||
                     Input.GetKeyDown(KeyCode.R)
                     || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Space))
            {
                NumActive = false;
                if (_sprite) _sprite.sprite = LetterSprite;
                if (_image) _image.sprite = LetterSprite;
            }
        }
        Debug.Log(NumActive);
    }

    private void OnEnable()
    {
        if (!_sprite && TryGetComponent(out SpriteRenderer renderer)) _sprite = renderer;
        if (!_sprite && TryGetComponent(out Image image)) _image = image;
        if (_sprite) _sprite.sprite = NumActive ? NumSprite : LetterSprite;
        if (_image) _image.sprite = NumActive ? NumSprite : LetterSprite;
    }
}
