using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boooooom : MonoBehaviour {
    public GameObject granad;
    public float waitForExplotion = 1;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Bom()
    {
        GameObject g = Instantiate(granad,gameObject.transform.position, transform.rotation);
        g.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
        g.GetComponent<Rigidbody>().angularVelocity = GetComponent<Rigidbody>().angularVelocity;
        Destroy(gameObject);
        
    }
    
    public void StatTimer()
    {
        StartCoroutine(BomTimer());
    }

    IEnumerator BomTimer()
    {
        yield return new WaitForSecondsRealtime(waitForExplotion);
        Bom();
    }
}
