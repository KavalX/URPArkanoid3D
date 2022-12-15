using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public StateManager _stateManager;

    public TextMeshProUGUI healthHUD;
    public TextMeshProUGUI pointsHUD;
    public TextMeshProUGUI multiplyHUD;


    void Start()
    {
        // Asigna el objeto Text Mesh Pro a la variable
        //healthHUD = GetComponent<TextMeshProUGUI>();
        

    }

    // Método que se ejecuta en cada frame del juego
    void Update()
    {

        

        healthHUD.text = $"Health : {_stateManager.health}";
        pointsHUD.text = $"Points : {_stateManager.points}";

        multiplyHUD.text= $"X{_stateManager.pointsPerConsecutiveHit}";


    }
   
}
