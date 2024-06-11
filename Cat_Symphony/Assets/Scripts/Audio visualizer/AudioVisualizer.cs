using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public GameObject prefab;  // El prefab que usaremos para visualizar el espectro
    public int numberOfObjects = 64;  // Número de objetos en el visualizador
    public float radius = 5f;  // Radio del círculo de visualización
    public float heightMultiplier = 2f;  // Multiplicador de altura
    public AudioSource audioSource;

    private GameObject[] objects;
    private float[] spectrumData;

    void Start()
    {
        // Crear objetos para visualizar el espectro
        objects = new GameObject[numberOfObjects];
        spectrumData = new float[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfObjects;
            Vector3 position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            objects[i] = Instantiate(prefab, position, Quaternion.identity);
            objects[i].transform.parent = this.transform;
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Obtener datos del espectro de audio
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Actualizar la altura de los objetos según el espectro
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 scale = objects[i].transform.localScale;
            scale.y = Mathf.Lerp(scale.y, spectrumData[i] * heightMultiplier, Time.deltaTime * 30);
            objects[i].transform.localScale = scale;
        }
    }
}

