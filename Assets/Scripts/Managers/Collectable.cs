using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Collectable Settings")]
    [SerializeField] private GameObject collectable;
    [SerializeField] private GameObject colliderOfCollectable;
    public bool hasCollected = false;
    public bool isCollidingWithPlayer = false;
    public bool isInteracting;
    [SerializeField] private bool interactionCooldown = false;
    private bool playerIsHolding = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 totalMovement;
    [SerializeField] private bool isDestructible = false;
    [SerializeField] public bool isHolding = false;
    //[SerializeField] private bool isFirstTime = true;
    //private TutorialManager tutorialManager;
    //private FeatureManager featureManager; // FeatureManager instance
    private PlayerMovement player;
    private CollectItem playerCollect;

    void Start()
    {
        //tutorialManager = GameObject.FindGameObjectWithTag("TutorialManager").GetComponent<TutorialManager>();
        //featureManager = GameObject.FindGameObjectWithTag("FeatureManager").GetComponent<FeatureManager>(); // Initialize FeatureManager
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!isDestructible) { rb = GetComponent<Rigidbody2D>(); }

        colliderOfCollectable.SetActive(true);
        collectable.SetActive(true);

        isInteracting = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().isInteracting;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerCollect = GameObject.Find("Player").GetComponent<CollectItem>();
        playerIsHolding = playerCollect.IsCarringCollectable;
    }

    void Update()
    {
        // Atualiza playerIsHolding constantemente com base no estado real
        if (playerCollect != null)
        {
            playerIsHolding = playerCollect.IsCarringCollectable;
        }

        isInteracting = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().isInteracting;

        if (!interactionCooldown && isInteracting)
        {
            if (isCollidingWithPlayer)
            {
                if (!isHolding && !hasCollected && !playerIsHolding)
                {
                    Collect();
                }
                else if (isHolding && hasCollected)
                {
                    ReleaseCollectable();
                }
            }
            StartCoroutine(InteractionCooldown(0.5f));
        }

        if (!isDestructible)
        {
            if (isHolding)
            {
                CollectableOnHold();
            }
            VelocityControl();
        }
    }

    public void Collect()
    {
        // Verifica se o jogador pode carregar mais itens
        //if(featureManager.GetFeatureActive(this.gameObject.name)){ // Check if feature is active
            if (playerCollect.currentCargoCarry < playerCollect.MaxCargoCarry)
            {
                hasCollected = true;
                if (!playerIsHolding && !isHolding)
                {
                    playerIsHolding = true;
                    playerCollect.currentCargoCarry++;
                    playerCollect.IsCarringCollectable = true;  // Atualiza o estado para "carregando"
                    CollectableOnHold();
                }
                else
                {
                    hasCollected = false;
                }
            }
            else
            {
                hasCollected = false;
            }
        //}
        //}else{
        //Debug.Log("Feature not active " + this.gameObject.name);
        if (isDestructible)
        {
            //featureManager.activeFeature(this.gameObject.name);
            //hasCollected = true;
            //tutorialManager.ShowTutorial(collectable.name+"Tutorial");
            //Debug.Log(collectable.name+"Tutorial");
            collectable.SetActive(false);
        }
            //featureManager.activeFeature(this.gameObject.name);
        //}
    }

    void CollectableOnHold()
    {
        isHolding = true;
        colliderOfCollectable.SetActive(false);
        totalMovement = player.totalMovement;

        if (totalMovement.x > 0)
        {
            transform.position = new Vector3(player.transform.position.x + 0.9f, player.transform.position.y, transform.position.z);
        }
        else if (totalMovement.x < 0)
        {
            transform.position = new Vector3(player.transform.position.x - 0.9f, player.transform.position.y, transform.position.z);
        }
        else if (totalMovement.y > 0)
        {
            spriteRenderer.sortingOrder = 3;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, transform.position.z);
        }
        else
        {
            spriteRenderer.sortingOrder = 5;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }

    public void ReleaseCollectable()
    {
        totalMovement = player.totalMovement;
        rb.AddForce(totalMovement * 10, ForceMode2D.Impulse);
        spriteRenderer.sortingOrder = 3;
        colliderOfCollectable.SetActive(true);
        isHolding = false;
        hasCollected = false;

        if (playerCollect != null)
        {
            playerCollect.currentCargoCarry--;
            playerCollect.IsCarringCollectable = false;  // Atualiza o estado para "não carregando"
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }

    void VelocityControl()
    {
        if (rb.velocity.magnitude < 0.01f)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity *= 0.999f;
        }
    }

    private IEnumerator InteractionCooldown(float duration)
    {
        interactionCooldown = true;
        yield return new WaitForSeconds(duration);
        interactionCooldown = false;
    }
}
