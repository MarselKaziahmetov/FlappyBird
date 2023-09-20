using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControll : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 1;
    [SerializeField] private GameOverHandler menuManager;

    private Rigidbody2D birdRigidbody;

    void Start()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        birdRigidbody.velocity = Vector2.up * jumpVelocity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        menuManager.GameOver();
    }
}
