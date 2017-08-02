//changes

using UnityEngine;
using System.Collections;

public class scrBaddie : MonoBehaviour {

    public int hp = 3;
    private  static float speedmodifier = 0.01f;
    public float detectionradius = 1.5f;
    private bool active = false;
    private Vector3 dest = Vector3.zero  ;
    public float speed =1f;//to be modified by speedmodifier above
    private Vector3 travel;
    private Rigidbody rb;
    private bool dead = false;


	// Use this for initialization
	void Start () {
        speed += speedmodifier;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
                
            ShouldMove();
            if (active)
            {
                dest = s.ship.transform.position;
                transform.LookAt(dest);
                travel = (dest - transform.position).normalized;
                Move();
            }
            else
            {
                active = CanDetectHero();
            }
            IsDead();
        }


    }
    private void ShouldMove()
    {
        Vector3 curpos = transform.position;
        Vector3 shippos = s.ship.transform.position;
            active = Vector3.Distance(shippos,curpos) < detectionradius    && (Vector3.Distance(shippos, curpos) > 0.3f);
    }
    private void Move()
    {
        transform.position += travel * speed * Time.deltaTime ;
            
    }
    private bool CanDetectHero()
    {
        return Vector3.Distance(s.ship.transform.position, transform.position) < detectionradius;
    }
    private void  IsDead() {
        if (hp <= 0) {
            dead = true;
            SetDeathPhysics();
            d.l(gameObject.name + " baddie dedz.  Destroyed in 2 seconds");
            Destroy(gameObject,2f);
            }
      }
    private void SetDeathPhysics()
    {
             rb.useGravity = true;
        Vector3 impactdirecton = transform.position + s.ship.transform.position;

        System.Random rand = new System.Random();
        float impactforce = 1+ rand.Next(8);

         rb.AddForce(impactdirecton.normalized * impactforce, ForceMode.Impulse);
         rb.AddTorque(impactdirecton.normalized *impactforce  );
        
    }
    void OnTriggerEnter(Collider col)
    {
        hp--;
        d.l("baddie hit " + col.gameObject.name);
        Destroy(col.gameObject);
    }
}
