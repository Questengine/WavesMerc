using UnityEngine;
using System.Collections;
public enum BurstStage{off, warmburst,warmproj,coolproj, coolburst}
public class scrBurst : MonoBehaviour
{

    // Use this for initialization
    public int count=3;
    private int index;
    public float warmup = 1;
    public float cooldown = 1;
    public float singlewarmup = 1;
    public float singlecooldown = 1;
    private BurstStage state;
    private float age;
    public int consumption;
    void Start()
    {
        state =  BurstStage.off;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool TimeToFire()
    {
        float curtime = Time.realtimeSinceStartup;
        bool res = false;
        if (s.ship.ammocur >= consumption)
        {
                
        if (state == BurstStage.off)
        {
            age = curtime;
            state = BurstStage.warmburst ;
            //d.l(" warm burst Start","->");
            index = 0;
        }
        else
        {
            if (state == BurstStage.warmburst)
            {
                if (age + warmup < curtime)
                {
                    age = curtime;
                    state = BurstStage.warmproj;
                    //d.l(" warmproj");
                }
            }
            if (state == BurstStage.warmproj)
            {
                if (age + singlewarmup < curtime)
                {
                    age = curtime;
                    state = BurstStage.coolproj ;
                        s.ship.ConsumeAmmo(consumption);
                    res = true;
                    index++;
                    //d.l(" fireing,  burstindex " + index );
                    //d.l("coool proj");
                }
            }
            if (state == BurstStage.coolproj )
            {
                if (age + singlecooldown < curtime)
                {
                    age = curtime;
                    if (index < count)
                    {
                        //d.l("next projectile in this burst");
                        state = BurstStage.warmproj;
                    }
                    else
                    {
                        state = BurstStage.coolburst;
                        //d.l("coolburst");
                    }
                }
            }
            if (state == BurstStage.coolburst )
            {
                if (age + warmup < curtime)
                {
                    age = curtime;
                    state = BurstStage.off;
                    //d.l("burst stop", "O");
                }
            }
        }
        }

        return res;
    }
    public void Stop()
    {
        age = Time.realtimeSinceStartup; 
        state = BurstStage.coolburst;
        //d.l("burst Stopped prematurely");

    }
}
