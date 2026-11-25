using UnityEngine;
using UnityEngine.InputSystem;

public class DiagnosticoJogador : MonoBehaviour
{
    [SerializeField] private Color corAlerta = Color.red;
    [SerializeField] private Color corInicial;
    private Vector3 posicaoInicial;
    private InputAction pular;
    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        pular = InputSystem.actions.FindAction("Jump");
    }

    void Start()
    {
        corInicial = sprite.color;
        posicaoInicial = transform.position;
    }

    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            sprite.color = (sprite.color == corAlerta) ? corInicial : corAlerta;
            Debug.Log($"Posição: {transform.position}");
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            transform.position = posicaoInicial;
            Debug.Log("Jogador voltou ao inicio");
        }

        if (pular.WasPressedThisFrame())
        {
            Debug.Log("Jogador pulou");
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
            {
                Debug.Log($"Posição: {transform.position}");
            }
    }
}
