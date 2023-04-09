using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodItem : MonoBehaviour   
{   
    public string foodName;

    private FoodStorage foodStorage;
    private AudioPlayer audioPlayer;

    void Start()
    {
        foodStorage = GameObject.FindObjectOfType<FoodStorage>();
        audioPlayer = GameObject.FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foodStorage.AddFoodItem(this);

            audioPlayer.PlaySound(audioPlayer.foodCollectedSound);

            Destroy(gameObject);
        }
    }
}
