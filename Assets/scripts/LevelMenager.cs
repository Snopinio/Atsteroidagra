using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Transform player;
    //odleg³oœc od koñca poziomu
    public float levelExitDistance = 100;
    //punkt koñca poziomu
    public Vector3 exitPosition;
    public GameObject exitPrefab;
    //zmienna flaga oznaczajaca ukonczenie poziou
    //zmienna flaga ukonczenie poziomu
    public bool levelComplete = false;
    //taka sama tylko jesli przegramy
    public bool levelFailed = false;
    // Start is called before the first frame update
    void Start()
    {
        //znajdz gracza
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //wylosuj pozycjê na kole o œrednicy 100 jednostek
        Vector2 spawnCircle = Random.insideUnitCircle; //losowa pozycja x,y wewn¹trz ko³a o r=1
        //chcemy tylko pozycjê na okrêgu, a nie wewn¹trz ko³a
        spawnCircle = spawnCircle.normalized; //pozycje x,y w odleg³oœci 1 od œrodka
        spawnCircle *= levelExitDistance; //pozycja x,y w odleg³oœci 100 od œrodka
        //konwertujemy do Vector3
        //podstawiamy: x=x, y=0, z=y
        exitPosition = new Vector3(spawnCircle.x, 0, spawnCircle.y);
        Instantiate(exitPrefab, exitPosition, Quaternion.identity);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //funkcja jest uruchamiana kiedy 
    public void OnSuccess()
    {
        Time.timeScale = 0f;

        levelComplete = true;
        Camera.main.transform.Find("LevelCompleteSound").GetComponent<AudioSource>().Play();
    }
    public void OnFailure()
    {
        Time.timeScale = 0f;

        levelFailed = true;
        Camera.main.transform.Find("GameOverSound").GetComponent<AudioSource>().Play();
    }
}
