using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Jauge
{
    private static int _jauge = 50;

    public static int jauge
    {
        get => _jauge;
        set
        {
            _jauge = value;
            if (_jauge >= 0 && _jauge <= 100) return;
            if (_jauge < 0) _jauge = 0;
            if (_jauge > 100) _jauge = 100;
        }
    }

    public static void Add()
    {
        jauge++;
    }

    public static void Remove()
    {
        jauge -= 3;
    }

    public static void Reset()
    {
        jauge = 50;
    }
}
