using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRigidbody;
    public TextMeshProUGUI textScore;
    public float timeLeft;
    public GameObject canvasEnd;
    public GameObject canvasInGame;
    public TextMeshProUGUI ScoreFin;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            End();
        }
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

    public void LacherPiece() {
        if(this.transform.childCount != 0) {
            this.transform.GetChild(0).GetComponent<Pieces>().pieceLacher();
            GetComponent<Player>().isPorting = false;
        }
    }

    public void prendrePiece(GameObject piece) {
        GetComponent<Player>().isPorting = true;
        piece.GetComponent<Pieces>().piecePrise();
    }

    public void addScore(int point) {
        GetComponent<Player>().score += point;
        textScore.text = ""+GetComponent<Player>().score;
    }


    public void End() {
        print("end");
        canvasInGame.SetActive(false);
        canvasEnd.SetActive(true);
        ScoreFin.text = "" + GetComponent<Player>().score;
    }

    public void RestartGame() {
        SceneManager.LoadScene("SceneTanguy");
    }

}