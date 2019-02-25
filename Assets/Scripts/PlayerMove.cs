using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float max;
    public float health;
    public float attack;
    public float fireRate;
    private float next_attack = 0.0f;
    public float bul_speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject bullet;
    private Rigidbody2D bulletRb;
    public Transform Firepoint1;
    public Transform Firepoint2;
    public Transform Firepoint3;
    public Transform Firepoint4;




    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        bulletRb = bullet.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(change);
        UpdateAnimationAndMove();
        Shooting();
        // Zakomentowane bo narazie puste



    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }
    void Shooting()
    {
        //Shooting right
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > next_attack)
        {
            next_attack = Time.time + fireRate;
            Instantiate(bullet, Firepoint1.position + Random.insideUnitSphere * max, Firepoint1.rotation);
        }
        //Shooting up
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > next_attack)
        {
            next_attack = Time.time + fireRate;
            Instantiate(bullet, Firepoint2.position + Random.insideUnitSphere * max, Firepoint2.rotation);
        }

        //Shooting left
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > next_attack)
        {
            next_attack = Time.time + fireRate;
            Instantiate(bullet, Firepoint3.position + Random.insideUnitSphere * max, Firepoint3.rotation);
        }
        //Shooting down
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > next_attack)
        {
            next_attack = Time.time + fireRate;
            Instantiate(bullet, Firepoint4.position + Random.insideUnitSphere * max, Firepoint4.rotation);
        }
        // Instantiate(bullet, Firepoint4.position + Random.insideUnitSphere * max, Firepoint4.rotation); 
        // Tworzy prefab bullet (do zmiany w inspektorze), w pozycji firepoint 4 z dodaną wartością po sferze gdzie max defniuje nam maksymalne wychylenie. Dzięki temu pociski nie są 
        // wystrzeliwane zawsze w idealnie tym samym miejscu

    }
}
