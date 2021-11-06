using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{

    [SerializeField] private GameObject[] Arc0;
    [SerializeField] private GameObject[] Arc1;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    public string styleArc;
    public int PieceArc;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent < MeshRenderer>();
        randomPiece();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            randomPiece();
        }*/
    }

    void randomPiece() {
        var randomArc = Random.Range(0, 2);
        var randomPiece = Random.Range(0, 4);
        print(randomPiece);
        PieceArc = randomPiece;
        if (randomArc == 0) {
            styleArc = "Arc0";
            meshFilter.sharedMesh = Arc0[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc0[PieceArc].GetComponent<Renderer>().sharedMaterial;
        } else if (randomArc == 1) {
            styleArc = "Arc1";
            meshFilter.sharedMesh = Arc1[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc1[PieceArc].GetComponent<Renderer>().sharedMaterial;
        }
        

    }

}
