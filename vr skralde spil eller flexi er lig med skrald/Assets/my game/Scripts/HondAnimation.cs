using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HondAnimation : MonoBehaviour {
    public bool right;
    public Mesh handÅben;
    public Mesh handLukket;
    public MeshFilter kkk;
    public Mesh handGester1;
    public Mesh handGester2;
    public Mesh handGester3;
    public Mesh handGester4;
    Vector2 thumstick_a;
    Vector2 thumstick_b;
	// Use this for initialization

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.5f && right == true || OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.5f && right == false)
        {
            kkk.mesh = handLukket;
        }
        else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.1f && right == true || OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.1f && right == false)
        {
            kkk.mesh = handÅben;
        }
        thumstick_a = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        thumstick_b = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        
        if (thumstick_a.x < -0.5f && right == true || thumstick_b.x < -0.5 && right == false)
        {
            kkk.mesh = handGester1;
        }

        if (thumstick_a.x > 0.5f && right == true || thumstick_b.x > 0.5 && right ==  false)
        {
            kkk.mesh = handGester2;
        }

        if (thumstick_a.y < -0.5f && right == true || thumstick_b.y < -0.5 && right == false)
        {
            kkk.mesh = handGester3;
        }

        if (thumstick_a.y > 0.5f && right == true || thumstick_b.y > 0.5 && right == false)
        {
            kkk.mesh = handGester4;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.A) && right == false || OVRInput.GetDown(OVRInput.RawButton.X) && right == true )
        {
            
        }
    }
}

