using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using UnityEngine;

public class ball : MonoBehaviour
{
    private bool ballIsActive;
    private int dir_Y;

    // Start is called before the first frame update
    void Start()
    {
        var rnd = Random.Range(0, 2); //выбираем в кого первым полетит
        if (rnd == 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 10;
        }
        
        if (rnd == 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
        if (Input.GetButtonDown("Cancel") == true)
        {
            ballIsActive = false;
            GetComponent<Rigidbody2D>().Sleep();
            transform.position = new Vector2(0,0);
        }
        //if (Input.GetButtonDown("Jump") == true)
        //{
            // проверка состояния
        //    if (!ballIsActive)
        //    {
                // применим силу
                // зададим активное состояние
                //ballIsActive = !ballIsActive;
                //GetComponent<Rigidbody2D>().AddForce(ююю);
                
        //    }
        //}
        //Debug.Log(GetComponent<Rigidbody2D>().position.x);
        if (transform.position.y > 6 || transform.position.y < -6)
        {
            Debug.Log("out");
            ballIsActive = false;
            GetComponent<Rigidbody2D>().Sleep();
            transform.position = new Vector2(0,0);
            var rnd = Random.Range(0, 2); //выбираем в кого первым полетит
            if (rnd == 0)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.down * 10;
            }
        
            if (rnd == 1)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "player1" || col.gameObject.name == "player2") {
            // Calculate hit Factor
            float x=hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);
            
            if (GetComponent<Rigidbody2D>().position.y < 0)
            {
                dir_Y = 1;
            }

            if (GetComponent<Rigidbody2D>().position.y > 0)
            {
                dir_Y = -1;
            }
            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, dir_Y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * 10;
        }
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketWidth) {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return ((ballPos.x - racketPos.x) / racketWidth);
    }
}
