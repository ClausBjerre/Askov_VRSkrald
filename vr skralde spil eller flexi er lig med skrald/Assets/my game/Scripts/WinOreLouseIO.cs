using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class WinOreLouseIO : MonoBehaviour {
    public string rigtigSotert;
    bool forkert = false;
    public bool tilAldtSkral = false;
    public Light ml;
    public float rødTid = 1;

    public int meny = 0;
    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
            EditorSceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrashMoverPhysics>() != null)
        {
            Destroy(other.GetComponent<TrashMoverPhysics>());
        }

        if (rigtigSotert != other.gameObject.tag && tilAldtSkral == false)
        {
            forkert = true;
            ml.color = Color.red;
            StartCoroutine(LysForkert());
        }
        
        
        if (other.GetComponent<poooooooliiing>() != null)
        {
            other.GetComponent<poooooooliiing>().Destroy(forkert, tilAldtSkral);
        }
        else
        {
            Debug.LogError("pooooooooliiing not found on thras");
            return;
        }


        if (meny == 1)
        {
            EditorSceneManager.LoadScene(1);
        }
        if (meny == 2)
        {
            
        }
        if (meny == 3)
        {
            Application.Quit();
        }
        
    }

    IEnumerator LysForkert()
    {
        yield return new WaitForSecondsRealtime(rødTid);
        ml.color = Color.white;
    }

}
