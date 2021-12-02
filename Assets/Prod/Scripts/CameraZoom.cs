using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float dollyZoom;
    private float distance;
    private float _frustumHeight;

    public Camera gameCam;
    // Start is called before the first frame update
    void Start()
    {
        distance = -gameCam.transform.position.z;
        _frustumHeight = GetFrustumHeight();
    }

    

    // Update is called once per frame
    void Update()
    {
        gameCam.transform.DOMoveZ(Mathf.Pow(Jauge.jauge / 2f, 1.1f) - 76f, 0.2f).SetEase(Ease.Linear);
        distance = -(Mathf.Pow(Jauge.jauge / 2f, 1.1f) - 76f);
        gameCam.DOFieldOfView(GetFieldOfView(), 0.2f).SetEase(Ease.Linear);
        
    }
    private float GetFrustumHeight()
    {
        return (2f * distance * Mathf.Tan(gameCam.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }
    float GetFieldOfView()
    {
        return (2f * Mathf.Atan(_frustumHeight * 0.5f / distance) * Mathf.Rad2Deg);
    }
}
