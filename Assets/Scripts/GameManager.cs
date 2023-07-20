using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject topRightBarrier;
    [SerializeField] private GameObject bottomLeftBarrier;
    [HideInInspector] public List<GameObject> blockInScene = new List<GameObject>();

    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject scoreUI;
    private int score;

    void Awake()
    {
        Time.timeScale = 0f;
        AlignBarriers();
    }

    public void ClickToStart(GameObject clickToStartUI)
    {
        Time.timeScale = 1f;
        clickToStartUI.SetActive(false);
    }
    void AlignBarriers()
    {
        Vector3 screenTopRight = new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane);
        Vector3 topRightPosition = Camera.main.ScreenToWorldPoint(screenTopRight);
        topRightBarrier.transform.position = topRightPosition;

        Vector3 screenBottomLeft = new Vector3(0, 0, Camera.main.nearClipPlane);
        Vector3 bottomLeftPosition = Camera.main.ScreenToWorldPoint(screenBottomLeft);
        bottomLeftBarrier.transform.position = bottomLeftPosition;

    }

    public void AddBlockToList(GameObject block)
    {
        blockInScene.Add(block);
    }
    public void RemoveBlockFromList(GameObject block)
    {
        blockInScene.Remove(block);
        score += 50;
        CheckBlocksInList();
    }

    void CheckBlocksInList()
    {
        if (blockInScene.Count == 0)
        {
            LevelComplete();
        }
    }

    public void LevelComplete()
    {
        endGameUI.SetActive(true);
        scoreUI.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();

        GameObject backgroundParent = GameObject.FindGameObjectWithTag("Background");
        for (int i = 0; i < backgroundParent.transform.childCount; i++)
        {
            GameObject child = backgroundParent.transform.GetChild(i).gameObject;
            child.GetComponent<SpriteRenderer>().sortingLayerName = "BackgroundFront";
        }
        Time.timeScale = 0f;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseGame()
    {

    }
    
}
