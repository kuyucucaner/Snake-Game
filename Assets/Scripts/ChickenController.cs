using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    [SerializeField] private SnakeController snakeController;
    [SerializeField] private float minX, maxX , minY, maxY;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            RandomChickenPosition();
            snakeController.CreateSegment();
        }
    }
    private void RandomChickenPosition()
    {
        transform.position = new Vector2(
            Mathf.Round(Random.Range(minX, maxX)) + 0.5f,
            Mathf.Round(Random.Range(minY, maxY)) + 0.5f
            );
    }
}
