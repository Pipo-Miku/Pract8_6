using UnityEngine;

public class RunnerScript : MonoBehaviour
{
    public Transform[] Points;
    private Vector3 target;
    public float Speed;
    private float distanse;
    private bool forward = true;
    private int currentPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = Points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        distanse = Vector3.Distance(target, transform.position);
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * Speed);

        if (forward)
        {
            if (distanse < 1f)
            {
                target = Points[currentPoint++].position;
                if (currentPoint == Points.Length)
                {
                    target = Points[currentPoint - 1].position;
                    forward = false;

                }
            }
        }
        if (!forward)
        {
            if (distanse < 1f)
            {
                target = Points[--currentPoint].position;
                if (currentPoint == 0)
                {
                    target = Points[currentPoint + 1].position;
                    forward = true;
                }
            }
        }
    }
}
