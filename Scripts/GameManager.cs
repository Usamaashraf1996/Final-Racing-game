using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public List<GameObject> enemy;
    public List<GameObject> position;
    public GameObject trainPrefab;
  
    public Text timerText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
   
    private float spawnrate = 1.0f;
    private float time = 1.0f;
    public bool isGameActive;
    public static GameManager instance;
    public float currentTime = 0;
    private float startTime = 25;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentTime = startTime;
      
    }
    void Update()
    {
        if (isGameActive == true)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = "Timer " + currentTime.ToString("0");
        }
        GameOver();
    }
    IEnumerator spawnCar() {
        //For Enemy Car Spawn evey 2sec
        while (isGameActive) {
            yield return new WaitForSeconds(time);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], transform.position, enemy[index].transform.rotation);
            int number = Random.Range(4, 6);
            Instantiate(enemy[number], GenerateSpawnPosition(), enemy[number].transform.rotation);
            int nUmber = Random.Range(7, enemy.Count);
            Instantiate(enemy[nUmber], GenerateSpawnPos(), enemy[nUmber].transform.rotation);
            Instantiate(trainPrefab, TrainSpawnPos(), trainPrefab.transform.rotation);
            Instantiate(enemy[nUmber], position[0].transform.position, position[0].transform.rotation);
           Instantiate(enemy[nUmber], position[1].transform.position, position[1].transform.rotation);
            Instantiate(enemy[number], position[2].transform.position, position[2].transform.rotation);
            Instantiate(enemy[number], position[3].transform.position, position[3].transform.rotation);
            Instantiate(enemy[nUmber], position[4].transform.position, position[4].transform.rotation);
            Instantiate(enemy[nUmber], position[5].transform.position, position[5].transform.rotation);
            Instantiate(enemy[number], position[6].transform.position, position[6].transform.rotation);
            Instantiate(enemy[number], position[7].transform.position, position[7].transform.rotation);
            yield return new WaitForSeconds(10.0f);
            Instantiate(trainPrefab, TrainSpawnPos(), trainPrefab.transform.rotation);
           
           // Instantiate(enemy[nUmber], testPrefab.transform.position, testPrefab.transform.rotation);
        }     
    }
    private Vector3 GenerateSpawnPosition()//car spawn position
    {

        float spawnX = Random.Range(100, 134);
        float spawnZ = Random.Range(185, 205);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
    private Vector3 GenerateSpawnPos()
    {

        float spawnX = Random.Range(-166, -68);
        float spawnZ = Random.Range(-36, -12);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
    private Vector3 TrainSpawnPos()
    {

        float spawnX = Random.Range(-352, -352);
        float spawnZ = Random.Range(586.76f, 586.76f);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }

    public void GameOver()
    {
       // timerText.text = "Timer " + currentTime.ToString("0");
        if (currentTime <= 0){
            isGameActive = false;
            currentTime = 0;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Playercontroller.instance.youWonText.gameObject.SetActive(false);
        } }
    public void RestartGame()//restart scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Startgame(int difficulty)
    {

        isGameActive = true;
        StartCoroutine(spawnCar());
      
        spawnrate /= difficulty;  //spawnrate/= mean spawnrate=spawnrate/difficulty its a shortcut
        titleScreen.SetActive(false);
    }
}
