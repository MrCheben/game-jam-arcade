using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{

    [SerializeField] private GameObject[] Arc2;
    [SerializeField] private GameObject[] Arc3;
    [SerializeField] private GameObject[] Arc4;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    public string styleArc;
    public string styleArc2;
    public int PieceArc;
    private Quaternion RotationOrigin;
    public bool isPorter= false;
    public bool inPlan = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent < MeshRenderer>();
        randomPiece();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            randomPiece();
        }*/

        if (isPorter == true) {
            transform.position = player.transform.position+ new Vector3(1,0,0);
            transform.rotation = player.transform.rotation ;
        }

    }

    void randomPiece() {
        var randomArc = Random.Range(2, 4);
        var randomPiece = Random.Range(0, 4);
        if (randomPiece == 3) {
            randomPiece = 0;
        }
            PieceArc = randomPiece;
        
        if (randomArc == 2) {
            styleArc = "Arc2";
            styleArc2 = "2";
            meshFilter.sharedMesh = Arc2[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc2[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc2[PieceArc].transform.localScale;
            transform.localRotation = Arc2[PieceArc].transform.localRotation;


        } else if (randomArc == 3) {
            styleArc = "Arc3";
            styleArc2 = "3";
            meshFilter.sharedMesh = Arc3[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc3[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc3[PieceArc].transform.localScale;
            transform.localRotation = Arc3[PieceArc].transform.localRotation;


        } else if (randomArc == 4) {
            styleArc = "Arc4";
            styleArc2 = "4";
            meshFilter.sharedMesh = Arc4[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc4[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc4[PieceArc].transform.localScale;
            transform.localRotation = Arc4[PieceArc].transform.localRotation;

        }
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
        gameObject.GetComponent<SphereCollider>().radius = 0.5f;
        gameObject.AddComponent<BoxCollider>();
        RotationOrigin = transform.rotation;
        

    }

    public void pieceLacher() {
        GetComponent<SphereCollider>().enabled = true;
        gameObject.transform.parent = null;
        isPorter = false;
    }

    public void piecePrise() {

            GetComponent<SphereCollider>().enabled = false;
            gameObject.transform.parent = player.gameObject.transform;
            isPorter = true;

        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Plan") {
            if(inPlan == false) {
                isPorter = false;
                player.gameObject.GetComponent<Player>().isPorting = false;
                // besoin de ne pas enelver des mains du joueur si deja remplit
                other.gameObject.GetComponent<Plan>().checkEmplacementPiece(this.gameObject);
                gameObject.transform.parent = null;
                transform.rotation = Quaternion.Euler(RotationOrigin.eulerAngles);
                inPlan = true;
                GetComponent<SphereCollider>().enabled = false;
            }



        }else if (other.tag == "Player") {
            if (inPlan == false) {
                if (other.gameObject.GetComponent<Player>().isPorting == false) {
                    other.gameObject.GetComponent<Player>().isPorting = true;
                    GetComponent<SphereCollider>().enabled = false;
                    gameObject.transform.parent = other.gameObject.transform;
                    isPorter = true;

                }
            } else if (inPlan == true) {
                /*inPlan = false;
                other.gameObject.GetComponent<Player>().isPorting = true;
                GetComponent<SphereCollider>().enabled = false;
                gameObject.transform.parent = other.gameObject.transform;
                isPorter = true;*/
            }

        }
    }



}
