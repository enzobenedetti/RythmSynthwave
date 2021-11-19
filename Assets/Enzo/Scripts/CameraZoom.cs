using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float dollyZoom;
    private float distance;
    private float _frustumHeight;

    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        distance = -camera.transform.position.z;
        _frustumHeight = GetFrustumHeight();
    }

    

    // Update is called once per frame
    void Update()
    {
        camera.transform.DOMoveZ(((Jauge.jauge / 2f) + 1f) - 52f, 0.2f).SetEase(Ease.Linear);
        distance = -(((Jauge.jauge / 2f) + 1f) - 52f);
        camera.DOFieldOfView(GetFieldOfView(), 0.2f).SetEase(Ease.Linear);
        
    }
    private float GetFrustumHeight()
    {
        return (2f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }
    float GetFieldOfView()
    {
        return (2f * Mathf.Atan(_frustumHeight * 0.5f / distance) * Mathf.Rad2Deg);
    }
}
