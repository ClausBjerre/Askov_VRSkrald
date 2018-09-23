using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeFlask : MonoBehaviour {
    public MeshFilter kkk;
    public Mesh cola;
    public Mesh mathias;
    public string goeIkkeIStykker;
    public BoxCollider bc;
    // Use this for initialization
    void Start ()
    {
        mathias = kkk.mesh;
        bc = GetComponent<BoxCollider>();
    }

    private void Awake()
    {
        
    }

     

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != goeIkkeIStykker)
        {
            kkk.mesh = cola;
            bc.size = new Vector3(0.14f, 0.3f, 0.14f);
            Debug.Log("lol");
        }
    }
}
