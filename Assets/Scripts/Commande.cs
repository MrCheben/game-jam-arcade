using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commande : MonoBehaviour
{

    public int currentPiece=0;
    public int MaxPiece = 3;
    public Vector3 vectorPlacement;
    public float espacement;
    [SerializeField] private GameObject[] Arc0;
    [SerializeField] private GameObject[] Arc1;
    [SerializeField] private List<string> pieces;
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
        var randomArc = Random.Range(0, 2);

        if (currentPiece == 1) {
            vectorPlacement.z += espacement;
        } else if (currentPiece == 2) {
            vectorPlacement.x += espacement;
        }
        else if (currentPiece == 3) {
            vectorPlacement.z -= espacement;
        }

        if (randomArc == 0) {
            var newPiece=Instantiate(Arc0[currentPiece], transform.position+vectorPlacement, Arc0[currentPiece].transform.rotation);
            newPiece.transform.parent = gameObject.transform;
            newPiece.layer = 6;
        } else if (randomArc == 1) {
            var newPiece =  Instantiate(Arc1[currentPiece], transform.position+vectorPlacement, Arc1[currentPiece].transform.rotation);
            newPiece.transform.parent = gameObject.transform;
            newPiece.layer = 6;
        }
        pieces.Add("" + randomArc + "-" + currentPiece);
        currentPiece++;
    }

    void checkCommande() {

    }

}
