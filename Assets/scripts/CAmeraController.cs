using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAmeraController : MonoBehaviour
{
    //wsprzolrzedne gracza
    Transform player;
    //wysokosc kamery
    public float cameraHeight = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //podlacz pozycje gracza do okalnej zmiennej korzystajac z jego taga
        //to nie jest zapisanie watosci jeden raz tylko referencja obiektu
        //to znaczy ze player zawsze bedzie zawieral aktualna pozycje gracza
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //oblicz docelowa pozycje kamery
        Vector3 targetPosition = player.position + Vector3.up * cameraHeight;
        //plynnie przesun kamere w kierunku gracza
        //funkcja Vector3.lep
        //przepllyne przechodzi z pozycji pierwszego argumentu w czasie trzeciego
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
