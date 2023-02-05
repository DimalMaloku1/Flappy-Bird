
/* I gjith ky komponent sherben qe te realizohet animacioni i karakterit,levizja Fizike e Karakterit dhe disa metoda te tjra per Obstacles*/

using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite [] sprites;

    private int spriteIndex;
    
    private Vector3 direction;

    public float gravity = -9.8f;

    public float strength = 5f;

    public static int numberOfCoins;


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    public void OnEnable()
    {
        Vector3 position = transform.position;   /*Tek kjo pjese e metodes vetem e demonstron poziten e karakterit*/
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            direction = Vector3.up * strength;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);  

            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];

    }
    private void OnTriggerEnter2D(Collider2D other)  /* Aktivizon Trigger tek karakteri (Flappy Bird) 
                                                      * Nese godet ndonje objekt qe eshte "Obstacle",
                                                      * Ateher eshte GameOver */
    {
        if (other.gameObject.tag == "Obstacle") 
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag =="Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}