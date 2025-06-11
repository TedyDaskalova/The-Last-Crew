using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;

    private Animator animator; // ⬅️ добавено

    void Start()
    {
        velocity = new Vector2(speed, speed);
        characterBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // ⬅️ взимаме Animator-а
    }

    void Update()
    {
        inputMovement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // Тригерваме правилната анимация
        if (inputMovement.y > 0)
        {
            animator.SetTrigger("WalkUp");
        }
        else if (inputMovement.y < 0)
        {
            animator.SetTrigger("WalkDown");
        }
    }

    void FixedUpdate()
    {
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        Vector2 newPosition = characterBody.position + delta;
        characterBody.MovePosition(newPosition);
    }
}
