using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 20f;
    public Rigidbody2D rb;
    public float lifeTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Buggie na początku to odnośnik do klasy z tego co rozumiem
        // Czyli unity sprawdza czy przy kolizji jest osiągalny komponent Buggie (to jest w tym wypadku skrypt)
        // Jesli tak to nadaje zmiennej "enemy" jakaś wartość, porónuje ją do zera i jeśli jest różna od zera to zadaje dmg obiektowi.
        Buggie enemy = collision.GetComponent<Buggie>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


    void DestroyProjectile ()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
