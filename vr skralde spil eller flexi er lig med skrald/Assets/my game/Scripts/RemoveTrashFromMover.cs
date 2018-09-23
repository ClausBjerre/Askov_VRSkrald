using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RemoveTrashFromMover : MonoBehaviour 
{


	private void OnTriggerEnter(Collider other)
	{
        if(other.GetComponent<DetachFromParent>() != null)
        {
            other.GetComponent<DetachFromParent>().Detach();
        }

        if(other.GetComponent<TrashMoverPhysics>() != null)
        {
            Destroy(other.GetComponent<TrashMoverPhysics>());
        }
	}

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position, GetComponent<BoxCollider>().size);
	}
}
