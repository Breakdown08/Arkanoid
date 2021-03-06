﻿using UnityEngine;

public class player1 : MonoBehaviour
{
    public float speed;
    private Vector2 position;

    public float boundary;
    
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.acceleration.x,0,Input.acceleration.z);
        position.x += Input.GetAxis("Horizontal") * speed;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        transform.position = position;
        if (position.x < -boundary)
        {
            transform.position = new Vector2 (-boundary, position.y);
            position.x = -boundary;
        }
        if (position.x > boundary)
        {
            transform.position = new Vector2 (boundary, position.y);
            position.x = boundary;
        }
    }
}
