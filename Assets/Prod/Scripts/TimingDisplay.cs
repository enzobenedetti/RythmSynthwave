using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class TimingDisplay : MonoBehaviour
{
    public Sprite perfectSprite;
    public Sprite niceSprite;
    public Sprite okSprite;
    public Sprite badSprite;
    public Sprite outRunSprite;
    
    public Transform zonesDisplay;
    public Transform zones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayResult(int index, int quality)
    {
        if (Jauge.isOutRun) foreach (Transform zone in zones)
        {
            if (zone.name == index.ToString())
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(zone.GetComponent<SpriteRenderer>().DOColor(Color.cyan, 0.2f))
                    .Append(zone.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.2f));
                sequence.Play();
            }
        }
        
        GameObject display = null;
        foreach (Transform zone in zonesDisplay)
        {
            if (zone.name == index.ToString())
            {
                display = zone.gameObject;
                break;
            }
        }
        
        display.SetActive(true);

        display.GetComponent<SpriteRenderer>().sprite = quality switch
        {
            4 => Jauge.isOutRun ? outRunSprite : perfectSprite,
            3 => niceSprite,
            2 => okSprite,
            _ => badSprite
        };
    }
}
