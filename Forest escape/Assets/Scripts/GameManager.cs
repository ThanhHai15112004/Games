using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] spawnObject;
    public GameObject[] spawnEnemy;
    public GameObject[] spawnPoint;
  
    public float timer;
    public float timerBetweenSpawms;

    public float speedMultiplier;
    public float distance;


    public Text Score;
    public Text Score2;

    private void Update()
    {
        Score.text = "SCORE: " + ((uint)distance);
        Score2.text = " " + ((uint)distance);
        

        timer += Time.deltaTime ;
        speedMultiplier += 0.4f * timer * Time.deltaTime;

        timerBetweenSpawms -= 0.01f * speedMultiplier * Time.deltaTime;
        timerBetweenSpawms = Mathf.Clamp(timerBetweenSpawms,1.3f , 3f);

        distance += Time.deltaTime * 5f;

        int randNum = Random.Range(0, 2);

        if (timer > timerBetweenSpawms)
        {

            timer = 0;
            int randNumn = Random.Range(0, spawnPoint.Length);
            Vector3 vector3 = spawnPoint[randNumn].transform.position;

            if (randNum == 0)
                SpawnObject(vector3);
            
           else
                SpawnEnemy(vector3);
        }
    }

    private void SpawnObject(Vector3 vector3)
    {
        vector3.y += Random.Range(-1.5f,0.5f);
        int randNum = Random.Range(0, spawnObject.Length);
        GameObject obj = spawnObject[randNum];


        Instantiate(obj, vector3, Quaternion.identity);
    }
    private void SpawnEnemy(Vector3 vector3)
    {
        int ranNum = Random.Range(0, spawnEnemy.Length);
        GameObject obj = spawnEnemy[ranNum];


        Instantiate(obj, vector3, Quaternion.identity);
    }
 
}
