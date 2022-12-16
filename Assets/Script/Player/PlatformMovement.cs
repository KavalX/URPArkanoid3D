using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField] int speed;

    [SerializeField] float maxX = -12f;

    [SerializeField] private Transform SpawnPos;

    [SerializeField] public StateManager _stateManager;

    public GameObject ballPrefab;

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

    }
    void FixedUpdate()
    {

        float dir = Input.GetAxis("Horizontal");
        float newX = transform.position.x + Time.deltaTime * speed * dir;
        float clampedX = Mathf.Clamp(newX, -maxX, maxX);

        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}


