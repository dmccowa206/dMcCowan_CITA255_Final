using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool hasShot = false;
    // private Vector2 startPos = transform.position;
    void Update()
    {
        if(!hasShot)
        {
            // moveandshoot

            // Shoot();
        }
        else
        {
            // leaveanddie
            //if (transform.position == startPos)
            {
                Destroy(gameObject);
            }
        }
    }
}
