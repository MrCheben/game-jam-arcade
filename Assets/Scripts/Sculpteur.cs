using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sculpteur : MonoBehaviour
{

    public GameObject prefabPiece;
    [SerializeField] private float timeBetweenSculpt;
    [SerializeField] private float DistanceSpawnPiece;
    [SerializeField] private Vector3 ForceSpawnPiece;
    [SerializeField] private Vector3 OriginForceSpawnPiece;
    [SerializeField] private float countRow;
    [SerializeField] private float countColumn;
    public float maxColumn;
    private Vector3 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        ForceSpawnPiece = OriginForceSpawnPiece;
        StartCoroutine(Scuplt());
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.A)) {
            InvokePiece();
        }

        if (Input.GetKeyDown(KeyCode.B)) {
            MoveSculpteur();
        }*/
    }

    void InvokePiece() {

        ForceSpawnPiece.y = ForceSpawnPiece.y - 5;
        var newPiece = Instantiate(prefabPiece,new Vector3(transform.position.x, transform.position.y, transform.position.z + DistanceSpawnPiece), transform.rotation);
        newPiece.GetComponent<Rigidbody>().AddForce(ForceSpawnPiece, ForceMode.Impulse);
        countRow++;
        if(countRow == 3) {

            countRow = 0;
            ForceSpawnPiece = OriginForceSpawnPiece;
            MoveSculpteur();
        }
    }

    void MoveSculpteur() {


        transform.position = new Vector3(transform.position.x+4.995f, transform.position.y, transform.position.z);
        countColumn++;
        if (countColumn == 3) {
            countColumn = 0;
            transform.position = originPosition;
        }

    }

    IEnumerator Scuplt() {
        InvokePiece();
        yield return new WaitForSeconds(timeBetweenSculpt);
        StartCoroutine(Scuplt());
    }

}
