using UnityEngine;
using UnityEngine.UI;

public class RoscoGenerator : MonoBehaviour
{
    public GameObject botonPrefab;
    public int cantidadLetras = 27; // Por ejemplo, 27 para el abecedario español
    public float radio = 200f; // Ajusta el radio según tu Canvas

    void Start()
    {
        string abecedario = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        for (int i = 0; i < cantidadLetras; i++)
        {
            float angulo = i * Mathf.PI * 2f / cantidadLetras;
            Vector3 pos = new Vector3(Mathf.Cos(angulo), Mathf.Sin(angulo), 0) * radio;
            GameObject boton = Instantiate(botonPrefab, transform);
            boton.GetComponent<RectTransform>().anchoredPosition = pos;
            boton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = abecedario[i].ToString();
        }
    }
}
