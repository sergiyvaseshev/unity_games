using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    private int gameObjectSpawnNum;
    public float speed;
    public float jumpForce = 20;
    public float gravityModifier;
    public GameObject gameObjectSpawn;
    public float bound;
    public bool isOnGround;
    public Rigidbody rigidbodyPlayer;
    public GameObject[] gameObjectsSpawn;
    public Transform spawntransform;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
        
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (isOnGround==true)
            {
                rigidbodyPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
           
        }
        if (transform.position.y < bound)
        {
            transform.position = spawntransform.position;
        }




        var HorizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.right * speed * Time.deltaTime * HorizontalInput);

    }
    private void OnCollisionEnter(Collision collision)
    {

    if (collision.gameObject.CompareTag("Ground") )
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("obstacles"))
        {
            gameOver= true;
            Debug.Log("gameOver= " );

        }


        
    }


}
