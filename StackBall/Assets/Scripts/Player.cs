using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class Player : MonoBehaviour
{
    public event System.Action onPlayerDeath;
    private int score;
    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] private float jumpForce = 120f;
    [SerializeField] private float jumpVelocity = 2.5f;
    bool clicking;
    Rigidbody playerRb;
    //float playerRadius;
    //bool grounded;

    public int Score { get { return score; } }


    void Start()
    {
        score = 0;
        playerRb = GetComponent<Rigidbody>();
        //playerRadius = this.gameObject.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump();
        //}
        //checkGrounded();

        if (Input.GetMouseButtonDown(0))
        {
            clicking = true;
            addForceDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;
        }
    }

    private void FixedUpdate()
    {
        //jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (clicking)
        {
            if (collision.collider.CompareTag("BadBlock"))
            {
                if (onPlayerDeath != null)
                {
                    onPlayerDeath();
                }
                Destroy(gameObject);
            }
            else if (collision.collider.CompareTag("GoodBlock"))
            {
                score++;
                Destroy(collision.transform.parent.gameObject);
            }
        }
        else jump();
    }

    //private void checkGrounded()
    //{
    //    grounded = false;
    //    Ray ray = new Ray(transform.position, -transform.up);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, playerRadius, groundLayer))
    //    {
    //        grounded = true;
    //    }
    //}


    private void addForceDown()
    {
        playerRb.velocity = -transform.up * jumpVelocity;
    }

    private void jump()
    {
        //playerRb.AddForce(transform.up * jumpForce);
        playerRb.velocity = transform.up * jumpVelocity;
        //if (grounded)
        //{
        //    playerRb.AddForce(transform.up * jumpForce);
        //}
    }
}
