using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject _generationObject;

    [SerializeField] private GameObject _firstGenerationPoint;
    [SerializeField] private GameObject _secondGenerationPoint;
    [SerializeField] private GameObject _ThirdGenerationPoint;

    private float _secondCount;

    void Start()
    {
        _secondCount = 0;
    }

    void Update()
    {
        int second = Mathf.FloorToInt(Time.time);
        int necessaryNumberOfSeconds = 2;

        int firstPointIndex = 1;
        int secondPointIndex = 2;
        int thirdPointIndex = 3;

        int minimalPointNumber = 1;
        int maximalPointNumber = 4;

        if (second > _secondCount)
        {
            Debug.Log(second);
            _secondCount++;

            if (second % necessaryNumberOfSeconds == 0)
            {
                int index = Random.Range(minimalPointNumber, maximalPointNumber);

                if (index == firstPointIndex)
                {
                    GenerateEnemy(_firstGenerationPoint);
                }
                else if (index == secondPointIndex)
                {
                    GenerateEnemy(_secondGenerationPoint);
                }
                else if (index == thirdPointIndex)
                {
                    GenerateEnemy(_ThirdGenerationPoint);
                }
            }
        }
    }

    private void GenerateEnemy(GameObject gameObject)
    {
        GameObject enemy = Instantiate(_generationObject, gameObject.transform.position, Quaternion.identity);
        enemy.AddComponent<Move>();
    }
}
