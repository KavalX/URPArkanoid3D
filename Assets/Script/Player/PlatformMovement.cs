using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    Transform PlatformTransform;
    [SerializeField]
    int speed;

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

        float dir = Input.GetAxis("Horizontal");
        float newX = transform.position.x + Time.deltaTime * speed * dir;
        float clampedX = Mathf.Clamp(newX, -maxX, maxX);

        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
    }


