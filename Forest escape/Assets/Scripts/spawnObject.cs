using UnityEngine;

public class spawnObject : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float speed;

    private GameManager gm;

    private float timer;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        


        if (timer > 10)
        {
            Destroy(gameObject);
        }
        Rb.velocity = Vector2.left * (speed + gm.speedMultiplier);
    }
}
