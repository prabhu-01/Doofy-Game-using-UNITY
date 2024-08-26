using UnityEngine;
using System.Collections;

public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab;
    private float minDestroyTime;
    private float maxDestroyTime;
    private float spawnTime;

    private Vector3 lastPulpitPosition;
    private int maxPulpits = 2;
    private int currentPulpits = 0;

    private ScoreManager scoreManager;
    private bool isGameActive = true;

    void Start()
    {
        var pulpitData = FindObjectOfType<GameController>().gameData.pulpit_data;
        minDestroyTime = pulpitData.min_pulpit_destroy_time;
        maxDestroyTime = pulpitData.max_pulpit_destroy_time;
        spawnTime = pulpitData.pulpit_spawn_time;

        lastPulpitPosition = Vector3.zero;

        scoreManager = FindObjectOfType<ScoreManager>();

        StartCoroutine(SpawnInitialPulpit());
        StartCoroutine(ManagePulpits());
    }

    IEnumerator SpawnInitialPulpit()
    {
        GameObject initialPulpit = Instantiate(pulpitPrefab, lastPulpitPosition, Quaternion.identity);
        currentPulpits++;

        float initialDestroyTime = 2f;
        Destroy(initialPulpit, initialDestroyTime);

        yield return new WaitForSeconds(initialDestroyTime);

        RemovePulpit();
    }

    IEnumerator ManagePulpits()
    {
        float initialDelay = 0.1f;
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            if (!isGameActive) yield break;

            if (currentPulpits < maxPulpits)
            {
                Vector3 spawnPosition = GetNextPulpitPosition();
                GameObject pulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);
                lastPulpitPosition = pulpit.transform.position;
                currentPulpits++;

                scoreManager.AddScore(1);

                float destroyTime = 4f;
                Destroy(pulpit, destroyTime);
                RemovePulpit();

                yield return new WaitForSeconds(spawnTime);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    Vector3 GetNextPulpitPosition()
    {
        float[] possibleOffsets = { -9f, 9f };
        Vector3 offset = Vector3.zero;

        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                offset = new Vector3(9f, 0, 0);
                break;
            case 1:
                offset = new Vector3(-9f, 0, 0);
                break;
            case 2:
                offset = new Vector3(0, 0, 9f);
                break;
            case 3:
                offset = new Vector3(0, 0, -9f);
                break;
        }

        Vector3 newPosition = lastPulpitPosition + offset;
        return newPosition;
    }

    public void RemovePulpit()
    {
        currentPulpits--;
    }

    public void StopGame()
    {
        isGameActive = false;
    }
}
