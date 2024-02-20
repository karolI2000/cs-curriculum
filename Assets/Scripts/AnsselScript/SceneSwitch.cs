using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField]
    int scene;

    static Vector3 atSceneZeroExit = new Vector3(6.5f, -2.46f, 0f);
    static Vector3 atSceneOneExit = new Vector3(-37.5f, -5.75f, 0f);

    static int sceneSwitchedFrom = -1;
    static RuntimeAnimatorController playerAnimator;
    int currentScene;
    [SerializeField] 
    GameObject player;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.FindWithTag("Player").transform.parent.gameObject;


        if (sceneSwitchedFrom > -1)
        {
            player.GetComponentInChildren<Animator>().runtimeAnimatorController = playerAnimator;
        }

        if (sceneSwitchedFrom == 1 && currentScene == 0)
        {
            player.transform.position = atSceneZeroExit;
            player.GetComponentInChildren<Animator>().SetInteger("WalkDir", 1);
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

        if (sceneSwitchedFrom == 0 && currentScene == 1)
        {
            player.GetComponentInChildren<Animator>().SetInteger("WalkDir", 2);
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

        if (sceneSwitchedFrom == 2 && currentScene == 1)
        {
            player.transform.position = atSceneOneExit;
            player.GetComponentInChildren<Animator>().SetInteger("WalkDir", 2);
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

        if (sceneSwitchedFrom == 1 && currentScene == 2)
        {
            player.GetComponentInChildren<Animator>().SetInteger("WalkDir", 1);
            player.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit something");
        print(collision.gameObject.name);
        if (collision.gameObject.transform.GetChild(0).gameObject.CompareTag("Player"))
        {
            print("hit the player");
            sceneSwitchedFrom = currentScene;
            playerAnimator = player.GetComponentInChildren<Animator>().runtimeAnimatorController;
            SceneManager.LoadScene(scene);
        }
    }
}
