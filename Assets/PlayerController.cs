using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float powerupStrength=15f;
    public bool hasPowerup;
    public float speed;
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
        rigidbody.AddForce(focalPoint.transform.forward* speed * forwardInput);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           Debug.Log("Collided with " + collision.gameObject.name + " hasPower = " + hasPowerup);
           if(hasPowerup == true)
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer=collision.gameObject.transform.position-transform.position;

                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }

        }
    }
}       
