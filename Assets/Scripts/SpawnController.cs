using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnController : MonoBehaviour
{
    public GameObject[] prefabToSpawn = new GameObject[3];
    public Sprite[] imageToSpawn = new Sprite[3];
    public float leftBound;
    public float rightBound;
    public float height;
    public float timer = 0.5f;
    private bool timer_set = false;
    private System.Random rnd = new System.Random();
    private int nextCircle;
    private Rigidbody2D component;
    public AudioClip CoinSound;
    public Image NextBall;
    public GameObject TutorialTextObject;

    private void SpawnNewShowCircle()
    {
        nextCircle = rnd.Next(0, 3);
        NextBall.sprite = imageToSpawn[nextCircle];
    }

    void Start()
    {
        SpawnNewShowCircle();
    }

    void Update()
    {
        if (CollisionController.gameOver) return;

        if (Input.GetMouseButtonDown(0) && !timer_set)
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.y = height;

            if (clickPosition.x > leftBound && clickPosition.x < rightBound)
            {
                timer_set = true;
                StartCoroutine(Cooldown());

                CollisionController collisionController = prefabToSpawn[nextCircle].GetComponent<CollisionController>();
                ScoreCounter.Score += collisionController.addScore;
                Instantiate(prefabToSpawn[nextCircle], clickPosition, Quaternion.identity);

                if (TutorialTextObject.activeInHierarchy == true)
                    TutorialTextObject.SetActive(false);

                PlayAudio();

                SpawnNewShowCircle();
            }
        }
    }

    public void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(CoinSound);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(timer);
        timer_set = false;
    }
}
