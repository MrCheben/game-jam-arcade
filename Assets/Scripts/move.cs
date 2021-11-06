using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{

    public float speed = 2f;
    private Vector3 mvDirection = Vector3.zero;
    CharacterController Cac;


    // Start is called before the first frame update
    void Start()
    {
        Cac = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Cac.isGrounded){
            mvDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            mvDirection = transform.TransformDirection(mvDirection);
            mvDirection *= speed;
        }
        Cac.Move(mvDirection*Time.deltaTime);
    }
}
