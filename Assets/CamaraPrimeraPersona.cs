using UnityEngine;

public class CamaraPrimeraPersona : MonoBehaviour
{
    public float sensibilidad = 2f;
    float rotacionX = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
