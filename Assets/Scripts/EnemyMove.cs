using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float moveSpd = 0.4f;
    [SerializeField] float shotDelay = 2f;
    [SerializeField] int hp = 3;
    private Vector3 initPos;
    private Vector3 shootPos;
    private bool hasShot = false, shotOnce = false;
    Shooter shooter;
    public int GetHp()
    {
        return hp;
    }
    public void HitHp(int dam)
    {
        hp -= dam;
    }
    void Start()
    {
        shooter = GetComponent<Shooter>();
    }
    public void SetShootPos(Vector3 sPos)
    {
        shootPos = sPos;
    }
    public void SetInitPos(Vector3 iPos)
    {
        initPos = iPos;
    }
    public void SetInitPosY(float newY)
    {
        initPos.y = newY;
    }
    void Update()
    {
        if(!hasShot)
        {
            // moveandshoot
            Move(shootPos);
        }
        else
        {
            // leaveanddie
            Move(initPos);
        }
    }
    void Move(Vector3 dest)
    {
        float delta = moveSpd * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, dest, delta);
        if (transform.position == dest)
        {
            if (hasShot)
            {
                Destroy(gameObject);
            }
            else
            {
                if(!shotOnce)
                {
                    Invoke("EShoot", shotDelay);
                    shotOnce = !shotOnce;
                }
                SetInitPosY(transform.position.y);
            }
        }
    }
    void EShoot()
    {
        shooter.EnemyShoot();
        hasShot = true;
    }
}
