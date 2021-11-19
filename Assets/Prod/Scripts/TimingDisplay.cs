using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingDisplay : MonoBehaviour
{
    public Sprite perfectSprite;
    public Sprite niceSprite;
    public Sprite okSprite;
    public Sprite badSprite;
    public Sprite outRunSprite;
    
    public Transform zones;
    public GameObject displayPrefab;

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
        GameObject display = null;
        foreach (Transform zone in zones)
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
