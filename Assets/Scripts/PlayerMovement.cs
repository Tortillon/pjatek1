using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float speed = 40f;

    void Start()
    {
        
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
    }
    void FixedUpdate()
    {   
    }
}
