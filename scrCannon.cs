using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class scrCannon : MonoBehaviour {

    // Use this for initialization

    private List<Transform> barrels;
    private float burstbirth;
	void Start () {
        barrels = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Barrel")
            {
                barrels.Add(child);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 ship = s.ship.transform.position;
        Vector3 hmd = s.gBwCam.position;
         
            Debug.DrawLine(ship, hmd, Color.red, 0.2f);

        }
    public void  Shooting()
    {
        //ask burst "Should I spawn projectiles"
        //d.l("cannon calling burst");
        if (s.burst.TimeToFire())
        { 
            //d.l(" FIRING",true );
            Fire();
        }
        //if so, spawn projectiles at the right places for this cannon

      
    }

    public void  StopShooting()
    {
        d.l(" cannon stop bursting");
        s.burst.Stop();
    }
    private void Fire()
    {
        //// //GameObject newprojectile = new GameObject();
        ////GameObject  newprojectile = (GameObject)Instantiate((GameObject)Resources.Load("Projectiles/projBasic"), transform.position , Quaternion.identity);
        //// newprojectile.GetComponent<scrProjectile>().SetDirection(transform.forward);
        //// newprojectile.transform.SetParent(s.gBwWorld);

        //GameObject newprojectile = new GameObject();
        //GameObject newprojectile = (GameObject)Instantiate((GameObject)Resources.Load("Projectiles/projBasic"), transform.position, transform.rotation);
        //newprojectile.GetComponent<scrProjectile>().SetDirection(transform.forward);
        //newprojectile.transform.SetParent(s.gBwWorld);

        FireFromEachBarrel();
    }

    private void FireFromEachBarrel()
    {
        foreach (Transform barrel in barrels ) {
            GameObject newprojectile = (GameObject)Instantiate((GameObject)Resources.Load("Projectiles/projBasic"), barrel.transform.position, barrel.transform.rotation *Quaternion.Euler(Vector3.right*-90) );
            //newprojectile.GetComponent<scrProjectile>().SetDirection(transform.forward);
            newprojectile.transform.SetParent(s.gBwWorld);
        }
               
    }
}
