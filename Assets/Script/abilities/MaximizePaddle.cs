using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MaximizePaddle : ability
{
    [SerializeField]
    private GameObject paddle;
    [SerializeField]
    private Vector3 originalSize;
    public float tiempo = 5f;

    public void SetPaddleScale()
    {
       originalSize = paddle.transform.localScale;
    }

    public override void Activate()
    {
        paddle.transform.localScale = originalSize * 1.5f;
    }

    public override void Desactivate()
    {
        paddle.transform.localScale = originalSize;
    }

    private void Start()
    {
        SetPaddleScale();
    }

    private void Update()
    {
       
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MaxPowerUp")
        {


            Activate();

            tiempo -= Time.deltaTime;
           
            if (tiempo < 0)
            {


                Desactivate();
                
            }
        }

        
    }
}

