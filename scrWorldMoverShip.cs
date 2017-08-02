using UnityEngine;
using System.Collections;

public class scrWorldMoverShip : MonoBehaviour {

    private Vector3 posHandInitial;
    private Vector3 posHandCur;
    private Vector3 posCamInitial;
    private float yEulerHandInitial;
    private float yEulerHandCur;
    private float yEulerCamInitial;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        TranslateStick();
        RotateStick();
        

    }
    private void TranslateStick()
    {
        Vector2 stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        s.gBwTrackingSpace.position += transform.forward  * 0.016f*stick.y;
     
    }
    private void RotateStick()
    {
        Vector2 stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        float rotamount =  2f * stick.x;

        yEulerCamInitial = s.gBwTrackingSpace.transform.rotation.eulerAngles.y;
        s.gBwTrackingSpace.rotation = Quaternion.Euler(0, yEulerCamInitial+= rotamount , 0);

     } 


}
