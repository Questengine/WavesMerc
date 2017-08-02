using UnityEngine;
using System.Collections;
using System.Collections.Generic    ;

public class scrGlowyBit : MonoBehaviour {

    // Use this for initialization
    public int hp;
    private List<Transform> blocks;
	void Start () {
        blocks = new List<Transform>();
        blocks.AddRange( gameObject.GetComponentsInChildren<Transform>());
        Transform removeShield = null;
        foreach (Transform oneT in blocks)
        {
            if (oneT.gameObject.name.ToUpper() == "SHIELD")
            {
                removeShield = oneT;
            }
        }
        blocks.Remove(removeShield);
    }
	
	// Update is called once per frame
	void Update () {
        if (hp < 0) { //
            Destroy(gameObject);
        }//end if--
    }
    void OnTriggerEnter(Collider other)
    {
        hp--;
        d.l("collision " + hp);
        Destroy(blocks[hp].gameObject);
        Destroy(other.gameObject);

    }
}
