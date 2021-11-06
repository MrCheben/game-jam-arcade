using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sculpteur : MonoBehaviour
{

    public GameObject prefabPiece;
    [SerializeField] private float DistanceSpawnPiece;
    [SerializeField] private Vector3 ForceSpawnPiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            InvokePiece();
        }
    }

    void InvokePiece() {
        var newPiece = Instantiate(prefabPiece,new Vector3(transform.position.x+ DistanceSpawnPiece, transform.position.y, -0.2f),Quaternion.identity);
        newPiece.GetComponent<Rigidbody>().AddForce(ForceSpawnPiece, ForceMode.Impulse);
    }
}
