using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMaterial : MonoBehaviour
{
    public Material[] newMaterials;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("SetMaterial")]
    void setMaterial()
    {
        Material[] materials = GetComponent<Renderer>().materials;
        materials[0] = newMaterials[index];
        GetComponent<Renderer>().materials = materials;
    }
}
