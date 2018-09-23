using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poooooooliiing : MonoBehaviour {

    GameManiger gameManager;
    
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManiger>();
    }

    void Update()
    {
        
    }

    public void Destroy(bool _forkert, bool tilAldtSkral)
    {
        if (gameManager != null)
        {


            if (tilAldtSkral == true)
            {
                gameManager.PointKeeper(-150);
                gameObject.SetActive(false);
            }
            else if (tilAldtSkral == false && _forkert == false)
            {
                gameManager.PointKeeper(100);
                gameObject.SetActive(false);
            }
            else if (_forkert == true && tilAldtSkral == false)
            {
                gameManager.Live();
                gameObject.SetActive(false);
            }
        }
    }
}
