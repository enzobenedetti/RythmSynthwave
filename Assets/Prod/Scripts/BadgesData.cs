using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BadgesData
{
    public int[] badgesId = new int[3];

    public BadgesData(int[] ids)
    {
        badgesId[0] = ids[0];
        badgesId[1] = ids[1];
        badgesId[2] = ids[2];
    }
}
