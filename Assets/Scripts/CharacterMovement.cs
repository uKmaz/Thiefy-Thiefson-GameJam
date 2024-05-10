using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalMoveSpeed = 5f; // Speed of the normal movement
    public float shiftMoveSpeed = 2f;  // Speed of the shift movement
    private Rigidbody2D rb;
    private float treasureEquipped=0;
    // TREASURE EQUIPPED İ AŞŞAĞIDA "BURASI" DİYE YAZDIĞIM YERDE TEXTE GÖNDER
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        float currentMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? shiftMoveSpeed : normalMoveSpeed;

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * currentMoveSpeed;

        // Apply movement to the Rigidbody2D
        rb.velocity = movement;

        if (Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1))
        {
            HandleMouseClick();
            // BURASI
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zone") && treasureEquipped != 0)
        {
            // ÇA ÇİNGGG PARA SESİ EKLİCEM

            treasureEquipped--; // Screen'deki kırmızı zone'a girince sol tık basarsa
            
        }
    }

    private void HandleMouseClick()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Treasure")&&treasureEquipped<2)
            {
                // COLLECT SESİ EKLİCEM
                Destroy(collider.gameObject);
                treasureEquipped++;
                break;
            }
            else if(treasureEquipped>2)
            {
                // FAZLA TREASURE ALIMI
                // ZONGG SESİ
            }
            


        }
    }
}
