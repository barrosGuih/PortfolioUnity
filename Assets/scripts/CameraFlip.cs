using UnityEngine;
using System.Collections;

public class CameraFlip : MonoBehaviour
{
    public KeyCode tecla = KeyCode.E;
    public float duracao = 1f;
    public float distancia = 3f;
    public Transform player;
    public Transform worldRoot;
    public GameObject particulas;

    [Header("Áudio")]
    public AudioSource audioSource; // NÃO usar PlayOnAwake

    private bool invertido = false;
    private bool emTransicao = false;

    void Update()
    {
        if (player == null || worldRoot == null || audioSource == null) return;

        float dist = Vector3.Distance(player.position, transform.position);

        if (dist <= distancia && Input.GetKeyDown(tecla))
        {
            if (!emTransicao)
            {
                StartCoroutine(FlipWorld());
            }
        }
    }

    IEnumerator FlipWorld()
    {
        emTransicao = true;


        // alterna estado
        invertido = !invertido;

        // 🔊 CONTROLE DO SOM
        if (invertido)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
                particulas.SetActive(true);
        }
        else
        {
            audioSource.Stop();
            particulas.SetActive(false);
        }

        Quaternion inicio = worldRoot.rotation;
        Quaternion fim = Quaternion.Euler(0, 0, invertido ? 180f : 0f);

        float t = 0f;
        while (t < duracao)
        {
            t += Time.deltaTime;
            worldRoot.rotation = Quaternion.Slerp(inicio, fim, t / duracao);
            yield return null;
        }

        worldRoot.rotation = fim;
        emTransicao = false;
        Debug.Log("Flip concluído!");
    }

    void OnDrawGizmosSelected()
    {
        if (player != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, distancia);
        }
    }
}
