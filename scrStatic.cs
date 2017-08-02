using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public static class s
{
    static public scrHero ship;
    static public scrBurst burst;
    static public scrCannon cannon;
    static public Transform gBwWorld;
    static public Transform gBwTrackingSpace;
    static public Transform gBwCam;




}


public static class u {
    



static public bool LOS(Vector3 a, Vector3 b, int[] layersblockingLOS)
{
    bool res = true;

    RaycastHit[] hits;
    hits = Physics.RaycastAll(a, b - a, Vector3.Magnitude(b - a));
    int i = 0;
    while (i < hits.Length && res)
    {
        RaycastHit hit = hits[i];
            foreach (int layer in layersblockingLOS)
            {
                if (hit.transform.gameObject.layer == layer)
                {
                    res = false;
                }
            }
       
        i++;
    }
    Color tempcolor;
    if (res)
    {
        tempcolor = Color.green;
    }
    else
    {
        tempcolor = Color.red;
    }
    ///  Debug.DrawRay(a, b - a, tempcolor, 12f);
    // s.d("time after LOS" + s.t());
    return res;
}


} 
