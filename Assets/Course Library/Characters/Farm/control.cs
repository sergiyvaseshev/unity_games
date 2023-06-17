using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    private int gameObjectSpawnNum;
    public float speed;
    public float bound;
    public float gravityModifier;
    public GameObject gameObjectSpawn;

    public Rigidbody rigidbodyPlayer;
    public GameObject[] gameObjectsSpawn;
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
            rigidbodyPlayer.AddForce(Vector3.up * 10, ForceMode.Impulse);
           
        }
        


       
        var HorizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.right * speed * Time.deltaTime * HorizontalInput);

    }
   

  
    }
