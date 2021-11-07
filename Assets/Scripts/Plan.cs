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
    public int countPiece0 =0;
    [SerializeField] private GameObject piece0;
    [SerializeField] private GameObject piece1;
    [SerializeField] private GameObject piece2;
    [SerializeField] private GameObject piece3;
    [SerializeField] private int goodPiece;
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
                if (piece.GetComponent<Pieces>().PieceArc == 0) {
                if (countPiece0 >= 2) {
                    checkPiece = true;
                } else {
                    checkPiece = false;
                }

                }else if (pieceIncruster[i].GetComponent<Pieces>().PieceArc == piece.GetComponent<Pieces>().PieceArc) {
                    checkPiece = true;
                    //print(true);
                } else {
                    checkPiece = false;
                }
            


            }

        if (pieceIncruster.Count == 0) {
            //print("BECAUSE NO PIECEINCRUSTER YET");
            if (piece.GetComponent<Pieces>().PieceArc == 0) {
                checkPiece = false;
                } else{
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
            countPiece0++;

            if (countPiece0 == 1) {
                piece.transform.position = transform.position + new Vector3(-0.5f, 0, -0.5f);
                piece0 = piece;
            } else if (countPiece0 > 1) {
                piece.transform.position = transform.position + new Vector3(0.5f, 0, -0.5f);
                piece3 = piece;
            }
        } else if (piece.GetComponent<Pieces>().PieceArc == 1) {
            piece.transform.position = transform.position + new Vector3(-0.5f, 0, 0.5f);
            piece1 = piece;
        } else if (piece.GetComponent<Pieces>().PieceArc == 2) {
            piece.transform.position = transform.position + new Vector3(0.5f, 0, 0.5f);
            piece2 = piece;
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
        //Pour chaque commande
        for (int i = 0; i < commandeManager.listCommande.Count; i++) {

            if (piece0.GetComponent<Pieces>().styleArc2 + "-" + piece0.GetComponent<Pieces>().PieceArc == commandeManager.listCommande[i].GetComponent<Commande>().pieces[0]) {   
                goodPiece++;
            }

            if (piece1.GetComponent<Pieces>().styleArc2 + "-" + piece1.GetComponent<Pieces>().PieceArc == commandeManager.listCommande[i].GetComponent<Commande>().pieces[1]) {
                goodPiece++;
            }

            if (piece2.GetComponent<Pieces>().styleArc2 + "-" + piece2.GetComponent<Pieces>().PieceArc == commandeManager.listCommande[i].GetComponent<Commande>().pieces[2]) {
                goodPiece++;
            }

            if (piece3.GetComponent<Pieces>().styleArc2 + "-" + piece3.GetComponent<Pieces>().PieceArc == commandeManager.listCommande[i].GetComponent<Commande>().pieces[3]) {
                goodPiece++;
            }

            if(goodPiece == 4) {
                print(i+" Bonne commande !");
                SuccessCommande(commandeManager.listCommande[i]);
                break;
            } else {
                print("Mauvais commande !");
                goodPiece = 0;
            }

        }
            

    }

    void SuccessCommande(GameObject commande) {
        for (int i = 0; i < pieceIncruster.Count; i++) {
            Destroy(pieceIncruster[i]);
        }
        pieceIncruster.Clear();
        nbPieceIncruster = 0;
        countPiece0 = 0;
        piece0 = null;
        piece1 = null;
        piece2 = null;
        piece3 = null;
        goodPiece = 0;
        commandeManager.DeleteCommande(true, commande);
    }



}
