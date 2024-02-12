using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dodaj do wspolrzednych wartosc x=1 y=0 z=0 pomnozone przez czas
        //mierzony w sekundach do ostatniej klatki
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
    }
}
