using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float speed = 50f;
    [SerializeField] private Transform panel;

    [SerializeField] private float swipeSpeed = 5f;
    private Vector3 currentMousePosition;
    private Vector3 lastMousePosition;
    private Vector3 deltaMousePosition;
    
    
    void Update()
    {
#if UNITY_EDITOR
        currentMousePosition = Input.mousePosition;
        deltaMousePosition = currentMousePosition - lastMousePosition;
        lastMousePosition = currentMousePosition;
        deltaMousePosition = new Vector3(deltaMousePosition.x / Screen.width, 0f, 0f);

        if (Input.GetMouseButton(0))
        {
            if (deltaMousePosition == Vector3.zero) return;
            transform.position += deltaMousePosition * swipeSpeed;
            var currentPosition = transform.position;
            var fixedXPosition = Mathf.Clamp(currentPosition.x, -4.37f, 4.45f);
            var newPosition = currentPosition;
            newPosition.x = fixedXPosition;
            transform.position = newPosition;
        }
#endif
        
        /*deltaMousePosition = Input.touches[0].deltaPosition;
        deltaMousePosition = new Vector3(deltaMousePosition.x / Screen.width, 0f, 0f);
        if (Input.touchCount == 1)
        {
            if (deltaMousePosition == Vector3.zero) return;
            transform.position += deltaMousePosition * (swipeSpeed * Time.deltaTime);
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.forward * speed;
    }
    
}