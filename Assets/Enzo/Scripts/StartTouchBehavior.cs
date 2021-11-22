using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartTouchBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform number in transform)
        {
            number.gameObject.SetActive(true);
            SpriteRenderer numberSprite = number.GetComponent<SpriteRenderer>();
            numberSprite.color = new Color(1f, 1f, 1f, 0f);
            numberSprite.DOFade(1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.timer >= -1.5f)
        {
            foreach (Transform number in transform)
            {
                SpriteRenderer numberSprite = number.GetComponent<SpriteRenderer>();
                numberSprite.DOFade(0f, 1f);
            }
        }
    }
}
