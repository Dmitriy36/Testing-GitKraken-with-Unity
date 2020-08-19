using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallController : MonoBehaviour
{

    public float upForce;
    Rigidbody2D rb;
    bool started;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.isKinematic = false;
            }
        } else
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            gameOver = true;
        }

        if(collision.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManager.instance.IncrementScore();
        }
    }

}
