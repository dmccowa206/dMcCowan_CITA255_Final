using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Vector2 mousePos;
    private Shooter shooter;
    private Player player;
    private GunPlayerS gun;
    GameManagerScr gm;
    delegate void SwapWeapon();
    private SwapWeapon swap;
    void Subscribe(Player player)
    {
        player.OnPlayerClick += shooter.ConstantFire;
        player.OnPlayerRelease += shooter.CancelInvoke;
    }
    void Awake()
    {
        gm = FindObjectOfType<GameManagerScr>();
        gun = gameObject.AddComponent<GunPlayerS>();
        player = gm.GetComponent<Player>();
        shooter = FindObjectOfType<Shooter>();
    }
    void Start()
    {
        player.fireRate = gun.GetFireRate();
        Subscribe(player);
    }
    void Update()
    {
        mousePos = WorldPosition.GetMouseWorldPos();
        Vector2 turretDirection = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = turretDirection;
        if(Input.GetKeyDown(KeyCode.Q))
        {
            swap = UseNextWeapon;
            swap();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            swap = UsePreviousWeapon;
            swap();
        }        
    }
    public GameObject GetCurrentWeapon()
    {
        return gm.bulletS;//CHANGE ONCE WEAPON SWAPPING WORKS
    }
    void UseNextWeapon()
    {
    }
    void UsePreviousWeapon()
    {
    }
}
