using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] GameObject[] FilesPrefab;  
    [SerializeField] float minTras; 
    [SerializeField] float maxTras;  
    [SerializeField] float fallSpeed = 2f;  
    [SerializeField] float secondSpawn = 0.5f;

    private List<GameObject> fallingObjects = new List<GameObject>();  

    void Start()
    {
        StartCoroutine(FileSpawn());
    }

    void Update()
    {
       
        for (int i = fallingObjects.Count - 1; i >= 0; i--)
        {
            if (fallingObjects[i] != null)
            {
               
                fallingObjects[i].transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            
                if (fallingObjects[i].transform.position.y < -10f)
                {
                    Destroy(fallingObjects[i]);
                    fallingObjects.RemoveAt(i);
                }
            }
        }
    }

    IEnumerator FileSpawn()
    {
        while (true)
        {
          
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y, 0f);

           
            GameObject newObject = Instantiate(FilesPrefab[Random.Range(0, FilesPrefab.Length)], position, Quaternion.identity);
            
           
            fallingObjects.Add(newObject);

        
            yield return new WaitForSeconds(secondSpawn);
        }
    }
}
