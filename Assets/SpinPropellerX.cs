using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float rotationSpeed = 100F;
    public bool invert;
    // Start is called before the first frame update
    void Start()
    {
        if (invert)
        {
            rotationSpeed *= -1;
          
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime );
    }
}
