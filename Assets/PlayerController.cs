using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speid;
    public Rigidbody rigidbody;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward* speid * forwardInput);
    }
}
