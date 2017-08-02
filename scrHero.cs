using UnityEngine;
using System.Collections;
using System;

public class scrHero : MonoBehaviour {

    public float firedelay;
    public int ammocur =1000;
    private int ammomox;
    private float lastshot = 0;
    private ParticleSystem pfxShield;
    private ParticleSystem pfxThrust;
    public int hp;

    // Use this for initialization
    void Start () {
        ParticleSystem[] pfxSystems = gameObject.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem pfx in pfxSystems) {
            if (pfx.name == "pfxForceField") {
                pfxShield = pfx;
            }
            if (pfx.name == "pfxThrust")
            {
                pfxThrust = pfx;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnTriggerEnter(Collider col) {
        d.l("Heor OnTriggerEnter "+ col.gameObject.name );
        pfxShield.startColor = Color.red ;
    }
    void OnTriggerExit(Collider col) {
        pfxShield.startColor = Color.blue;
    }

   public  void    ConsumeAmmo(int cost)
    {
        ammocur -= cost;

    }
    public string Ammo()
    {
        return ammocur.ToString();
    }
    public void AddAmmo(int val)
    {
        ammocur += val;
    }
    public void AddHealth(int val)
    {
        hp += val;
    }
    public void AddTime(int val)
    {
        //ammocur += val;
    }

}
