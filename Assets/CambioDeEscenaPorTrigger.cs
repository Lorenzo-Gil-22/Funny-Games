using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscenaPorTrigger : MonoBehaviour
{
    public string nombreEscena; // Escribe aquí el nombre de la escena a cargar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu personaje tenga el tag "Player"
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
