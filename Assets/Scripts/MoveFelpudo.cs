using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MoveFelpudo : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 3f;
    public float forcaPulo = 5.5f;

    private Rigidbody2D rb;
    private float eixoX;
    private bool pular;
    private bool venceu = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // Reiniciar a qualquer momento com R
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        // Se já venceu, não lê mais input de movimento
        if (venceu)
        {
            eixoX = 0f;
            pular = false;
            return;
        }

        // Leitura do input (WASD + espaço)
        eixoX = 0f;
        if (Keyboard.current.aKey.isPressed) eixoX = -1f;
        if (Keyboard.current.dKey.isPressed) eixoX = 1f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            pular = true;
        }
    }

    void FixedUpdate()
    {
        if (venceu)
        {
            // Para o personagem completamente
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            return;
        }

        // Movimento horizontal: preserva o eixo Y (gravidade/colisão intactos)
        rb.linearVelocity = new Vector2(eixoX * velocidade, rb.linearVelocity.y);

        // Pulo
        if (pular)
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            pular = false;
        }
    }

    // Chamado pelo GatilhoFofura quando o jogador encosta na Fofura
    public void Vencer()
    {
        venceu = true;
    }
}