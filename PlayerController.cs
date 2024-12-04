using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float moveSpeed=5f;
    // Start is called before the first frame update
    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Vector2 move = new Vector2(h, v).normalized;
        _rb.velocity=move*moveSpeed;
    }
}
