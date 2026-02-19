using UnityEngine;

public class desativarObj : MonoBehaviour
{
    [SerializeField] private GameObject painelUI;
    public GameObject objetoAlvo;
    private bool playerEstaPerto = false;

    void Update()
    {
        if (playerEstaPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (objetoAlvo != null)
            {
                objetoAlvo.SetActive(!objetoAlvo.activeSelf);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            painelUI.SetActive(true);
            playerEstaPerto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            painelUI.SetActive(false);
            playerEstaPerto = false;
        }
    }
}