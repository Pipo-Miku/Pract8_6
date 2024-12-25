using System.Diagnostics.CodeAnalysis;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TeamRunScript : MonoBehaviour
{
    public Transform[] Runners;
    public Transform Child;
    public float Speed;
    private Vector3 target;
    private float passDistance;
    private int currentRunner, targetCount; //Бегающий сейчас

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        targetCount = 1;
        target = Runners[targetCount].position;
    }

    // Update is called once per frame
    void Update()
    {
        Runners[currentRunner].transform.LookAt(target);
        Runners[currentRunner].position = Vector3.MoveTowards(Runners[currentRunner].transform.position, target, Time.deltaTime * Speed);
        passDistance = Vector3.Distance(Runners[currentRunner].position, target);

        if (passDistance <= 0f)
        {
            Child.SetParent(Runners[targetCount]);
            currentRunner++;
            targetCount++;
            if (currentRunner < Runners.Length - 1) // Выполняют все кроме последнего
            {
                target = Runners[targetCount].position;
            }
            else if (currentRunner == Runners.Length - 1) // Выполняет только последний
            {
                targetCount = 0;
                target = Runners[targetCount].position;
            }
            else    //Начало итерации
            {
                currentRunner = 0;
                target = Runners[targetCount].position;
            }
        }
    }
}
