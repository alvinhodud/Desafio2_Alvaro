using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Transform target; 
    public Rigidbody2D rb;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    void Update()
    {
        StartCoroutine(Propulsao());
    }

    IEnumerator Propulsao()
    {
        rb.velocity = transform.right * 10;
        yield return new WaitForSeconds(0.5f);
        rb.velocity = transform.right * 0;
        if(target == null)
        {
            StartCoroutine(Die());
        }
        StartCoroutine(Attack()); 
    }
    
    IEnumerator Attack()
    {
        float speed = 5;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Attack());
    }

    IEnumerator Die()
    {
        if (target == null)
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            int damage = 10;
            enemy.Takedamage(damage);  
            Destroy(gameObject);
        }
    }
}
