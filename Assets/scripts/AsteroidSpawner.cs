#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //gracz (jego pozycja)
    Transform player;

    //prefab statycznej asteroidy
    public GameObject staticAsteroid;

    //czas od ostatio wygenerowanej asteoidy
    float timeSinceSpawn;

    //odleglosc w jakiej spawnuje sie asteroidy
    public float spawnDistance = 10;

    //odleglosc pomiedzy asteroidami
    public float safeDistance = 10;

    //odstep pomiedzy spawnem kolejnych asteroid
    public float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        //znajdz gracz i przypisz do zmiennej
        player = GameObject.FindWithTag("Player").transform;

        //zeruj czas
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceSpawn > cooldown)
        {
            SpawnAsteroid(staticAsteroid);
            timeSinceSpawn = 0;
        }


        AsteroidCountControll();

        timeSinceSpawn += Time.deltaTime;
    }

    GameObject? SpawnAsteroid(GameObject prefab)
    {
        //nieskonczony while - wyjdziemy returnem
        //generyczna funkcja sluzaca do wylosowania wspolrzednych i umieszczenia
        //w tym miejscu asteroidy z prefaba

        //stworz losowa pozycje na okregu (x,y)
        Vector2 randomCirclePosition = Random.insideUnitCircle.normalized;

        //losowa pozycja w odleg³oœci 10 jednostek od œrodka œwiata
        //mapujemy x->x  
        Vector3 randomPosition = new Vector3(randomCirclePosition.x, 0, randomCirclePosition.y) * spawnDistance;

        //na³ó¿ pozycjê gracza - teraz mamy pozycje 10 jednostek od gracza
        randomPosition += player.position;

        //sprawdz czy miejsce jest wolne
        //! oznaczanie nie czyli nie ma nic w promieniu 5 jednostek od miejsca randomposition
        if (!Physics.CheckSphere(randomPosition, safeDistance))
        {
            //stworz zmienn¹ asteroid, zespawnuj nowy asteroid korzystaj¹c z prefaba
            // w losowym miejscu, z rotacj¹ domyœln¹ (Quaternion.identity)
            GameObject asteroid = Instantiate(staticAsteroid, randomPosition, Quaternion.identity);
            //zwróæ asteroidê jako wynik dzia³ania
            return asteroid;
        }
        else
        {
            return null;
        }
    }
    void AsteroidCountControll()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        //przejdz pela 
        foreach (GameObject asteroid in asteroids)
        {
            //odleglosc od gracza

            //wektor przesuniecia miedzy graczem a asteroida
            //Co ile musze przesunac gracza zeby znalazl sie w miejscu asteroidy
            Vector3 delta = player.position - asteroid.transform.position;
            float distanceToPlayer = delta.magnitude;

            if (distanceToPlayer > 30)
            {
                Destroy(asteroid);
            }
        }
    }
}