using System.Collections;
using UnityEngine;

public class BrickTest : MonoBehaviour

{
    public Bricks brickTf;


    public MeshRenderer p1; 
    public MeshRenderer p2; 
    public MeshRenderer p3; 
    public MeshRenderer p4; 
    public MeshRenderer p5;
    public MeshRenderer p6;
    public MeshRenderer p7;
    public MeshRenderer p8;

    public int flashCount = 0; // contador para llevar el registro de cuántas veces ha parpadeado el cubo
    
    public float tiempo = 2.5f;

    private void Update()
    {

        


        switch (flashCount)
        {
            case 0:

                tiempo -= Time.deltaTime;
                if (tiempo < 0)
                {
      

                    flashCount++;
                    tiempo = .2f;
                }

                break;
            
            case 1:

                tiempo -= Time.deltaTime;
                if (tiempo < 0)
                {
                    p1.enabled = false;
                    p2.enabled = false;
                    p3.enabled = false;
                    p4.enabled = false;
                    p5.enabled = false;
                    p6.enabled = false;
                    p7.enabled = false;
                    p8.enabled = false;

                    flashCount++;
                    tiempo = .2f;
                }

                break;

            case 2:

                tiempo -= Time.deltaTime;
                if (tiempo < 0)
                {
                    p1.enabled = true;
                    p2.enabled = true;
                    p3.enabled = true;
                    p4.enabled = true;
                    p5.enabled = true;
                    p6.enabled = true;
                    p7.enabled = true;
                    p8.enabled = true;

                    flashCount++;
                    tiempo = .2f;
                }

                break;


            case 3:

                tiempo -= Time.deltaTime;
                if (tiempo < 0)
                {
                    p1.enabled = false;
                    p2.enabled = false;
                    p3.enabled = false;
                    p4.enabled = false;
                    p5.enabled = false;
                    p6.enabled = false;
                    p7.enabled = false;
                    p8.enabled = false;

                    flashCount++;
                    tiempo = .2f;
                }

                break; 
            
            case 4:

                tiempo -= Time.deltaTime;
                if (tiempo < 0)
                {
                    p1.enabled = true;
                    p2.enabled = true;
                    p3.enabled = true;
                    p4.enabled = true;
                    p5.enabled = true;
                    p6.enabled = true;
                    p7.enabled = true;
                    p8.enabled = true;

                    flashCount++;
                    tiempo = .2f;
                }

                break;


            case 5:

                tiempo -= Time.deltaTime;
                if (tiempo < 0)
                {
                    Destroy(gameObject);
                }
               


                break;
        }
    }

}
