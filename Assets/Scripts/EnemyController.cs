using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] bool death = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (death){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        // untuk ambil coins dan add point ke character
        if(collision.gameObject.tag == "Bullets" || collision.gameObject.tag == "Player"){
            death = true;
        }
        
    }
}
