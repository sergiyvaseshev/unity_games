using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5 ;
    public float bound = -8;

    // Start is called before the first frame update
   public void SlowDown()
    {
        speed--;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, 0, speed);
        // Time.deltaTime время между кадрами (чем больше кадров, тем меньше времени между кадрами)
        transform.Translate(direction * Time.deltaTime); 


        if (transform.position.z < bound)
        {
            Destroy(gameObject);
        }
       

    }
}
