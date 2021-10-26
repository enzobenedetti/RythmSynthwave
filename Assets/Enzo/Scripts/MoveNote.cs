using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour
{
    public static float speed = 2f;

    public NoteType NoteType;
    // Start is called before the first frame update
    void Start()
    {
        if (NoteType.direction == Vector3.zero)
            transform.localScale = new Vector3(3, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        NoteType.Movement(this.transform, speed);
    }
}
