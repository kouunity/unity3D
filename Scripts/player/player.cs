using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 3.0F;
    private Vector3 moveDirection = Vector3.zero;
    // Use this for initialization
    void Start () {
	}
	// Update is called once per frame
	void Update () {

        // float x = Input.GetAxis("Horizontal");
        // float z = Input.GetAxis("Vertical");
        // Vector3 force = new Vector3(x*50,0,z*50);
        // Rigidbody rgb = GetComponent<Rigidbody>();
        // rgb.velocity = force;
        //// rgb.AddRelativeForce(force);
        // if (Input.GetMouseButton(1))
        // {
        //     float rota = Input.GetAxis("Mouse X");
        //     float x1 = transform.eulerAngles.x;
        //     float y1= transform.eulerAngles.y+rota;
        //     float z1= transform.eulerAngles.z;
        //     transform.Rotate(x1,y1,z1);
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
            }
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

       //// }
    }

}
