using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static bool IsValid(this GameObject go)
    {
        return go != null && go.activeSelf;
    }
}
