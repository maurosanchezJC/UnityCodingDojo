using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSpawns = 10;

    [SerializeField] private List<Color> availableColors = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < initialSpawns; i++)
        {
            yield return null;
            CreateInstance();
        }
    }

    private void CreateInstance()
    {
        float newY = UnityEngine.Random.Range(transform.position.y - .2f, transform.position.y + .2f);
        float newX = UnityEngine.Random.Range(transform.position.x - .2f, transform.position.x + .2f);
        Vector2 newPos = new Vector2(newX, newY);
        GameObject obj = Instantiate(prefab, gameObject.transform);
        obj.transform.position = newPos;
        obj.GetComponent<SpriteRenderer>().color = availableColors[UnityEngine.Random.Range(0, availableColors.Count)];
    }

    private void DeleteInstance()
    {
        if (transform.childCount == 0)
        {
            return;
        }
        
        Destroy(transform.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CreateInstance();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeleteInstance();
        }
    }
}
