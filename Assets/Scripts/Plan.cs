using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan : MonoBehaviour
{
    public List<GameObject> pieceIncruster;
    public int nbPieceIncruster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrusterPiece(GameObject piece) {
        pieceIncruster.Add(piece);
        piece.GetComponent<BoxCollider>().enabled = false;
        piece.GetComponent<Rigidbody>().useGravity = false;
        piece.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if(piece.GetComponent<Pieces>().PieceArc == 0) {
            piece.transform.position = transform.position+ new Vector3(-1,0,-1);
        } else if (piece.GetComponent<Pieces>().PieceArc == 1) {
            piece.transform.position = transform.position + new Vector3(-1, 0, 1);
        } else if (piece.GetComponent<Pieces>().PieceArc == 2) {
            piece.transform.position = transform.position + new Vector3(1, 0, 1);
        } else if (piece.GetComponent<Pieces>().PieceArc == 3) {
            piece.transform.position = transform.position + new Vector3(1, 0, -1);
        }

        
        nbPieceIncruster++;
        if (nbPieceIncruster == 4) {
            CheckCommande();
        }
    }

    public void DesincrusterPiece(GameObject piece) {
        nbPieceIncruster--;

    }

    void CheckCommande() {

    }



}
