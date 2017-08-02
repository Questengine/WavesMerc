using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System;

public class scrRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Spawn20();
	}
	
	// Update is called once per frame
	void Update () {
	}

   

    private void Spawn20() {
        Vector3 roomorigin = transform.position;
        string[] partnames = { "pfAmmo", "pfClock", "pfCornerrounded", "pfCross",
            "pfCross3d", "pfCubeframe", "pfCubeshapex", "pfCylindercup",
         "pfGrenade", "pfHextowerlarge",  "pfHourglass", "pfHextowertriangle", "pfHextowerrandom"};
        string[] pickupnames = { "Ammo", "AmmoLarge", "Time", "TimeLarge" ,"Health", "HealthLarge"};
        string[] baddienames = { "goDart", "goFirewing", "goPropcannon", "goSpikedisc", "goTwinblast", "goVertbird", "goTrirocket" };
        int alternator = 1;
        System.Random rand = new System.Random();
        for (float x = -1; x <= 1; x++)
        {
            for (float y = -1; y <= 1; y++)
            {
                for (float z = -1; z <= 1; z++)
                {
                        alternator++;
                    
                    float sum = x + y + z;
                    if (sum != 2 && sum != 0) { //
                        if (alternator % 6 == 0) {//; only populate 1/X of posibilities

                            Vector3 pos = new Vector3(x, y, z) * 0.5f;
                            string wallpartname = partnames[rand.Next(partnames.Length)];
                            GameObject newwallpart = (GameObject)Instantiate((GameObject)Resources.Load("Models/" + wallpartname), Vector3.zero, Quaternion.identity);
                            newwallpart.transform.SetParent(transform);
                            newwallpart.transform.localPosition = pos;
                            newwallpart.transform.localScale = Vector3.one*0.4f;
                            newwallpart.transform.localRotation = Quaternion.identity;
                        }
                        if (alternator % 13 == 0)
                        {//; only populate 1/X of posibilities

                            string pickupname = pickupnames[rand.Next(pickupnames.Length)];
                            Vector3 pos = new Vector3(x, y, z) * 0.5f;
                            GameObject newpickup = (GameObject)Instantiate((GameObject)Resources.Load("Parts/Pickups/pfPickup" + pickupname), Vector3.zero, Quaternion.identity);
                            newpickup.transform.SetParent(transform);
                            newpickup.transform.localPosition = pos;
                            newpickup.transform.localRotation = Quaternion.identity;
                        }
                        if (alternator %7 == 0)
                        {//; only populate 1/X of posibilities

                            string baddiename = baddienames[rand.Next(baddienames.Length)];
                            Vector3 pos = new Vector3(x, y, z) * 0.5f;
                            GameObject newbaddie = (GameObject)Instantiate((GameObject)Resources.Load("Baddies/"+baddiename), Vector3.zero, Quaternion.identity);
                            newbaddie.transform.position = transform.position +pos;
                            newbaddie.transform.SetParent(s.gBwWorld);
                            newbaddie.transform.localRotation = Quaternion.identity;
                        }
                    }//end if--
                }
            }
        }


       
    }
}
