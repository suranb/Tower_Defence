using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawn;
    public float timeBetweenWaves = 20f;
    private float countdown = 0f;
    public Text waveCountdownText;
    private int waveNumber;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);

    }
    // IEnumerator lar oss fryse tiden så det ikke spawner dobbelte. venter halvt sekund før det kommer ny sapwn
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawn.position, spawn.rotation);
    }

    void EndPath()
    {

    }
}
