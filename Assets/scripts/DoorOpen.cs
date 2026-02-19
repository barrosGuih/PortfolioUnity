using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [Header("Porta Direita")]
    public Transform portaDireita;
    private float dirZFechado = 1.055f;
    private float dirZAberto = -1.74f;

    [Header("Porta Esquerda")]
    public Transform portaEsquerda;
    private float esqZFechado = 7.015f;
    private float esqZAberto = 9.73f;

    [Header("Configurações de Movimento")]
    public float velocidade = 5f;
    private bool playerEstaPerto = false;

    void Update()
    {
        // Define o alvo de cada porta baseado se o player está perto ou não
        float targetDirZ = playerEstaPerto ? dirZAberto : dirZFechado;
        float targetEsqZ = playerEstaPerto ? esqZAberto : esqZFechado;

        // Move a Porta Direita
        if (portaDireita != null)
        {
            Vector3 posDir = portaDireita.localPosition;
            float novoZDir = Mathf.Lerp(posDir.z, targetDirZ, Time.deltaTime * velocidade);
            portaDireita.localPosition = new Vector3(posDir.x, posDir.y, novoZDir);
        }

        // Move a Porta Esquerda
        if (portaEsquerda != null)
        {
            Vector3 posEsq = portaEsquerda.localPosition;
            float novoZEsq = Mathf.Lerp(posEsq.z, targetEsqZ, Time.deltaTime * velocidade);
            portaEsquerda.localPosition = new Vector3(posEsq.x, posEsq.y, novoZEsq);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEstaPerto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEstaPerto = false;
        }
    }
}