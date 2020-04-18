using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMission : MonoBehaviour
{
    private enum missions{Water, Food, Respirator, Pills};
    private missions mission;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 4;
        mission = (missions)Random.Range(0, 3);
        Debug.Log(mission);
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            Debug.Log("You Win!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (mission)
        {
            case missions.Water:
                if (collision.gameObject.name == "Water")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    count--;
                }
                break;
            case missions.Food:
                if (collision.gameObject.name == "Food")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    count--;
                }
                break;
            case missions.Respirator:
                if (collision.gameObject.name == "Respirator")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    count--;
                }
                break;
            case missions.Pills:
                if (collision.gameObject.name == "Pills")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    count--;
                }
                break;
        }
        Debug.Log(mission);
    }
}
