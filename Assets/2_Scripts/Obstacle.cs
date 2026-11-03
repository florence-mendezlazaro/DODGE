using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("ObstacleVariables")]
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}