using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Vector2 mousePos;
    void Start()
    {
        
    }
    void Update()
    {
        mousePos = WorldPosition.GetMouseWorldPos();
        Vector2 turretDirection = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = turretDirection;        
    }
}
