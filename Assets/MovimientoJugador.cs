using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform camara; // Asigna aquí tu cámara en el Inspector

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        // Dirección relativa a la cámara
        Vector3 adelante = camara.forward;
        Vector3 derecha = camara.right;
        adelante.y = 0;
        derecha.y = 0;
        adelante.Normalize();
        derecha.Normalize();

        Vector3 movimiento = (adelante * movZ + derecha * movX) * velocidad * Time.deltaTime;
        transform.Translate(movimiento, Space.World);
    }
}
