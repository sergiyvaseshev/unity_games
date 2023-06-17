using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject: MonoBehaviour
{
 
           public float speed;
    void Start()
    {
      
    }

    
    void Update()
    {

        Vector3 direction = new Vector3(0, 0, speed);
        
        transform.Translate(direction * Time.deltaTime);

        if (transform.position.z > 30.5f)
        {
            Destroy(gameObject);
        }
           
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animals"))
        {
            other.gameObject.GetComponent<DamageAnimals>().Damage();
            Destroy(gameObject);
        }

    }
}
