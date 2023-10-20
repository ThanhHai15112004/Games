using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject dustCloud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
        }
    }
}
