using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    //model zawierajacy 3 kostki
    GameObject model;
    //wylosowana rotacja/s
    Vector3 rotation = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        //przepisuje do zmiennej model obiekt -pojemnij zawierajacy kostki
        //bedace czescia modelu asteroidy
        model = transform.Find("Model").gameObject;
        //przygotuj generator liczb losowych
        //Random r = new Random();
        //nie robimy bo unity ma satyczne random

        //iteruj przez czesci modelu
        foreach (Transform cube in model.transform)
        { 
            //uzyj wbudowanego random.rotation
            cube.rotation = Random.rotation;

            //losowa liczba
            float scale = Random.Range(0.9f, 1.1f);

            //przeskaluj
            cube.localScale = new Vector3 (scale, scale, scale);
        }
        //wylosuj jednarozowo rotacje/s naszej asteroidy
        rotation.x = Random.value;
        rotation.y = Random.value;
        rotation.z = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        //obroc asteroide (model) w wyznaczonym kierunku
        model.transform.Rotate(rotation * Time.deltaTime);
    }
}
