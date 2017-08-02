using UnityEngine;
using System.Collections;

public class scrPfxKillSelf : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 1f);
	}
}
