using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{

    [SerializeField] private GameObject[] Arc0;
    [SerializeField] private GameObject[] Arc1;
    [SerializeField] private GameObject[] Arc2;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    public string styleArc;
    public int PieceArc;
    private Quaternion RotationOrigin;
    public bool isPorter= false;
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
        var randomArc = Random.Range(0, 3);
        var randomPiece = Random.Range(0, 4);
        PieceArc = randomPiece;
        if (randomArc == 0) {
            styleArc = "Arc0";
            meshFilter.sharedMesh = Arc0[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc0[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc0[PieceArc].transform.localScale;
            transform.localRotation = Arc0[PieceArc].transform.localRotation;
            gameObject.AddComponent<SphereCollider>();
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
            gameObject.GetComponent<SphereCollider>().radius = 0.007f;

        } else if (randomArc == 1) {
            styleArc = "Arc1";
            meshFilter.sharedMesh = Arc1[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc1[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc1[PieceArc].transform.localScale;
            transform.localRotation = Arc1[PieceArc].transform.localRotation;
            gameObject.AddComponent<SphereCollider>();
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
            gameObject.GetComponent<SphereCollider>().radius = 0.007f;

        } else if (randomArc == 2) {
            styleArc = "Arc2";
            meshFilter.sharedMesh = Arc2[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc2[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc2[PieceArc].transform.localScale;
            transform.localRotation = Arc2[PieceArc].transform.localRotation;
            gameObject.AddComponent<SphereCollider>();
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
            gameObject.GetComponent<SphereCollider>().radius = 0.5f;
        }
        gameObject.AddComponent<BoxCollider>();
        RotationOrigin = transform.rotation;
        

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Plan") {
            isPorter = false;
            other.gameObject.GetComponent<Plan>().checkEmplacementPiece(this.gameObject);
            gameObject.transform.parent = null;


            transform.rotation = Quaternion.Euler(RotationOrigin.eulerAngles);


        } else if (other.tag == "Player") {
            GetComponent<SphereCollider>().enabled = false;
            gameObject.transform.parent = other.gameObject.transform;
            isPorter = true;
        }
        }



}
