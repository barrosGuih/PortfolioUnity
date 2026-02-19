using UnityEngine;

public class DoorOpen1 : MonoBehaviour
{
    [Header("Porta Direita")]
    public Transform portaDireita;
    // Mudei o nome de Z para X para fazer sentido
    public float dirXFechado = -8.95f; 
    public float dirXAberto = -6.21f;

    [Header("Porta Esquerda")]
    public Transform portaEsquerda;
    public float esqXFechado = -14.91f;
    public float esqXAberto = -17.77f;

    [Header("Configurações de Movimento")]
    public float velocidade = 5f;
    private bool playerEstaPerto = false;

    void Update()
    {
        // Define o alvo de cada porta no eixo X
        float targetDirX = playerEstaPerto ? dirXAberto : dirXFechado;
        float targetEsqX = playerEstaPerto ? esqXAberto : esqXFechado;

        // Move a Porta Direita no X
        if (portaDireita != null)
        {
            Vector3 posDir = portaDireita.localPosition;
            // O Lerp agora calcula o X
            float novoXDir = Mathf.Lerp(posDir.x, targetDirX, Time.deltaTime * velocidade);
            // Aplicamos o valor no primeiro parâmetro (X) e mantemos o Y e Z originais
            portaDireita.localPosition = new Vector3(novoXDir, posDir.y, posDir.z);
        }

        // Move a Porta Esquerda no X
        if (portaEsquerda != null)
        {
            Vector3 posEsq = portaEsquerda.localPosition;
            float novoXEsq = Mathf.Lerp(posEsq.x, targetEsqX, Time.deltaTime * velocidade);
            // Aplicamos o valor no primeiro parâmetro (X) e mantemos o Y e Z originais
            portaEsquerda.localPosition = new Vector3(novoXEsq, posEsq.y, posEsq.z);
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