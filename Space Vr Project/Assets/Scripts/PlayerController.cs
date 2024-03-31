using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // control speed
    public static Vector3 pos;
    public float speed = 50f;
    public CharacterController controller;
    public Transform cam;

    private void Start()
    {
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = cam.TransformDirection(moveDirection);
        // direction we want to move
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
