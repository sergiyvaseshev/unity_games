using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float destroyEnemyHeight;
    public Rigidbody rigidbody;
    private GameObject player;
    public GameObject cars;
    public bool setcars;

    public void SetCars(GameObject car)
    {
       cars = car;
        setcars = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (setcars)
        {
            cars.gameObject.transform.position = transform.position;
        }
        
        var lookDirection = (player.transform.position - transform.position).normalized;
        rigidbody.AddForce(lookDirection* speed);

        if (transform.position.y < -destroyEnemyHeight)
        {
            Destroy(gameObject);
        }

        
    }
}
