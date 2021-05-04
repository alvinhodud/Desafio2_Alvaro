using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public GameObject MissilePrefab;
    public GameObject BoomerangPrefab;
    public LineRenderer LaserRend;
    bool Weapon1 = true;
    bool Weapon2 = false;
    bool Weapon3 = false;
    bool Weapon4 = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {   
            if (Weapon1 == true)
            {
                Shoot1();
            }
            else if (Weapon2 == true)
            {
                StartCoroutine(Laser());
            }
            else if (Weapon3 == true)
            {
                Shoot3();
            }
            else if (Weapon4 == true)
            {
                Shoot4();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapon1 = true;
            Weapon2 = false;
            Weapon3 = false;
            Weapon4 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Weapon1 = false;
            Weapon2 = true;
            Weapon3 = false;
            Weapon4 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Weapon1 = false;
            Weapon2 = false;
            Weapon3 = true;
            Weapon4 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Weapon1 = false;
            Weapon2 = false;
            Weapon3 = false;
            Weapon4 = true;
        }
    }
    
    void Shoot1()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    IEnumerator Laser()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
        if (hitinfo)
        {
            Enemy enemy = hitinfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Takedamage(10);
            }
            LaserRend.SetPosition(0, FirePoint.position);
            LaserRend.SetPosition(1, hitinfo.point);
        }
        else
        {
            LaserRend.SetPosition(0, FirePoint.position);
            LaserRend.SetPosition(1, FirePoint.position + FirePoint.right * 100);
        }
        LaserRend.enabled = true;

        yield return new WaitForSeconds(0.1f);

        LaserRend.enabled = false;
    }

    void Shoot3()
    {
        Instantiate(MissilePrefab, FirePoint.position, FirePoint.rotation);
    }

    void Shoot4()
    {
        Instantiate(BoomerangPrefab, FirePoint.position, FirePoint.rotation);
    }
}
