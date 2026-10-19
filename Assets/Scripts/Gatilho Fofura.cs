using UnityEngine;

public class GatilhoFofura : MonoBehaviour
{
    [Header("Referências")]
    public ParticleSystem particulasCoracao;
    public GameObject textoVitoria;
    public MoveFelpudo scriptFelpudo;

    [Header("Configuração")]
    public string tagDoJogador = "Player";

    private bool jaAtivou = false;

    void Start()
    {
        if (particulasCoracao != null)
        {
            particulasCoracao.Stop();
        }

        if (textoVitoria != null)
        {
            textoVitoria.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (jaAtivou) return;

        if (outro.CompareTag(tagDoJogador))
        {
            jaAtivou = true;

            if (particulasCoracao != null)
            {
                particulasCoracao.Play();
            }

            if (textoVitoria != null)
            {
                textoVitoria.SetActive(true);
            }

            if (scriptFelpudo != null)
            {
                scriptFelpudo.Vencer();
            }
        }
    }
}