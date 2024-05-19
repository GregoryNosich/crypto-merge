using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    public GameObject nextPrefab;
    public static bool gameOver = false;
    public int addScore = 0;
    public ParticleSystem sparks;
    private ParticleSystem newSparks;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.name == collision.gameObject.name && nextPrefab != null)
        {
            CollisionController collisionController = nextPrefab.GetComponent<CollisionController>();

            Vector2 newPosition;
            newPosition.x = (transform.position.x + collision.gameObject.transform.position.x) / 2;
            newPosition.y = (transform.position.y + collision.gameObject.transform.position.y) / 2;

            if (transform.position.x > collision.gameObject.transform.position.x || (transform.position.x == collision.gameObject.transform.position.x && transform.position.y > collision.gameObject.transform.position.y))
            {
                ScoreCounter.Score += collisionController.addScore;

                Destroy(gameObject);
                Destroy(collision.gameObject);

                Instantiate(nextPrefab, newPosition, transform.rotation);
                newSparks = Instantiate(sparks, newPosition, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            gameOver = true;
        }
    }
}
