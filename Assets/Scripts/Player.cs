using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    public float moveSpeed = 5;
    public bool isPorting=false;
    public float score;
    Camera viewCamera;
    PlayerController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 intersectionPoint = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, intersectionPoint, Color.red);
            controller.LookAt(intersectionPoint);
        }

        if (Input.GetMouseButtonDown(1)) {
            if(isPorting == true) {
                controller.LacherPiece();
            }
            
        }




    }



   /* private void OnTriggerEnter(Collider other) {
        print(other.name);
    }*/

    /*private void OnTriggerStay(Collider other) {
        if (other.tag == "Piece") {
            if (Input.GetMouseButtonDown(0)) {
                if (isPorting == false) {
                    controller.prendrePiece(other.gameObject);
                }
            }
        }
    }*/

}
