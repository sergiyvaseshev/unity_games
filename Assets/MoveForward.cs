using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5 ;
    public float bound = -8;
    public bool destroyObject = true;
    private control player;
    void Start()
    {
        
        player =GameObject.Find("Player").GetComponent<control>();
    }
    // Start is called before the first frame update
    public void SlowDown()
    {
        speed--;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameOver==false)
        {

        
        Vector3 direction = Vector3.left * speed;
        // Time.deltaTime время между кадрами (чем больше кадров, тем меньше времени между кадрами)
        transform.Translate(direction * Time.deltaTime); 
}
        if(destroyObject)
        {

       

        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
       } 

    }
}
