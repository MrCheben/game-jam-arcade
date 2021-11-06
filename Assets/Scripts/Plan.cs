using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan : MonoBehaviour
{
    public List<GameObject> pieceIncruster;
    public CommandeManager commandeManager;
    public int nbPieceIncruster;
    public int pieceCorrespondante;
    public bool checkPiece;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkEmplacementPiece(GameObject piece) {

        //if(pieceIncruster.Count >= 1) {
            for (int i = 0; i < pieceIncruster.Count; i++) {
               // print(pieceIncruster[i].GetComponent<Pieces>().PieceArc);
                if (pieceIncruster[i].GetComponent<Pieces>().PieceArc == piece.GetComponent<Pieces>().PieceArc) {
                    checkPiece = true;
                    print(true);
                } else {
                    checkPiece = false;
                }
            }

            if (checkPiece == false) {
                IncrusterPiece(piece);
            }

       /* } else {
            IncrusterPiece(piece);
            print("inf 0");
        }*/


    }

    void IncrusterPiece(GameObject piece) {
        pieceIncruster.Add(piece);
        piece.GetComponent<BoxCollider>().enabled = false;
        piece.GetComponent<Rigidbody>().useGravity = false;
        piece.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (piece.GetComponent<Pieces>().PieceArc == 0) {
            piece.transform.position = transform.position+ new Vector3(-0.5f,0,-0.5f);
        } else if (piece.GetComponent<Pieces>().PieceArc == 1) {
            piece.transform.position = transform.position + new Vector3(-0.5f, 0, 0.5f);
        } else if (piece.GetComponent<Pieces>().PieceArc == 2) {
            piece.transform.position = transform.position + new Vector3(0.5f, 0, 0.5f);
        } else if (piece.GetComponent<Pieces>().PieceArc == 3) {
            piece.transform.position = transform.position + new Vector3(0.5f, 0, -0.5f);
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
             print("Commande donné : ");
            //for (int i = 0; i < pieceIncruster.Count; i++) {
            //print("" + pieceIncruster[i].GetComponent<Pieces>().styleArc + "-" + pieceIncruster[i].GetComponent<Pieces>().PieceArc);
            //}



        for (int i = 0; i < commandeManager.listCommande.Count; i++) {
            //print("Piéces "+i + " " + commandeManager.listCommande[i].GetComponent<Commande>().pieces[i]);
        }
    }



}
