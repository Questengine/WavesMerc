using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class scrWorldMoverHand   : MonoBehaviour {

    private Vector3 posHandInitial;
    private Vector3 posHandCur;
    private Vector3 posCamInitial;
    private float yEulerHandInitial;
    private float yEulerHandCur;
    private float yEulerCamInitial;
    private Text txtAmmo;
    private Text txtTime;

    // Use this for initialization
    void Start () {
        txtAmmo = GameObject.Find("txtAmmo").GetComponent<Text>();
        txtTime = GameObject.Find("txtTime").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        

        Translate();
        Rotate();
        UpdateUI();
//
    }

    private void UpdateUI()
    {
        txtAmmo.text = s.ship.Ammo();
        txtTime.text = Time.timeSinceLevelLoad.ToString();
    }

    private void Translate()
    {
            
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.LTouch ))
        {
            posHandInitial = transform.position;
            posCamInitial = s.gBwTrackingSpace.position;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            posHandCur = transform.position;
            Vector3 newPos;//= s.gBwCam.position;
            newPos = posCamInitial + (posHandInitial-posHandCur  )*3;
            s.gBwTrackingSpace.position = newPos;
            posHandInitial = transform.position;
            posCamInitial = s.gBwTrackingSpace.position;

        }
    }
    private void Rotate()
    {

        /*
        parent bWorld to nothing
        rotate an unattached pivot to zero
        parent world to pivot, offset by controllers vector to origin
        apply controller yrot to pivot
        */
        
        

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            yEulerHandInitial = transform.rotation.eulerAngles.y;
            yEulerCamInitial = s.gBwTrackingSpace.transform.rotation.eulerAngles.y;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            yEulerHandCur = transform.rotation.eulerAngles.y;
            float newEulerCamY;//= s.gBwPivot.transform.rotation.eulerAngles.y;
            newEulerCamY = yEulerCamInitial + (yEulerHandInitial-yEulerHandCur  );
            s.gBwTrackingSpace.rotation = Quaternion.Euler(0, newEulerCamY, 0);

            yEulerHandInitial = transform.rotation.eulerAngles.y;
            yEulerCamInitial = s.gBwTrackingSpace.transform.rotation.eulerAngles.y;
            //yEulerHandInitial = yEulerHandCur;//yEulerCur = s.gBwPivot.transform.rotation.eulerAngles.y;//saved for next time


            }
          
        }
}
