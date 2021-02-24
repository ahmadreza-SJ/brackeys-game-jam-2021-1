using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

public class LevelController : MonoBehaviour
{
    public UnityEvent OnExitLevel;

    private BoxCollider2D levelCollider;

    private float currLevelLowerBound;
    private float currLevelUpperBound;

    public float Scaler;
    public float GravityScale;
    public float FirstLevelLowerBound;
    public float FirstLevelUpperBound;

    public void InitializeLevel(int level)
    {
        float levelLength = (FirstLevelUpperBound - FirstLevelLowerBound) * level * Scaler;
        float offset = FirstLevelLowerBound + (Scaler * level * (level - 1) / 2);
        currLevelLowerBound = offset;
        currLevelUpperBound = offset + levelLength;
        CreateLevelArea();
    }
    
    private void CreateLevelArea()
    {
        if(levelCollider != null)
        {
            Destroy(levelCollider);
        }
        levelCollider = gameObject.AddComponent<BoxCollider2D>();
        levelCollider.isTrigger = true;
        levelCollider.offset = new Vector2(0, (currLevelLowerBound + currLevelUpperBound) / 2);
        Range screenRange = GameManager.Instance.GetCameraViewXRange(0);
        levelCollider.size = new Vector2(screenRange.Max - screenRange.Min + 10, currLevelUpperBound - currLevelLowerBound);
    }

    private void throwBackToLevel()
    {
        float playerY = GameManager.Instance.Player.transform.position.y;
        Rigidbody2D playerRb = GameManager.Instance.Player.GetComponent<Rigidbody2D>();
        if (playerY > currLevelUpperBound)
        {
            playerRb.gravityScale = GravityScale;
        }

        if (playerY < currLevelLowerBound)
        {
            playerRb.gravityScale = -GravityScale;
        }
    }

    private void RemoveGravity()
    {
        GameManager.Instance.Player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            throwBackToLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            RemoveGravity();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        InitializeLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
