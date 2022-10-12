using UnityEngine;

public class LocationController : MonoBehaviour
{
    [SerializeField]
    private GameObject BarierPrefab;

    [SerializeField]
    private GameObject FoodPrefab;

    private void Awake()
    {
        GenerateBariers();
        GenerateFood();
    }

    private void GenerateFood()
    {
        int foodCount = 60;
        for (int i = 1; i < foodCount; i++)
        {
            int minInclusive = -5;
            int maxExclusive = 5;
            int random = Random.Range(minInclusive, maxExclusive);

            float foodStep = 10f;
            float blockStep = 40f;
            if ((foodStep * i) % blockStep == 0)
            {
                continue;
            }
            var food = Instantiate(FoodPrefab, gameObject.transform);
            food.transform.localPosition = new Vector3(1f * random, 0f, 10f * i);
        }
    }

    private void GenerateBariers()
    {
        int row = 15;
        int start = -4;
        int end = 5;

        for (int i = 1; i < row; i++)
        {
            for (int j = start; j < end; j++)
            {
                var barier = Instantiate(BarierPrefab, gameObject.transform);

                barier.transform.localPosition = new Vector3(3.4f * j, 0f, 40f * i);
            }
        }
    }
}