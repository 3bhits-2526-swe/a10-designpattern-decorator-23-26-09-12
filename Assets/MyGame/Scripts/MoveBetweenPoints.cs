using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachDistance = 0.05f;

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentTarget = pointB;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();

        if (Vector3.Distance(transform.position, currentTarget.position) <= reachDistance)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );
    }
}