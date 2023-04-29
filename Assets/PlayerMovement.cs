using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    float timer;
    SpriteRenderer sr;
    GameObject player; 

    [SerializeField] GameObject[] characters;

    void ChangeColor()
    {
        Color randomColor = Random.ColorHSV();
        foreach (SpriteRenderer r in GetComponentsInChildren <SpriteRenderer>())
        {
            r.material.color = randomColor;
            randomColor = Random.ColorHSV();
        }
        foreach (SpriteShapeRenderer c in GetComponentsInChildren<SpriteShapeRenderer>())
        {
            c.color = randomColor;
            randomColor = Random.ColorHSV();
        }
    }

    void ChangeSpeed()
    {
        if (speed == 5f)
        {
            speed = 10f;
        }
        else if (speed == 10f)
        {
            speed = 20f;
        }
        else if (speed == 20f)
        {
            speed = 5f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) ChangeSpeed();
        
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
        if (Input.GetKey(KeyCode.A)) moveVector.x = -1;
        if (Input.GetKey(KeyCode.S)) moveVector.y = -1;
        if (Input.GetKey(KeyCode.D)) moveVector.x = 1;
        if (Input.GetKeyDown(KeyCode.F)) ChangeColor();

        moveVector.Normalize();
        transform.position += Time.deltaTime * speed * moveVector;
        if (moveVector.x < 0) sr.flipX = true;
        else if (moveVector.x > 0) sr.flipX = false;
    }
}
