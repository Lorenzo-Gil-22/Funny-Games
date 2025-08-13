
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelMenu;
    public GameObject panelOpciones;

    [Header("Volumen")]
    public Slider sliderVolumen;
    public TMP_InputField porcentajeTexto; // Este es el input de volumen
    public AudioMixer audioMixer;

    private bool actualizandoDesdeInput = false;

    void Start()
    {
        // Mostrar solo el menú al inicio
        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);

        // Configurar eventos
        sliderVolumen.onValueChanged.AddListener(CambiarVolumenDesdeSlider);
        porcentajeTexto.onEndEdit.AddListener(CambiarVolumenDesdeInput);
        porcentajeTexto.onSelect.AddListener(LimpiarAlSeleccionar);

        // Iniciar en 100%
        float valorInicial = 1f;
        sliderVolumen.value = valorInicial;
        ActualizarVolumen(valorInicial);
        porcentajeTexto.text = "100%";
    }

    public void Jugar()
    {
        Debug.Log("Clic en JUGAR detectado");
        SceneManager.LoadScene("Mapa 1"); // Usar cuando tengas otra escena
    }

    public void Opciones()
    {
        panelMenu.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void Volver()
    {
        panelOpciones.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Debug.Log("Juego cerrado");
    }

    private void ActualizarVolumen(float valor)
    {
        float volumenDB = Mathf.Lerp(-80f, 0f, valor);
        audioMixer.SetFloat("Volumen", volumenDB);
    }

    public void CambiarVolumenDesdeSlider(float valor)
    {
        if (actualizandoDesdeInput) return;

        int porcentaje = Mathf.RoundToInt(valor * 100);
        porcentajeTexto.text = porcentaje + "%";
        ActualizarVolumen(valor);
    }

    public void CambiarVolumenDesdeInput(string texto)
    {
        actualizandoDesdeInput = true;

        int valorNumerico;
        if (int.TryParse(texto, out valorNumerico))
        {
            valorNumerico = Mathf.Clamp(valorNumerico, 0, 100);
            float valorNormalizado = valorNumerico / 100f;

            sliderVolumen.value = valorNormalizado;
            ActualizarVolumen(valorNormalizado);
            porcentajeTexto.text = valorNumerico + "%";
        }
        else
        {
            porcentajeTexto.text = "";
        }

        // Forzar que el input pierda el foco al apretar Enter
        EventSystem.current.SetSelectedGameObject(null);

        actualizandoDesdeInput = false;
    }

    public void LimpiarAlSeleccionar(string textoActual)
    {
        porcentajeTexto.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu Juego"); // Cambia el nombre si tu escena principal se llama diferente
        }
    }
}


