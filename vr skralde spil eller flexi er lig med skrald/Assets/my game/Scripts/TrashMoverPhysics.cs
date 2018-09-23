using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMoverPhysics : MonoBehaviour {

    public float speed = 2.0f;

    OVRGrabbable grapperScript;
    Vector3 diretion;

    void Start()
    {

        if (Random.value > 0.5f)
            diretion = Vector3.back;
        else
            diretion = Vector3.left;


        grapperScript = GetComponent<OVRGrabbable>();
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

	private void LateUpdate()
	{
        if (grapperScript && grapperScript.isGrabbed)
            Destroy(this); // Destroy this script
	}

	void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(diretion) * speed * Time.deltaTime);
    }
}
