using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplierr = 2f;

    private float maxPos = -19f;

    public GameObject[] background;

    private void Update()
    {

        foreach (var bg in background)
        {
            Vector3 vector3 = bg.transform.localPosition;
            vector3.x -= speed * Time.deltaTime * speedMultiplierr;

            speedMultiplierr += Time.deltaTime * 0.01f;
            
            bg.transform.localPosition = vector3;

            if (bg.transform.localPosition.x <= maxPos)
            {
                bg.transform.localPosition = new Vector3(47, 0, 0);
            }
        }
    }

}
