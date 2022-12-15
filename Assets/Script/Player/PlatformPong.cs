using UnityEngine;

public class PlatformPong : MonoBehaviour
{

    [SerializeField]
    Transform PlatformTransform;
    [SerializeField]
    int speed;

    [SerializeField]
    float minZ = 12f;
    [SerializeField]
    float maxZ = -12f;

    public Transform SpawnPos;
    public GameObject BallPrefab;
    public bool canShoot;


    private void Update()
    {
        // Mover la plataforma hacia la izquierda si se presiona la flecha izquierda
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlatformTransform.Translate(Vector3.left * speed * Time.deltaTime);

        }

        // Mover la plataforma hacia la derecha si se presiona la flecha derecha
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlatformTransform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        // Si el cubo se est� moviendo a la derecha y su posici�n en el eje x
        // es mayor que la posici�n m�xima permitida, detenemos su movimiento
        if (transform.position.z < maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }
        // Si el cubo se est� moviendo a la izquierda y su posici�n en el eje x
        // es menor que la posici�n m�nima permitida, detenemos su movimiento
        if (transform.position.z > minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
        // Si el cubo se est� moviendo dentro del rango permitido, actualizamos su
        // posici�n en el eje x seg�n la velocidad y la direcci�n en la que se est�
        // moviendo

        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
        {
            Instantiate(BallPrefab, SpawnPos.transform.position, Quaternion.identity);
        }

    }


}


