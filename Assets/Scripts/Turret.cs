using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Vector2 mousePos;
    private Shooter shooter;
    private Player player;
    private GunPlayerS gun;
    // delegate void SwapWeapon();
    // private SwapWeapon swap;
    void Subscribe(Player player)
    {
        player.OnPlayerClick += shooter.ConstantFire;
        player.OnPlayerRelease += CancelInvoke;
    }
    void Awake()
    {
        gun = gameObject.AddComponent<GunPlayerS>();
        player = GameManagerScr.instance.GetComponent<Player>();
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
    }
    public GameObject GetCurrentWeapon()
    {
        return gun.bulletS;//CHANGE ONCE WEAPON SWAPPING WORKS
    }
}
