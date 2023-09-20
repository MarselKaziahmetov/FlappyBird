using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRateTime;
    [SerializeField] private float pipeHeight;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private GameObject pipeObject;

    private float timer = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("DifficultyLevel"))
        {
            int diff = PlayerPrefs.GetInt("DifficultyLevel");
            switch (diff)
            {
                case 0:
                    spawnRateTime = 2;
                    break;
                case 1:
                    spawnRateTime = 1.5f;
                    break;
                case 2:
                    spawnRateTime = 1;
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        if (timer > spawnRateTime)
        {
            PipeSpawnerAndDestroyer();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void PipeSpawnerAndDestroyer()
    {
        GameObject _newPipe = Instantiate(pipeObject);
        _newPipe.transform.position = transform.position + new Vector3(0f, Random.Range(-pipeHeight, pipeHeight), 0f);
        Destroy(_newPipe, timeToDestroy);
    }
}
