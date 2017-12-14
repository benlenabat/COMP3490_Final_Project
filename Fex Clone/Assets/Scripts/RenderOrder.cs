using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{

    private GameObject obj;

    private void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Background");
        //MeshRenderer rend = obj.GetComponent<MeshRenderer>;
    }
}
