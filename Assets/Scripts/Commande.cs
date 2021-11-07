using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commande : MonoBehaviour
{

    public int currentPiece=0;
    public int MaxPiece = 3;
    public Vector3 vectorPlacement;
    public float espacement;
    [SerializeField] private GameObject[] Arc2;
    [SerializeField] private GameObject[] Arc3;
    [SerializeField] public List<string> pieces;

    // Start is called before the first frame update
    void Start()
    {
        SetUpPlan();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetUpPlan() {
        for (int i = 0; i < MaxPiece; i++) {
            randomPiece();
        }
    }

    void randomPiece() {
        var randomArc = Random.Range(2, 4);

        if (currentPiece == 1) {
            vectorPlacement.z += espacement;
        } else if (currentPiece == 2) {
            vectorPlacement.x += espacement;
        } else if (currentPiece == 3) {
            vectorPlacement.z -= espacement;
        }

        if (randomArc == 2) {
            var newPiece = Instantiate(Arc2[currentPiece], transform.position + vectorPlacement, Arc2[currentPiece].transform.rotation);
            newPiece.transform.parent = gameObject.transform;
            newPiece.layer = 6;
        } else if (randomArc == 3) {
            var newPiece = Instantiate(Arc3[currentPiece], transform.position + vectorPlacement, Arc3[currentPiece].transform.rotation);
            newPiece.transform.parent = gameObject.transform;
            newPiece.layer = 6;
        }
        var currentPieceVal = currentPiece;
        if (currentPieceVal == 3) { currentPieceVal = 0; }
        pieces.Add("" + randomArc + "-" + currentPieceVal);
        currentPiece++;
    }

    void checkCommande() {

    }

}
