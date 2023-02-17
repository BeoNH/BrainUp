using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class Spawner : MonoBehaviour
{
    protected static Spawner instance;
    public static Spawner Instance { get => instance; }


    [SerializeField] protected GameObject prefabs;
    [SerializeField] protected float minTras;
    [SerializeField] protected float maxTras;
    protected TMP_Text healthText;

    private int countPrefab = 10;
    private int health = 0;


    void Awake()
    {
        instance = this;
    }
    protected void Update()
    {
        //callSpaw();
    }
    
    public void callSpaw()
    {
        GameManager.Instance.UpdateGameState(GameState.Playing);
        for (int i = 0; i < countPrefab; i++)
        {
            //await Task.Delay(2000);
            Spawn();
            countPrefab--;
            health += 1;
            updateTextBox();
            Debug.Log(i);
        }
    }

    protected virtual void Spawn()
    {
        var wanted = Random.Range(minTras, maxTras);
        var pos = new Vector3(wanted, wanted);

        GameObject gameObj = Instantiate(prefabs, pos, Quaternion.identity);

        healthText = gameObj.GetComponentInChildren<TMP_Text>();

        //yield return new WaitForSeconds(5f);
    }

    protected virtual void updateTextBox()
    {
        healthText.text = health.ToString();
    }
}
