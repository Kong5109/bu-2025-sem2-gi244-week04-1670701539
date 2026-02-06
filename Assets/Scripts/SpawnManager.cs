using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] dogPrefabs;

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(-10, 10);
        int index = Random.Range(0, dogPrefabs.Length);

        if (dogPrefabs[index] != null)
        {
            Instantiate(dogPrefabs[index], new Vector3(x, 0, 20), Quaternion.Euler(0, 180, 0));
        }
        else
        {
            Debug.LogWarning($"dog Prefab {index} is null");
        }
    }
}
