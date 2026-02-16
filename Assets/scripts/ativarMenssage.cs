using UnityEngine;

public class ativarMenssage : MonoBehaviour
{
    [SerializeField] private GameObject painelUI;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se quem entrou foi o Player
        if (other.CompareTag("Player"))
        {
            painelUI.SetActive(true); // Mostra a UI
            
            // Liberar o mouse se precisar clicar em algo na UI
            // Cursor.lockState = CursorLockMode.None;
            // Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            painelUI.SetActive(false); // Esconde a UI
            
            // Opcional: Trava o mouse de volta para o jogo
            // Cursor.lockState = CursorLockMode.Locked;
            // Cursor.visible = false;
        }
    }
}