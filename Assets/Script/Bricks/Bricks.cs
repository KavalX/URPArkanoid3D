using UnityEngine;

public class Bricks : MonoBehaviour

{
    private BallShot _ballShot;
    public GameObject MaxPaddlePU;
    public BrickType brickType;

    public GameObject fracturePrefab;
    public Vector3 position;
    public string type;
    public int health;
    public int MaxHealth;
    //public int pointsPerBrick;

    [SerializeField]
    public static int brickCount = 0;


    private void Start()
    {

        if (!GameObject.Find("Ball"))
        {
            return;

        }
        else { _ballShot.gameObject.GetComponent<BallShot>(); }


    }

    private void Update()
    {

       

        if (!GameObject.Find("Ball"))
        {

            return;


        }

        brickCount = _ballShot.sameBrickCount;

        if (brickCount == 2)
        {

            Instantiate(MaxPaddlePU, this.gameObject.transform.position, Quaternion.identity);

        }


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
