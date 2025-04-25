using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 3f;
    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = movingRight ? 1 : -1;
        transform.Translate(Vector2.right * offset * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, startPos) >= patrolDistance)
            movingRight = !movingRight;
    }
}
