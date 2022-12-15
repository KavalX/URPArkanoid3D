using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    Transform PlatformTransform;
    [SerializeField]
    int speed;

    [SerializeField]
    float minX = 12f;
    [SerializeField]
    float maxX = -12f;


    public GameObject ballPrefab;
    [SerializeField]
    private Transform SpawnPos;

    [SerializeField]
    public StateManager _stateManager;

    public PlayerAbilities currentAbility;


    void Awake()
    {
        // Obtener la referencia al prefab de la bola


        PlatformTransform = GetComponent<Transform>();
    }

    private void Update()
    {

        if (_stateManager.isBallInPlay == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("pulso");
                Instantiate(ballPrefab, SpawnPos.transform.position, Quaternion.identity);
            }
        }

        switch (currentAbility)
        {
            case PlayerAbilities.None:
                // El jugador no tiene habilidades especiales
                break;
            case PlayerAbilities.SuperSpeed:
                speed = 30;
                break;
            case PlayerAbilities.ExtraLife:
                _stateManager.health = 3;
                break;
            case PlayerAbilities.MultiBall:
                // El jugador tiene varias pelotas
                break;

        }


    }
    void FixedUpdate()
    {

        // Mover la plataforma hacia la izquierda si se presiona la flecha izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlatformTransform.Translate(Vector3.left * speed * Time.deltaTime);

        }

        // Mover la plataforma hacia la derecha si se presiona la flecha derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlatformTransform.Translate(Vector3.right * speed * Time.deltaTime);
        }

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


