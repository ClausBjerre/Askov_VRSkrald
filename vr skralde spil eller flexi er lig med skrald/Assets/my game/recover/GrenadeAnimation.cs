using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeAnimation : MonoBehaviour
{

    public float animationSpeed = 0.1f;
    public MeshFilter beltMesh;
    public Mesh[] allConveorMeshes;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(AnimateBelt());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AnimateBelt()
    {
     
            for (int i = 0; i < allConveorMeshes.Length; i++)
            {
                beltMesh.mesh = allConveorMeshes[i];

                yield return new WaitForSeconds(animationSpeed);
            }


    }
}
