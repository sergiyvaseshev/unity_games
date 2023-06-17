using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    private int gameObjectSpawnNum;
    public float speed;
    public float bound ;
    public GameObject gameObjectSpawn;
    public GameObject[] gameObjectsSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
        
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("тест gameObjectsSpawn.Length = " + gameObjectsSpawn.Length);
           
            gameObjectSpawnNum = Random.Range(0, gameObjectsSpawn.Length);
            Debug.Log("тест gameObjectSpawnNum = " + gameObjectSpawnNum);

            Instantiate(gameObjectsSpawn[gameObjectSpawnNum], transform.position, gameObject.transform.rotation);
        }
        


        if (transform.position.x > bound)
        {
            transform.position = new Vector3( bound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -bound)
        {
            transform.position = new Vector3( -bound, transform.position.y, transform.position.z);
        }
        var HorizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.right * speed * Time.deltaTime * HorizontalInput);

    }
   

  
    }
