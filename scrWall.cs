using UnityEngine;
using System.Collections;

public class scrWall : MonoBehaviour {

    private BoxCollider[] WallParts;
    private bool partstranslucent = false;
    public const float distancewalltomidpoint = 1.0f;
    private MeshRenderer[] wallRends ;
    private Color wallColor;
    private Color wallColorTransparent;
    // Use this for initialization
    public void bwInit () {

        WallParts = gameObject.GetComponentsInChildren<BoxCollider>();
         wallRends = gameObject.GetComponentsInChildren<MeshRenderer>();
        wallColor = wallRends[0].material.color;
        wallColor.a  = 1f;
        wallColorTransparent = wallColor;
        wallColorTransparent.a = 0.3f;
        WallsShow();

    }
	
	// Update is called once per frame
	void Update () {


        MakeWallPartsTransparent();
    }
    private void MakeWallPartsTransparent()
    {
        //find the midpoint between the ship and the hmd
        //         if that point is kind of close to this wall
        // then for each wallpart, make transparent
        Vector3 midpoint = (s.ship.transform.position + s.gBwCam.position) / 2;
        if (Vector3.Distance(midpoint, transform.position) < distancewalltomidpoint)
        {
            foreach (BoxCollider onewallpart in WallParts)
            {
                if (Vector3.Distance(midpoint, onewallpart.transform.position) < distancewalltomidpoint)
                {
                    CheckWallShouldBeTransparent(onewallpart);
                }
            }
        }
        RestoreTransparentWalls();

    }
    private void CheckWallShouldBeTransparent(BoxCollider wall)
    {
        Vector3 ship = s.ship.transform.position;
        Vector3 hmd = s.gBwCam.position;
        if (Physics.Raycast(ship, hmd - ship, Vector3.Distance(hmd, ship)))
        {
            //YES, wall should be transparent
            partstranslucent = true;
            Debug.DrawLine(ship, hmd, Color.red, 0.2f);
            WallsHide();
        }
    }
    private void RestoreTransparentWalls()
    {
        if (partstranslucent)
        {
            Vector3 midpoint = (s.ship.transform.position + s.gBwCam.position) / 2;
            if (Vector3.Distance(midpoint, transform.position) > distancewalltomidpoint)
            {
                partstranslucent = false;
                WallsShow();
            }
                
        }        
    }
    private void WallsHide()
    {
        foreach (MeshRenderer onerend in wallRends)
        {
            onerend.material.color = wallColorTransparent;
        }

    }
    private void WallsShow()
    {
        foreach (MeshRenderer onerend in wallRends)
        {
            onerend.material.color = wallColor;
        }
    }
}
