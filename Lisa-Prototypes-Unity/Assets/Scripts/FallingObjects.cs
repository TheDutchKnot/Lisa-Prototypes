using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] GameObject [] FilesPrefab;
    [SerializeField] float secondSpawn = 0.5f; 
    [SerializeField] float minTras;
    [SerializeField] float maxTras; 



    void Start(){
    {
       StartCoroutine(FileSpawn());  
    }
    }

IEnumerator FileSpawn()
{
    while(true)
    {
        var wanted = Random.Range(minTras, maxTras);
        var position = new Vector3(wanted, transform.position.y);
        GameObject gameObject = Instantiate(FilesPrefab[Random.Range(0, FilesPrefab.Length)], position, Quaternion.identity);
        
      
        yield return new WaitForSeconds(secondSpawn);
        
        MoveSystem moveScript = gameObject.GetComponent<MoveSystem>();
        if (!moveScript.IsCorrectlyPlaced)  
        {
            Destroy(gameObject, 5f);  
        }
    }
}
}