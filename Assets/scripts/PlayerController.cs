using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float flySpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dodaj do wspolrzednych wartosc x=1 y=0 z=0 pomnozone przez czas
        //mierzony w sekundach do ostatniej klatki
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        //prezeentacja dzialania wygladzonego sterowania (emulacja joysticka)
        //Debug.Log(Input.GetAxis("Vertical"));

        //sterowanie predkoscia
        //stworz nowy wektor przesuniecia o wartosc 1 do przodu
        Vector3 movement = transform.forward;
        //pomnoz go przez czas od ostatniej klatki
        movement *= Time.deltaTime;
        //pomnoz go przez "wychylenie joysticka"
        movement *= Input.GetAxis("Vertical");
        //pomnoz predkosc obietku
        movement *= flySpeed;
        //dodaj ruch obietku
        //zmiana na fizyke
        // transform.position += movement;
        //komponent fizyki wewn�trz gracza
        Rigidbody rb = GetComponent<Rigidbody>();
        //dodaj si�e - do przodu statku w trybie zmiany pr�dko�ci
        rb.AddForce(movement, ForceMode.VelocityChange);



        //obrot
        //modyfikuj o� "Y" obiektu player
        Vector3 rotation = Vector3.up;
        //przemnoz przez czas
        rotation *= Time.deltaTime;
        //przemnoz przez klawiature
        rotation *= Input.GetAxis("Horizontal");
        //pomnoz przez predkosc obietku
        rotation *= rotationSpeed;
        //dodaj obrot obiektu
        //nie mozemy uzyc += poniewaz unity uzywa Quaterionow do zapisu rotacji
        transform.Rotate(rotation);

    }
    private void OnCollisionEnter(Collision collision)
    {
        //uruchamia sie automatycznie jesli zetkniekmy sie z innym coliderem

        //sprawdz czy doknelismy asteroidy
        if (collision.collider.transform.CompareTag("Asteroid"))
        {
            Debug.Log("Boom!");
            //pauza
            Time.timeScale = 0;
        }
    }
}
