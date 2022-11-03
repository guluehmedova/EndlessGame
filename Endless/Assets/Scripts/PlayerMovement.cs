using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] Rigidbody rb;

    float horizontalInput;
    
    [SerializeField]
    float horizontalMultiplier;

    bool alive = true;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    
    void Start()
    {
        speed = 10f;
        horizontalMultiplier = 2;
    }
    private void FixedUpdate()
    {
        if (!alive) return;
        
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
        if (transform.position.y < -5f) { Die(); }
    }

    public void Die()
    {
        alive = false;
        //restart the game
        Invoke("Restart", 2f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        //if we are jump
        rb.AddForce(Vector3.up * jumpForce);
    }
}
