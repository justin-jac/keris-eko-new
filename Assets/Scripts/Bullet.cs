using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb; 
     private void OnCollisionEnter2D (Collision2D collision){
        switch(collision.gameObject.tag){
            case "Coins":
                Debug.Log("Collide Coins");
                Destroy(this.gameObject);
                break;
            case "Collider": //cari tau cara biar ngelewatin coin dan ga kedetect circle collider
                Debug.Log("Collide");
                Destroy(this.gameObject);
                break;
            case "Bullets":
                Debug.Log("Collide Bullet");
                Destroy(this.gameObject);
                break;
            case "Enemy":
                Debug.Log("Collide Enemy");
                Destroy(this.gameObject);
                break;

        }
        // if(collision.gameObject.tag != "Bullets"){
        //     Debug.Log("Tr");
        //     Destroy(this.gameObject);
        // }
     }
        
}

