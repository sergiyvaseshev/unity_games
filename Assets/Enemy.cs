using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float destroyEnemyHeight;
    public Rigidbody rigidbody;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var lookDirection = (player.transform.position - transform.position).normalized;
        rigidbody.AddForce(lookDirection* speed);

        if (transform.position.y < -destroyEnemyHeight)
        {
            Destroy(gameObject);
        }

        
    }
}
