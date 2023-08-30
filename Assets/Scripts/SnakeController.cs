using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private GameObject segmentPrefab;
    private List<GameObject> segments = new List<GameObject>();
    private bool isFirstSegment = true;

    void Start()
    {
        Reset();
        ResetSegment();
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
    }
    private void FixedUpdate()
    {
        SnakeMove();
        MoveSegment();
    }
    private void Reset()
    {
        direction = Vector2.right;
        Time.timeScale = 0.1f;
    }
    public void CreateSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab);
        newSegment.transform.position = segments[segments.Count - 1].transform.position;
        segments.Add(newSegment);
        if (isFirstSegment)
        {
            isFirstSegment = false;
            newSegment.SetActive(false);
        }
    }

    private void ResetSegment()
    {
        for(int i = 0; i < segments.Count; i++)
        {
            Destroy(segments[i]);
        }
        segments.Clear();
        segments.Add(gameObject);

        for(int i = 0; i < 3; i++)
        {
            CreateSegment();    
        }
    }
    private void MoveSegment()
    {
        for(int i  = segments.Count -1; i > 0; i--)
        {
            segments[i].transform.position = segments[i - 1].transform.position;
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction= Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    private void SnakeMove()
    {
        float x, y;
        x = transform.position.x + direction.x;
        y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Segment"))
        {
            RestartGame();
        }
    
    }
}
