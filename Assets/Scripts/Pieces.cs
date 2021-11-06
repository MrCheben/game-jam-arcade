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
    private Quaternion RotationOrigin;

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
        PieceArc = randomPiece;
        if (randomArc == 0) {
            styleArc = "Arc0";
            meshFilter.sharedMesh = Arc0[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc0[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc0[PieceArc].transform.localScale;
            transform.localRotation = Arc0[PieceArc].transform.localRotation;
            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<SphereCollider>();
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
            gameObject.GetComponent<SphereCollider>().radius = 0.007f;

        } else if (randomArc == 1) {
            styleArc = "Arc1";
            meshFilter.sharedMesh = Arc1[PieceArc].GetComponent<MeshFilter>().sharedMesh;
            meshRenderer.material = Arc1[PieceArc].GetComponent<Renderer>().sharedMaterial;
            transform.localScale = Arc1[PieceArc].transform.localScale;
            transform.localRotation = Arc1[PieceArc].transform.localRotation;
            gameObject.AddComponent<BoxCollider>();
        }
        RotationOrigin = transform.rotation;
        

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Plan") {
            other.gameObject.GetComponent<Plan>().checkEmplacementPiece(this.gameObject);
            gameObject.transform.parent = null;
            print(RotationOrigin.eulerAngles);

            //transform.rotation = new Vector3(RotationOrigin.eulerAngles, RotationOrigin.eulerAngles.y, RotationOrigin.eulerAngles.z);


        } else if (other.tag == "Player") {
            GetComponent<SphereCollider>().enabled = false;
            gameObject.transform.parent = other.gameObject.transform;
        }
        }



}
