using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelChanger : MonoBehaviour
{
    public GameObject levelObject;
    public Material levelMaterial;
    public Material invisibleMaterial;

    public Light lightLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelObject.transform.localScale = new Vector3(1f, 1f, Jauge.jauge / 100f);
        if (levelObject.TryGetComponent(out MeshRenderer actualMaterial))
            actualMaterial.material.Lerp(invisibleMaterial, levelMaterial, Jauge.jauge / 100f);
        else
        {
            foreach (Transform child in levelObject.transform)
            {
                MeshRenderer childMaterial = child.GetComponent<MeshRenderer>();
                childMaterial.material.Lerp(invisibleMaterial, levelMaterial, Jauge.jauge / 100f);
            }
        }
        lightLevel.intensity = Jauge.jauge / 100f;
    }
}
