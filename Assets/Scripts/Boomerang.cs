using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{ 
    public Rigidbody2D rb; 

    void Update()
    {
        StartCoroutine(Vai());
    }

    IEnumerator Vai()
    {
        rb.velocity = transform.right * 10;
        yield return new WaitForSeconds(0.5f);
        rb.velocity = transform.right * 0;
        Volta();
    }

    void Volta()
    {
        rb.velocity = transform.right * -10;
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            int damage = 30;
            enemy.Takedamage(damage);
            Destroy(gameObject);
        }
    }
}
