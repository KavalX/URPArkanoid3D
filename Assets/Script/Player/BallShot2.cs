using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot2 : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [Header("Speeds")]
    [SerializeField]
    private float initialspeed;
    [SerializeField]
    public float speed;
    [SerializeField]
    public float PlatformBounc;
    [SerializeField]
    private Vector3 Velocity;
    [SerializeField]
    private float staticSpeed;
    [SerializeField]
    private Vector3 Direction;

  
    [SerializeField]
    private int pointsPerHit;
    

    public StateManager _stateManager;

    [Header("Enumerators")]
    [SerializeField]
    private GameState currentGameState;
    [SerializeField]
    private BrickType BrickColor;
    [SerializeField]
    private PlayerAbilities abilities;
    [SerializeField]
    private BrickType previousBrickType;

    // Almacena el número de veces que se ha chocado con el mismo tipo de ladrillo
    [SerializeField]
    private int sameBrickCount = 0;

    // Almacena el puntaje total
    [SerializeField]
    public int points = 0;
    [SerializeField]
    private int brickMultiply;



    private void Awake()
    {

        _stateManager = StateManager.FindObjectOfType<StateManager>();
        currentGameState = GameState.Playing;
        abilities = PlayerAbilities.None;
        rb = GetComponent<Rigidbody>();
        _stateManager.isBallInPlay = true;

    }

    private void Start()
    {
        Velocity.x = Random.Range(-1.5f, 1.5f);
        Velocity.z = 1;

        rb.AddForce(Velocity * initialspeed, ForceMode.VelocityChange);
    }

    private void Update()
    {

        Physics.IgnoreLayerCollision(10,11);
        
        //Debug.Log(rb.velocity.magnitude);


        if (rb.velocity.magnitude < staticSpeed)
        {
            // Establecemos la velocidad del Rigidbody en la velocidad deseada
            rb.velocity = rb.velocity.normalized * staticSpeed;
        }

        // Verificamos si la velocidad actual del Rigidbody es mayor que la velocidad máxima permitida
        if (rb.velocity.magnitude > speed)
        {
            // Establecemos la velocidad del Rigidbody en la velocidad máxima permitida
            rb.velocity = rb.velocity.normalized * speed;
        }

        if (_stateManager.pointsPerConsecutiveHit >= 4)
        {
            abilities = PlayerAbilities.ExtraLife;
        }

        

    }

  
    // Se llama cuando se choca con un ladrillo
    public void OnCollisionWithBrick(BrickType brickType)
    {

        // Si el tipo de ladrillo es el mismo que el anterior, se aumenta el contador
        if (brickType == previousBrickType)
        {
            sameBrickCount++;
           
        }
        // Si el tipo de ladrillo es diferente, se resetea el contador
        else
        {
            sameBrickCount = 0;
        }


        // Se aumenta el puntaje según el contador
        
        points += pointsPerHit + (sameBrickCount * brickMultiply);
        _stateManager.points = this.points;
       

        // Se actualiza el tipo de ladrillo anterior
        previousBrickType = brickType;
    }

    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "BlueBrick":
                
                BrickColor = BrickType.Blue;
                brickMultiply = 2;
                pointsPerHit = 10;

                
                //consecutiveHitsBlue++;

                OnCollisionWithBrick(BrickColor);


                break;

            case "YellowBrick":

                //BlueCalc();
                //consecutiveHitsYellow++;
                //_stateManager.pointsPerConsecutiveHit = 3;

                BrickColor = BrickType.Yellow;
                brickMultiply = 3;
                pointsPerHit = 20;
                OnCollisionWithBrick(BrickColor);


                break;

            case "OrangeBrick":
                
                BrickColor = BrickType.Orange;
                brickMultiply = 4;
                pointsPerHit = 30;
                OnCollisionWithBrick(BrickColor);

                //consecutiveHitsOrange++;
                //_stateManager.pointsPerConsecutiveHit = 4;


                break;
            case "BigBrick":
                
                BrickColor = BrickType.Red;
                brickMultiply = 5;
                pointsPerHit = 50;
                OnCollisionWithBrick(BrickColor);

                //consecutiveHitsOrange++;
                //_stateManager.pointsPerConsecutiveHit = 4;


                break;

            case "Platform":

                Velocity.x = Random.Range(-1.5f, 1.5f);
                Velocity.z = 5;

                rb.AddForce(Velocity * PlatformBounc, ForceMode.Impulse);
                _stateManager.pointsPerConsecutiveHit = 0;
                sameBrickCount = 0;

                break;

            case "Lose":
                _stateManager.pointsPerConsecutiveHit = 0;
                _stateManager.isBallInPlay = false;
                _stateManager.health -= 1;
                Destroy(this.gameObject);



                break;

            default:
                
                
                _stateManager.pointsPerConsecutiveHit = 0;
                break;
        }

    }

}


/*
[Header("PointsSystem")]
[SerializeField]
private int consecutiveHitsBlue;
[SerializeField]
private int consecutiveHitsYellow;
[SerializeField]
private int consecutiveHitsOrange;
[SerializeField]
private int currentPointsB;
[SerializeField]
private int currentPointsY;
[SerializeField]
private int currentPointsO;
[SerializeField]
private int PointsCount;
[SerializeField]
private bool isBonus;

*/