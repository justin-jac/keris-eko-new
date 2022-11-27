using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public AIPath aIPath;
    Vector2 direction; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();
    }


    void faceVelocity()
    {
        direction = aIPath.desiredVelocity;

        transform.right = direction;
    }
}
