using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteMission : MonoBehaviour
{
    public string Name;
    public Text Request;
    public float Rate;
    public Image Bar;
    public AudioClip Win;
    private enum missions{Water, Food, Respirator, Pills};
    private missions mission;
    private int count;
    private float health;
    private float size;
    private static int numFinished;
    private AudioSource source;
    private bool gotThisFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        count = 4;
        mission = (missions)Random.Range(0, 4);
        size = Bar.rectTransform.sizeDelta.x;
        Request.text = Name + " needs: " + mission;
        numFinished = 2;
        source = GetComponent<AudioSource>();
        Debug.Log(mission);
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            Request.text = "Done!!";
            Destroy(this);
            numFinished--;
            if (numFinished <= 0)
            {
                Cursor.visible = true;
                SceneManager.LoadScene("Win");
            }
            source.PlayOneShot(Win);
            Debug.Log("You Win!");
        }
        health -= Time.deltaTime * Rate;
        if (health <= 0)
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Lose");
            //Lose screen
        }
        Bar.rectTransform.sizeDelta = new Vector2(size * (health / 100), Bar.rectTransform.sizeDelta.y);
        gotThisFrame = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gotThisFrame)
        {
            return;
        }
        switch (mission)
        {
            case missions.Water:
                if (collision.gameObject.name == "Water")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    source.PlayOneShot(collision.gameObject.GetComponent<PickUp>().Clip);
                    count--;
                    health = 100;
                    Request.text = Name + " needs: " + mission;
                    gotThisFrame = true;
                }
                break;
            case missions.Food:
                if (collision.gameObject.name == "Food")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    source.PlayOneShot(collision.gameObject.GetComponent<PickUp>().Clip);
                    count--;
                    health = 100;
                    Request.text = Name + " needs: " + mission;
                    gotThisFrame = true;
                }
                break;
            case missions.Respirator:
                if (collision.gameObject.name == "Respirator")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    source.PlayOneShot(collision.gameObject.GetComponent<PickUp>().Clip);
                    count--;
                    health = 100;
                    Request.text = Name + " needs: " + mission;
                    gotThisFrame = true;
                }
                break;
            case missions.Pills:
                if (collision.gameObject.name == "Pills")
                {
                    mission = (missions)Random.Range(0, 3);
                    Destroy(collision.gameObject);
                    source.PlayOneShot(collision.gameObject.GetComponent<PickUp>().Clip);
                    count--;
                    health = 100;
                    Request.text = Name + " needs: " + mission;
                    gotThisFrame = true;
                }
                break;
        }
    }
}
