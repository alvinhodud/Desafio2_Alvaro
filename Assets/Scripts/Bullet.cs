using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{  
    public Rigidbody2D rb;

    void Start()
    {
        float speed = 20f;
        rb.velocity = transform.right * speed;
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            int damage = 25;
            enemy.Takedamage(damage);   
            Destroy(gameObject);
        }
    }
}
