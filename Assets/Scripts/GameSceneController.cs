using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextOutputHandler(string text);
public class GameSceneController : MonoBehaviour
{
    [Header("Player Settings")]
    [Range(5, 20)]
    public float playerSpeed = 10;
    [Header("Screen Settings")]
    public Vector3 screenBounds;

    [Header("Prefab")]
    [SerializeField]
    private EnemyController enemyPrefab;

    private HUDController hudController;
    private int totalScore;

    // Start is called before the first frame update
    void Start()
    {

        hudController = FindObjectOfType<HUDController>();
        screenBounds = GetScreenBounds();

        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GetScreenBounds()
    {
        var mainCamera = Camera.main;
        var screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        return mainCamera.ScreenToWorldPoint(screenVector);

    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(2);
        while(true)
        {
            var horizontalPosition = Random.Range(-screenBounds.x, screenBounds.x);
            var spawnPosition = new Vector2(horizontalPosition, screenBounds.y);
            var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            enemy.EnemyEscaped += EnemyAtBottom;
            enemy.EnemyKilled += EnemyKilled;

            yield return wait;
        }
    }

    private void EnemyKilled(int pointValue)
    {
        totalScore += pointValue;
        hudController.scoreText.text = totalScore.ToString();
    }

    private void EnemyAtBottom(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        Debug.Log("Enemy Escaped");
    }

    public void KillObject(IKillable killable)
    {
        killable.Kill();
    }

    public void OutputText(string output)
    {
        Debug.LogFormat("{0} output by GameSceneController", output);
    }
}
