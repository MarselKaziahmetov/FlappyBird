using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("DifficultyLevel"))
        {
            int diff = PlayerPrefs.GetInt("DifficultyLevel");
            switch (diff)
            {
                case 0:
                    speed *= 1;
                    break;
                case 1:
                    speed *= 1.5f;
                    break;
                case 2:
                    speed *= 2;
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
