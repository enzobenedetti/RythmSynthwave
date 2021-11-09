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

    Transform zoneToDisplay;
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
                zoneToDisplay = zone;
                display = Instantiate(displayPrefab, zoneToDisplay.position + Vector3.up/2, Quaternion.identity);
                break;
            }
        }
        if (quality >= 4)
        {
            if (Jauge.isOutRun)
            {
                display.GetComponent<SpriteRenderer>().sprite = outRunSprite;
            }
            else
            {
                display.GetComponent<SpriteRenderer>().sprite = perfectSprite;
            }
        }
        else if (quality == 3)
        {
            display.GetComponent<SpriteRenderer>().sprite = niceSprite;
        }
        else if (quality == 2)
        {
            display.GetComponent<SpriteRenderer>().sprite = okSprite;
        }
        else
        {
            display.GetComponent<SpriteRenderer>().sprite = badSprite;
        }
    }
}
