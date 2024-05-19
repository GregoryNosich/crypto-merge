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
    private static List<CollisionController> mergedCollisions = new List<CollisionController>();

    void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionController collisionController = nextPrefab.GetComponent<CollisionController>();

        if (mergedCollisions.Contains(this) || mergedCollisions.Contains(collisionController))
            return;

        if (this.name != collision.gameObject.name)
            return;

        if (nextPrefab == null)
            return;

        Vector2 newPosition;
        newPosition.x = (transform.position.x + collision.gameObject.transform.position.x) / 2;
        newPosition.y = (transform.position.y + collision.gameObject.transform.position.y) / 2;

        ScoreCounter.Score += collisionController.addScore;

        mergedCollisions.Add(this);
        mergedCollisions.Add(collisionController);

        Destroy(gameObject);
        Destroy(collision.gameObject);

        Instantiate(nextPrefab, newPosition, transform.rotation);
        newSparks = Instantiate(sparks, newPosition, Quaternion.identity);
    }

    private void Update()
    {
        mergedCollisions.Clear();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            gameOver = true;
        }
    }
}
