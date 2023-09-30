using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float powerupStrength=15f;
    public bool hasPowerup;
    public float speed;
    public float respawnPos;
    public Rigidbody rigidbody;
    private GameObject focalPoint;
    public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y< respawnPos)
        {
            transform.position = Vector3.zero;
        }
        float forwardInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward* speed * forwardInput);

        powerup.gameObject.transform.position = transform.position + new Vector3(0, -0.1f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {                    
            Destroy(other.gameObject);
            StartCoroutine(PowerupRoutine());
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
    private IEnumerator PowerupRoutine() 
    {
        hasPowerup = true;
        powerup.gameObject.SetActive(true);

        yield return new WaitForSeconds(7);

        hasPowerup = false;
        powerup.gameObject.SetActive(false);
    }
}       
