using UnityEngine;
using System.Collections;

public enum ePickup
{
    ammo, health,time
}
public class scrPickup : MonoBehaviour {
    public ePickup pickuptype;
    public int pickupvalue;
void OnTriggerEnter(Collider col)
{
        if (col.gameObject.name == "Ship")
        {
            switch (pickuptype)
            {

                case ePickup.ammo:
                    s.ship.AddAmmo(pickupvalue);
                    break;
                case ePickup.health:
                    s.ship.AddHealth(pickupvalue);
                    break;
                case ePickup.time:
                    s.ship.AddTime(pickupvalue);
                    break;
            }
            d.l("Pickup collieds with ship... destroying " + gameObject.name );
            GameObject  pfxPickup = (GameObject)Instantiate((GameObject)Resources.Load("PFX/pfxPickedUp"), transform.position , Quaternion.identity);

            Destroy(gameObject);
        }

}
    

    }