using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandeManager : MonoBehaviour
{

    public GameObject prefabCommande;
    public float timeExpirationCommande;
    public float timeBetweenCommande;
    public float timeSinceLastCommande;
    [SerializeField] private Vector3 vectorPlacement;
    public float distanceBetweenCommande;
    public List<GameObject> listCommande;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastCommande = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastCommande < timeBetweenCommande) {
            timeSinceLastCommande += Time.deltaTime;
        } else {
            newCommande();
        }
    }

    void newCommande() {
        var newCommande=Instantiate(prefabCommande, transform.position + vectorPlacement,Quaternion.identity);
        newCommande.transform.parent = gameObject.transform;
        listCommande.Add(newCommande);
        vectorPlacement.x += distanceBetweenCommande;
        timeSinceLastCommande = 0;
    }

}
