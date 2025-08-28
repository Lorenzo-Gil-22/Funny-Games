using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    [Tooltip("Menu Juego")]
    public string nombreEscena;

    private void OnTriggerEnter(Collider other)
    {
        // Cambia "Player" por el tag de tu personaje si es necesario
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
