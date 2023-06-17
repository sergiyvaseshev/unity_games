using System;
using UnityEngine;
public class Player : MonoBehaviour {
  private static readonly int Attack = Animator.StringToHash("attack");
  [SerializeField]
  private Animator _animatorPlayer;

  //private float speed = 20f;

  private void Start() {
        Application.targetFrameRate = 10;
  }
  
  private void Update() {
        var horizontalInput = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(0, 0, -10f*horizontalInput);
        var Vertical = Input.GetAxis("Vertical");
        transform.Translate(dir*Time.deltaTime);
        


  }
  
  
  /*var horizontalInput = Input.GetAxis ("Horizontal") ;
    transform. Rotate(Vector3.up, 5 * horizontalInput * Time. deltaTime);*/
    
  /*if (Time.time > 1f && Time.time < 2f) {
    transform.Translate(speed*Time.deltaTime,0,0);
  }*/

  private void OnMouseDown() {
    if(_animatorPlayer!=null) {
      _animatorPlayer.SetTrigger(Attack);
    }
    //PoolManager.CreateRandomItem?.Invoke();
  }
}