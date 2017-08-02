using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scrMaster : MonoBehaviour {


    void Awake()
    {
        s.gBwWorld = ((GameObject )(GameObject.Find("bwWorld"))).transform;
        s.gBwTrackingSpace = ((GameObject)(GameObject.Find("bwVRCameraRig"))).transform;
        s.gBwCam = ((GameObject)(GameObject.Find("CenterEyeAnchor"))).transform;
        GameObject theShip = ((GameObject)(GameObject.Find("Ship")));
            s.cannon = theShip.GetComponentInChildren<scrCannon>();
        s.ship = theShip.GetComponent<scrHero>();
        s.burst = theShip.GetComponentInChildren<scrBurst>(); 
    }
    // Use this for initialization
    void Start() {
        GameObject[] walls = GameObject.FindGameObjectsWithTag ("GOWall");
        string[] wallnames = {"8","C", "H", "I", "L", "O", "N", "T", "U",  "High", "Low", "Solid" };
        string[] matnames = { "blue", "cobalt", "gray", "green", "lead", "yellow", "purple" };
        System.Random rand = new System.Random();
        foreach (GameObject onewall in walls)
        {
            string wallname = wallnames[rand.Next(wallnames.Length )];
            GameObject  newwall = (GameObject)Instantiate((GameObject)Resources.Load("Parts/WallParts/WallCubes"+wallname),Vector3.zero , Quaternion.identity);
            newwall.transform.SetParent(onewall.transform );
            newwall.transform.localPosition = Vector3.zero;
            newwall.transform.localScale = Vector3.one;
            newwall.transform.localRotation  = Quaternion.identity ;

            Renderer[] renderers = newwall.GetComponentsInChildren<Renderer >();
            string matname = matnames[rand.Next(matnames.Length)];
            Material newMat = Resources.Load("Materials/Walls/"+matname, typeof(Material)) as Material;
            foreach (MeshRenderer onerenderer in renderers) {
                onerenderer.material = newMat;
            }
            onewall.GetComponent<scrWall>().bwInit();
            //d.l(wallname, "--");
        }//end foreach--        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
             ButtonFirePrimary();
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {

            ButtonFirePrimaryUp();
        }
    }
    private void ButtonFirePrimary()
    {
       s.cannon.Shooting();
    }
    private void ButtonFirePrimaryUp()
    {
        s.cannon.StopShooting();
    }
}
