using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;

    // Coins Spawn
    public GameObject coinsObject;
    CoinsScripts coinsScripts;

    public Camera cameras;

    Vector2 moveDirection;
    Vector2 mousePosition;

    //Dummy death condition
    [SerializeField] bool death = false;

    // Point dari character (nanti gantien ilangno serializefield e ae)
    [SerializeField] int point;


    void Start(){
        Cursor.visible = false; 

        point = 0;
        coinsScripts = coinsObject.gameObject.GetComponent<CoinsScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); //keyboard
        float movey = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButton(0)){ //kurang atur aSpd
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, movey).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cameras.transform.position = this.transform.position;

        cameras.transform.position += new Vector3(0,0,-10);
        // camera.transform.rotation = this.transform.rotation;

        // cameras.transform.rotation = rb.transform.rotation;
        // iki ide buruk btw



        // Coins Spawner
        if(death){
            coinsScripts.setValue(point);
            // Destroy character lalu replace dengan coins
            Destroy(this.gameObject);
            Instantiate(coinsObject, this.transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = aimAngle;



    }

    void OnCollisionEnter2D(Collision2D collision){
        // untuk ambil coins dan add point ke character
        if(collision.gameObject.tag == "Coins"){
            point += collision.gameObject.GetComponent<CoinsScripts>().value;
            Destroy(collision.gameObject);
            Debug.Log(point);
        }
        if(collision.gameObject.tag == "Bullets" && collision.gameObject.tag == "Enemy"){
            death = true;
        }
        
    }
}
