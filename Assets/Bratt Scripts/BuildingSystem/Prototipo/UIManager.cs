using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI manager null");

            return _instance;
        }
    }

    public delegate void Pared();
    public static event Pared MostrarPared;
    public delegate void Suelo();
    public static event Pared MostrarSuelo;
    public delegate void Rampa();
    public static event Pared MostrarRampa;

    public GameObject pared;
    public GameObject suelo;
    public GameObject rampa;

    private void Awake()
    {
        _instance = this;

        pared.SetActive(false);
        suelo.SetActive(false);
        rampa.SetActive(false);

        MostrarPared += ParedM;
        MostrarRampa += RampaM;
        MostrarSuelo += SueloM;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MostrarPared();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            MostrarRampa();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            MostrarSuelo();
        }
    }

    private void ParedM()
    {
        pared.SetActive(true);
        suelo.SetActive(false);
        rampa.SetActive(false);
    }

    private void RampaM()
    {
        pared.SetActive(false);
        suelo.SetActive(false);
        rampa.SetActive(true);
    }
    private void SueloM()
    {
        pared.SetActive(false);
        suelo.SetActive(true);
        rampa.SetActive(false);
    }
}
