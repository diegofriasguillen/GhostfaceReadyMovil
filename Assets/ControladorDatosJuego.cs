using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControladorDatosJuego : MonoBehaviour
{
    public GameObject jugador;
    public string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();
    public GameObject knifes;
    public GameObject kills_;
    public GameObject tiempo;
    public GameObject powerUps;

    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";
        jugador = GameObject.FindGameObjectWithTag("Player");
        knifes = GameObject.FindGameObjectWithTag("KnifePoints");
        kills_ = GameObject.FindGameObjectWithTag("Points");
        tiempo = GameObject.FindGameObjectWithTag("Timer");

        CargarDatos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarDatos();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardarDatos();
        }
    }

    private void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);

            Debug.Log("Posicion Jugador : " + datosJuego.posicion);

            jugador.transform.position = datosJuego.posicion;
            jugador.GetComponent<Ghostface>().lives = datosJuego.vida;
            jugador.GetComponent<Ghostface>().UpdateLifeIcons();
            knifes.GetComponent<Points>().points = datosJuego.savedKnifes;
            kills_.GetComponent<NPCPoints>().killing = datosJuego.kills;
            tiempo.GetComponent<TimerController>().currentTime = datosJuego.tiempoGuardado;
            
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }

    private void GuardarDatos()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            posicion = jugador.transform.position,
            vida = jugador.GetComponent<Ghostface>().lives,
            savedKnifes = knifes.GetComponent<Points>().points,
            kills = kills_.GetComponent<NPCPoints>().killing,
            tiempoGuardado = tiempo.GetComponent<TimerController>().currentTime

        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos); 
        File.WriteAllText(archivoDeGuardado, cadenaJSON);
        Debug.Log("Archivo Guardado");
    }


}
