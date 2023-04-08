using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStorage : MonoBehaviour
{
    public string foodItemsInStorage;

    public void AddFoodItem(FoodItem foodItem)
    {
        foodItemsInStorage += foodItem.foodName + ", ";
    }

}
