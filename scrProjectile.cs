using UnityEngine;
using System.Collections;


public class scrProjectile : MonoBehaviour {
    public int strength;
    public float speed;
    private float lifespan = 0.54f;
    public float birthtime;
    private Vector3 travel;

    // Use this for initialization
    void Start () {
        birthtime = Time.realtimeSinceStartup;
        name = "basic " + birthtime;
        speed = .02f;
        travel = transform.forward;



    }

    // Update is called once per frame
    void Update () {
        transform.position += travel * speed;
        if (birthtime + lifespan < Time.realtimeSinceStartup ){ //
                                                                //d.l("kill this projectile");
            Destroy(gameObject);
        }//end if-- 
	}
}
