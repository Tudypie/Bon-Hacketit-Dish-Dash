using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodStorage : MonoBehaviour
{
    public string foodItemsInStorage;

    [SerializeField] private TMP_Text collectedFoodText;

    private void Update()
    {
        collectedFoodText.text = foodItemsInStorage;
    }

    public void AddFoodItem(FoodItem foodItem)
    {
        foodItemsInStorage += foodItem.foodName + ", ";
    }

}
