using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRGrabbable), typeof(Rigidbody))]
public class DetachFromParent : MonoBehaviour 
{

    OVRGrabbable grapScript;
    Rigidbody rb;
    Transform mrParent;
    public bool fjerndig = false;
    bool isGrapped = false;

  	// Use this for initialization
	void Start () 
    {
        grapScript = GetComponent<OVRGrabbable>();
        rb = GetComponent<Rigidbody>();
        
        mrParent = transform.parent;
	}

	private void Update()
	{
        if(grapScript.isGrabbed && isGrapped == false || fjerndig == true)
        {
            isGrapped = true;
            Detach();
        }      
	}

	public void Detach()
    {
        if (GetComponentInParent<boooooom>() != null)
        {
            GetComponentInParent<boooooom>().StatTimer();
        }
        
        
        transform.parent = null;
        rb.useGravity = true;
        
        Destroy(this);
    }
}
