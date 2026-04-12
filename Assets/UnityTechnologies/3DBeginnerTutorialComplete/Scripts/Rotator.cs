using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float baseAngle;
    private float alpha = 0.0f;
    private float speed = 0.1f;

    void Start()
    {
        baseAngle = transform.eulerAngles.y;
    }

    void FixedUpdate()
    {
        alpha = Mathf.PingPong(Time.time * speed, 1.0f);

        float currentOffset = Mathf.Lerp(-45f, 45f, alpha);

        transform.eulerAngles = new Vector3(0, baseAngle + currentOffset, 0);
    }
}
