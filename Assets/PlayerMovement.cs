using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    float timer;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void ChangeSpeed()
    {
        if (speed == 5f)
        {
            speed = 10f;
            return;
        }
        if (speed == 10f)
        {
            speed = 15f;
            return;
        }
        if (speed == 15f)
        {
            speed = 5f;
            return;
        }
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
        moveVector.Normalize();
        transform.position += Time.deltaTime * speed * moveVector;
        if (moveVector.x < 0) sr.flipX = true;
        else if (moveVector.x > 0) sr.flipX = false;
    }
}
