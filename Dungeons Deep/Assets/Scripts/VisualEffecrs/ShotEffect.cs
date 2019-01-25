using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEffect : MonoBehaviour {



    public float delay;

	void Start () { // destroys the particle after one loop of animation + a delay.
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
	}
	
	void Update () {
		
	}
}
