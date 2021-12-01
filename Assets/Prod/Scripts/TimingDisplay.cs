using System;
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
    public GameObject particule;

    public static bool[] zoneAnimating = new bool[9];
    private float[] timeBalise = new float[9];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int f = 0; f <= timeBalise.Length - 1; f++)
        {
            if (timeBalise[f] <= Timer.timer + 0.4f && zoneAnimating[f])
            {
                timeBalise[f] = float.MaxValue;
                zoneAnimating[f] = false;
            }
        }
    }

    /// <summary>
    /// Feedback d'une notes avec le texte
    /// </summary>
    /// <param name="index">index de la note touché</param>
    /// <param name="quality">qualité de la note touché</param>
    public void DisplayResult(int index, int quality)
    {
        foreach (Transform zone in zones)
        {
            if (zone.name == index.ToString() && quality > 1)
            {
                zoneAnimating[int.Parse(zone.name)-1] = true;
                timeBalise[int.Parse(zone.name)-1] = Timer.timer;
                
                Sequence sequence = DOTween.Sequence();
                sequence.Append(zone.DOShakeScale(0.1f, Jauge.isOutRun ? 3f : 1f, 5, 0f, true).SetEase(Ease.OutElastic))
                    .Append(zone.DOScale(Vector3.one, 2f)).SetEase(Ease.InElastic)
                    .Insert(0f,zone.GetComponent<SpriteRenderer>()
                        .DOColor(Jauge.isOutRun ? Color.cyan : Color.cyan / 2, 0.2f)).SetEase(Ease.OutQuint)
                    .Insert(0.2f, zone.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.2f).SetEase(Ease.InQuint));
                sequence.Play();
                

                if (Jauge.isOutRun) Instantiate(particule, zone.position, Quaternion.identity);
                else
                {
                    GameObject particuleGo =  Instantiate(particule, zone.position, Quaternion.identity);
                    ParticleSystem.EmissionModule emissionModule = particuleGo.GetComponent<ParticleSystem>().emission;
                    emissionModule.rateOverTime = Score.Combo * 20;
                }
                
                break;
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
