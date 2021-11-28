using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject basketPrefab;
    public GameObject heartPrefab;
    public int numHearts = 3;
    public float basketsBottomY = -14f;
    private float heartY = 12f;
    private float heartX = -25f;
    private float heartSpacingY = 3f;
    public List<GameObject> heartList;


    // Start is called before the first frame update
    void Start()
    {
        heartList = new List<GameObject>();

        if (SceneManager.GetActiveScene().name == "_Scene_0")
        {
            for (int i = 0; i < numHearts; i++)
            {
                GameObject tHeartGO = Instantiate<GameObject>(heartPrefab);
                Vector3 pos = Vector3.zero;
                pos.x = heartX + (heartSpacingY * i);
                pos.y = heartY;
                tHeartGO.transform.position = pos;
                heartList.Add(tHeartGO);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed()
    {
        // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach( GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Create an int called basketIndex
        // Assign it to the last element in the basketList collection
        int heartIndex = heartList.Count-1;
        GameObject tBasketGO = heartList[heartIndex];

        // Remove the Basket from the list and destroy the GameObject
        heartList.RemoveAt(heartIndex);
        Destroy(tBasketGO);

        // If there are no Baskets left, restart the game
        if (heartList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
