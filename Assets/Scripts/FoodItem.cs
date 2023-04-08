using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour   
{   
    public string foodName;

    private FoodStorage foodStorage;

    void Start()
    {
        foodStorage = GameObject.FindObjectOfType<FoodStorage>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foodStorage.AddFoodItem(this);
            Destroy(gameObject);
        }
    }
}
