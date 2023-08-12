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
    public Animator animator;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource audioSource;
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
            if (isOnGround==true && !gameOver)
            {
                dirt.Stop();
                animator.SetTrigger("Jump_trig");
                audioSource.PlayOneShot(jumpSound, 1.0f);
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
            dirt.Play();
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("obstacles"))
        {
            gameOver= true;
            audioSource.PlayOneShot(crashSound, 1.0f);
            dirt.Stop();
            explosion.Play();
            animator.SetBool("Death_b", true);
            Debug.Log("gameOver= " );

        }


        
    }


}
