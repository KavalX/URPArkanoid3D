using UnityEngine;

public class Bricks : MonoBehaviour

{

    public BrickType brickType;

    public GameObject fracturePrefab;
    public Vector3 position;
    public string type;
    public int health;
    public int MaxHealth;
    //public int pointsPerBrick;

    

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ball":

                health--;

                if (health <= 0)
                {
                    Instantiate(fracturePrefab, transform.position, transform.rotation);
                    Destroy(gameObject);
                }

                switch (brickType)
                {
                    case BrickType.Blue:
                        // Realizar acción para el ladrillo de color azul
                        Debug.Log("soy azul");

                        break;

                    case BrickType.Yellow:
                        // Realizar acción para el ladrillo de color amarillo
                        Debug.Log("soy amarillo");

                        break;

                    case BrickType.Red:
                        // Realizar acción para el ladrillo de color oscuro
                        break;
                }


                break;

        }



    }

}
