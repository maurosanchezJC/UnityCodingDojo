using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;

    public bool isWarping = false;
    public int warpId = -1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<PathListener>(out PathListener logger))
        {
            logger.ShowLog();
        }
    }
}
