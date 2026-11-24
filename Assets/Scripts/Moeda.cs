using UnityEngine;

public class Moeda : MonoBehaviour
{
    [Header("Giro")]
    [SerializeField] private float velocidadeGiro = 180f;

    [Header("Flutuação")]
    [SerializeField] private bool flutuar = true;
    [Tooltip("altura máxima, em unidades")]
    [SerializeField, Range(0f, 1f)] private float amplitude = 0.25f;
    [SerializeField, Range(0f, 5f)] private float frequencia = 2f;
    private Vector3 posicaoInicial;
    private float defasagem;

    [Header("Config Cor")]
    [SerializeField] private bool brilhar = true;
    [SerializeField] private Color piscaMoeda = Color.red;
    [SerializeField] private Color corMoeda = Color.yellow;
    [SerializeField] private float piscador = 0.5f;
    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        posicaoInicial = transform.localPosition;
        defasagem = Random.Range(0f, 2f * Mathf.PI);
        Debug.Log($"Moeda pronta em {transform.position}");
    }
    void Update()
    {
        Girar();
        if (flutuar)
        {
            Flutuar();
        }  
        if (brilhar)
        {
            trocaCor();
        }
    }

    void Girar()
    {
        transform.Rotate(0f, velocidadeGiro * Time.deltaTime, 0f);
    }

    void Flutuar()
    {
        float t = Time.time * frequencia + defasagem;
        float y = Mathf.Sin(t) * amplitude;
        transform.localPosition = posicaoInicial + Vector3.up * y;
    }

    void trocaCor()
    {
        float a = Mathf.PingPong(Time.time * piscador, 1f);
        sprite.color = Color.Lerp(corMoeda, piscaMoeda, a);
    }
}
