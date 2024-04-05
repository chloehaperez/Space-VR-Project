using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // control speed
    public static Vector3 pos;
    public float speed = 50f;
    public float acceleration = 0;
    public CharacterController controller;
    public Transform cam;
    public Animation anim;
    Vector3 driftDirection;

    private void Start()
    {
        pos = gameObject.transform.position;
        anim["Scene"].speed = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;
        anim.Play("Scene");
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = cam.TransformDirection(moveDirection);
        // direction we want to move
        controller.Move(moveDirection * speed * Time.deltaTime);
        if(moveDirection != new Vector3(0, 0, 0)){
            acceleration = speed;
            anim["Scene"].speed = 1f;
            driftDirection = moveDirection;
        }
        else if(moveDirection == new Vector3(0, 0, 0) & acceleration > 0){
            controller.Move(driftDirection * acceleration * Time.deltaTime);
            acceleration = acceleration - .5f;
            anim["Scene"].speed = .5f;
        }
        else{
            anim["Scene"].speed = .2f;
        }
    }
}
