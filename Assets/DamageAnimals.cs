using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimals : MonoBehaviour


{
    private int damageCounter;

   public MoveForward moveForward;
    // Start is called before the first frame update
    public void Damage()
    {
        Debug.Log("метод Damage  ");

        damageCounter++;

        if (damageCounter == 3)
        {
            Destroy(gameObject);
        }

        moveForward.SlowDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
