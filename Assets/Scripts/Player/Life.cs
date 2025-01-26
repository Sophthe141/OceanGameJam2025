using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour {

    [Header("Life Settings")]
    [SerializeField] private List<Image> lifeImages; // Lista de imagens da HUD de vida
    [SerializeField] private int maxLives = 3; // Número máximo de vidas
    private int currentLives; // Vida atual do player
    public bool isDead = false; // Flag para verificar se o player está morto
    public static Life instance;
    private Rigidbody2D rb;
    public float pushForce = 5f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Start() {
        // Inicializar variáveis
        currentLives = 3; // Carregue a vida do player do PlayerPrefs (ou defina um valor inicial)

        // Obter referências das imagens e adicioná-las à lista
        foreach (Image image in GetComponentsInChildren<Image>()) {
            if (image.tag == "LifeImage") {
                lifeImages.Add(image);
            }
        }
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();

        UpdateLifeHUD();
    }


    void UpdateLifeHUD() {
        // Mostrar/desativar imagens de acordo com a vida atual
        for (int i = 0; i < lifeImages.Count; i++) {
            if (i < currentLives) {
                lifeImages[i].enabled = true;
            } else {
                lifeImages[i].enabled = false;
            }
        }
        
    }

    public void AddLife() {
        currentLives = Mathf.Min(currentLives + 1, maxLives);
        UpdateLifeHUD();
    }

    public void RemoveLife() {
        currentLives = Mathf.Max(currentLives - 1, 0);
        animator.Play("Damage");
        UpdateLifeHUD();
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if (other.CompareTag("Enemy")) {
            
            RemoveLife();
            
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Vector2 pushDirection = (transform.position - other.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
           
        
    }

}