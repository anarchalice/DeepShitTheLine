using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedObject")
        {
            GameStateManager.SetState(GameState.GameOver);
        }
    }
}
