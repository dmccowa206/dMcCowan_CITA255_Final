using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    Vector2 mousePos;
    private Shooter shooter;
    private Player player;
    private GunPlayerS gun;
    GameManagerScr gm;
    delegate void SwapWeapon();
    private SwapWeapon swap;
    int weaponIndex = 0;
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
            // Debug.Log(GetCurrentWeapon().name);
            if (GetCurrentWeapon().name == "BulletEnemy")
            {
                swap();
            }
            ChangeGun(GetCurrentWeapon().name);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            swap = UsePreviousWeapon;
            swap();
            // Debug.Log(GetCurrentWeapon().name);
            if (GetCurrentWeapon().name == "BulletEnemy")
            {
                swap();
            }
            ChangeGun(GetCurrentWeapon().name);
        }        
    }
    public GameObject GetCurrentWeapon()
    {
        return gm.weapons[weaponIndex];
    }
    void UseNextWeapon()
    {
        weaponIndex ++;
        if (weaponIndex >= gm.weapons.Count)
        {
            weaponIndex = 0;
        }
        
    }
    void UsePreviousWeapon()
    {
        weaponIndex --;
        if (weaponIndex < 0)
        {
            weaponIndex = gm.weapons.Count - 1;
        }
    }
    // bool CheckUsability()
    // {
    //     if (GetCurrentWeapon().name == "BulletEnemy")
    //     {
    //         return GetComponent<GunEnemy>().GetPlayerUsable();
    //     }
    //     return GetComponent<GunPlayerS>().GetPlayerUsable();
    // }
    void ChangeGun(string gunName)
    {
        if (gunName == "BulletPlayerS")
        {
            Destroy(gun);
            gun = gameObject.AddComponent<GunPlayerL>();
        }
        else if (gunName == "BulletPlayerL")
        {
            Destroy(gun);
            gun = gameObject.AddComponent<GunPlayerS>();
        }
    }
}
