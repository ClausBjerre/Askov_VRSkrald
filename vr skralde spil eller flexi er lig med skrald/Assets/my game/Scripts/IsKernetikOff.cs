using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKernetikOff : MonoBehaviour {
    OVRGrabbable grapScript;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        grapScript = GetComponent<OVRGrabbable>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (grapScript.isGrabbed == false && GetComponentInParent<DetachFromParent>() == false && rb.isKinematic == true)
        {
            rb.isKinematic = false;
        }
	}
}
