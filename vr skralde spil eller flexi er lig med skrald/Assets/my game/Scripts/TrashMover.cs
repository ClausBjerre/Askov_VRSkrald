using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMover : MonoBehaviour {

   public float speed = 1f;
    GameObject trashObject;

    public GameObject SetTrashObject{ set { trashObject = value; } }

    Vector3 diretion;

    // Use this for initialization
	void Start () 
    {
        DetachFromParent childWithDetachScript = GetComponentInChildren<DetachFromParent>();

        if (childWithDetachScript)
            ParentTrashToMover(childWithDetachScript.gameObject);

        if (Random.value > 0.5f)
            diretion = Vector3.back;
        else
            diretion = Vector3.left;
        
	}

    public void ParentTrashToMover(GameObject _trash)
    {
        //Debug.Log(_trash.GetComponent<Collider>().GetType());

        float objectHeight = 0f;

        if (_trash.GetComponent<Collider>().GetType() == typeof(BoxCollider))
        {
            objectHeight = _trash.GetComponent<BoxCollider>().bounds.size.y;// * _trash.transform.localScale.y;
            //Debug.Log(_trash.GetComponent<BoxCollider>().bounds.size);
        }

        _trash.transform.parent = transform;
        _trash.transform.localPosition = Vector3.zero;
        _trash.transform.localPosition += new Vector3(0f, objectHeight * 0.5f, 0f);
    }
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(diretion * Time.deltaTime * speed, Space.World);	
	}
}
