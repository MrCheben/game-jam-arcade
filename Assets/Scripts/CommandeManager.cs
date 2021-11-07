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
    private Player player;
 
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastCommande = 100;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

    public void DeleteCommande(bool success,GameObject commande) {
        if(success == true) {
            player.GetComponent<PlayerController>().addScore(commande.GetComponent<Commande>().point);
            listCommande.Remove(commande);

            for (int i = 0; i < listCommande.Count; i++) {

                if (listCommande[i].transform.position.x > commande.transform.position.x) {
                    listCommande[i].transform.position =  new Vector3(listCommande[i].transform.position.x- distanceBetweenCommande, listCommande[i].transform.position.y, listCommande[i].transform.position.z);
                }

            }
            vectorPlacement.x -= distanceBetweenCommande;
            Destroy(commande);
            //player
        }
    }



}
