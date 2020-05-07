using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    Text TextoAmarillo;
    [SerializeField]
    Text TextoRojo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ActualizarPuntaje();
    }
    private void ActualizarPuntaje()
    {
        TextoAmarillo.text = player.PuntajeAm.ToString();
        TextoRojo.text = player.PuntajeRojo.ToString();
    }
}
