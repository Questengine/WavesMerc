using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public static class d
{

    const int appendthismanytags = 12;
    public static string vs(Vector3 v)
    {
        return "(" + v.x.ToString("#.##") + "," + v.y.ToString("#.##") + "," + v.z.ToString("#.##") + ")";
    }

    public static void l(string txt, Vector3 v1, Vector3 v2)
    {
        txt += " " + vs(v1) + " -- ";
        l(txt, v2);
    }
    public static void l(string txt, Vector3 v)
    {
        txt += " " + vs(v);
        l(txt);

    }
    public static void l(string txt, bool tf)
    {

       l("");
       l("************************************************");
       l("             " + txt);
       l("*************************************************");
       l("");
    }

    public static void l(string txt, string tag)
    {
        string res = txt;
        for (int i = 0; i < appendthismanytags; i++)
        {
            txt += " " + tag;
        }
        l(txt);
    }
    public static void l(string txt)
    {
        Debug.Log( txt);

    }

    //UTILITIES

    public static int RandomIndex(int maxallowed) {

        System.Random rand = new System.Random();
        int res = rand.Next (maxallowed );
        return res;
    }
}
