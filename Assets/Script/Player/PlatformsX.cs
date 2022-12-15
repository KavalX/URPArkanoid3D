using System;
using UnityEngine;

public class PlatformsX : MonoBehaviour
{

    [SerializeField]
    int speed;
    [SerializeField]
    float minX = 12f;
    [SerializeField]
    float maxX = -12f;

    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;

    public Transform SpawnPos;
    public GameObject ballPrefab;

    private void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                platform1.transform.Translate(Vector3.left * speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                platform1.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                print("pulso");
                Instantiate(ballPrefab, SpawnPos.transform.position, Quaternion.identity);
            }


        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                platform2.transform.Translate(Vector3.left * speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                platform2.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            // Mover la plataforma hacia la izquierda si se presiona la flecha izquierda 
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                platform3.transform.Translate(Vector3.left * speed * Time.deltaTime);

            }

            // Mover la plataforma hacia la derecha si se presiona la flecha derecha
            if (Input.GetKey(KeyCode.RightArrow))
            {
                platform3.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }

    }

    private void Instantiate(object ballPrefab, object position, Quaternion identity)
    {
        throw new NotImplementedException();
    }

    void Movement()
    {





        // Si el cubo se est� moviendo a la derecha y su posici�n en el eje x
        // es mayor que la posici�n m�xima permitida, detenemos su movimiento
        if (transform.position.x < maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        // Si el cubo se est� moviendo a la izquierda y su posici�n en el eje x
        // es menor que la posici�n m�nima permitida, detenemos su movimiento
        if (transform.position.x > minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        // Si el cubo se est� moviendo dentro del rango permitido, actualizamos su
        // posici�n en el eje x seg�n la velocidad y la direcci�n en la que se est�
        // moviendo

    }
}


