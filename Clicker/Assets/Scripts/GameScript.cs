using System.Collections;
using System.Threading;
using UnityEngine;
using System;
using Random = System.Random;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using GoogleMobileAds.Api;
using System.Collections.Generic;
using UnityEditor;


public class GameScript : MonoBehaviour
{
    public InterstitialAd ad;
    AdRequest request;
    private const string middlePages = "ca-app-pub-3940256099942544/8691691433";

    public RectTransform sizeRect;
    public GameObject peopleField;  
    public List<GameObject> persons;
    public List<Sprite> sprites;

    public Text BoostLabels;
    public Text scoreText;
    public Text pointsPerClick;
    public Text pointsPerSecond;

    int boostIndex = 0;
    bool loading;

    public static Random rnd = new Random();

    public Button[] boostBttns;
    public Button[] shopBttns;

    public double[] boosts;
    public int[] boostCosts;
    public float[] boostsTimer;
    public float[] cooldownTimer;

    private Save saves = new Save();
    public int[] ups;
    private int bonusCounter = 0;

    private double clickBoost = 1;


    int language = 0; //0 - russian     1 - english

    public Text[] menuBarButtonsText;

    [Header("Магазин")]
    //public int emps;
    public double[] costs;
    public double[] bonuses;
    public Text[] costLabels;


    bool canBuyBoost = true;

    private double score = 0;
    public GameObject shopPanel;
    public GameObject boostPanel;
    private double bonus = 1;


    public void showhideShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    public void showhideBoosts()
    {
        boostPanel.SetActive(!boostPanel.activeSelf);
    }

    public void buyBoost()
    {
        //if (score >= boostCosts[boostIndex])
        //{
        score -= boostCosts[boostIndex];
        if (!loading) bonusCounter++;
        boostBttns[boostIndex].interactable = true;
        boostIndex++;
        if (boostIndex < boostBttns.Length)
        {
            BoostLabels.text = "Кричалка" + " X" + boosts[boostIndex] + " на " + boostsTimer[boostIndex] + " секунд\n" + boostCosts[boostIndex];
        }
        else
        {
            boostIndex--;
            BoostLabels.text = "Куплено";
            canBuyBoost = false;
            shopBttns[3].interactable = false;
        }
        //}
    }

    public void hideAllpanels()
    {
        boostPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void addBounus(int index)
    {
        //if (score >= costs[index])
        //{
        bonus += bonuses[index];
        if (!loading) { ups[index]++; }
        score -= costs[index];
        makeNewPerson(index);
        costs[index] *= 1.4;
        bonuses[index] *= 1.1;
        costLabels[index].text = "Улучшение +" + Math.Round(bonuses[index], 2) + "\n" + Math.Round(costs[index], 2);
        //}     
    }

    public void hire(int index)
    {
        Debug.Log("До " + bonuses[index]++);
        bonuses[index]++;
        Debug.Log("После " + bonuses[index]++);
        score -= costs[index];
        if (!loading) ups[ups.Length - 1]++;
        costs[index] *= 1.8;
        costLabels[index].text = "Улучшение +1/сек\n" + Math.Round(costs[index], 2);
    }

    IEnumerator pointsPerSec()
    {
        while (true)
        {
            score += bonuses[2];
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator bonusTimer(int index)
    {
        boostBttns[index].interactable = false;

        clickBoost *= boosts[index];
        yield return new WaitForSeconds(boostsTimer[index]);
        clickBoost /= boosts[index];

        yield return new WaitForSeconds(cooldownTimer[index]);
        boostBttns[index].interactable = true;
    }
    IEnumerator checkCosts()
    {
        while (true)
        {
            for (int i = 0; i < costs.Length; i++)
            {
                if (score >= costs[i])
                {
                    shopBttns[i].interactable = true;
                }
                else
                {
                    shopBttns[i].interactable = false;
                }
            }
            if (score >= boostCosts[boostIndex] && canBuyBoost)
            {
                shopBttns[shopBttns.Length - 1].interactable = true;
            }
            else
            {
                shopBttns[shopBttns.Length - 1].interactable = false;
            }
            yield return new WaitForSeconds(0);
        }
    }

    private void SortChildrenByName()
    {
        GameObject obj = peopleField;
        List<Transform> children = new List<Transform>();
        for (int i = obj.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = obj.transform.GetChild(i);
            children.Add(child);
        }
        children.Sort((Transform t1, Transform t2) => { return int.Parse(t2.name).CompareTo(int.Parse(t1.name)); });
        for (int i = 0; i < children.Count; ++i)
        {
            //Undo.SetTransformParent(children[i], children[i].parent, "Sort Children");
            children[i].SetSiblingIndex(i);
        }
    }


    public void makeNewPerson(int index)
    {
        for (int i = (int)bonuses[index]; i > 0; i--)
        {

            int x = rnd.Next(-(int)sizeRect.rect.width / 2, (int)sizeRect.rect.width / 2);
            int y = rnd.Next(-(int)sizeRect.rect.height / 2, (int)sizeRect.rect.height / 2);




            var go = new GameObject(y.ToString(), typeof(RectTransform));
            var image = go.AddComponent<Image>();
            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
            go.transform.SetParent(peopleField.transform);
            //renderer.sprite = sprites[rnd.Next(sprites.Count)];
            image.sprite = sprites[rnd.Next(sprites.Count)];
            go.transform.localPosition = new Vector3(x, y, 100);
            go.transform.localScale = new Vector3(1, 1, 1);
            persons.Add(go);
        }
        if (!loading) SortChildrenByName();
    }

    public void boostActivate(int index)
    {
        StartCoroutine(bonusTimer(index));
    }
    public void backToMenu()
    {
        Application.LoadLevel("Menu");
    }
    public void onClick()
    {
        score += bonus * clickBoost;
    }

    private void save()
    {
        saves.score = score;
        saves.bonusCounter = bonusCounter;
        saves.ups = ups;
        saves.quitTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        Debug.Log("OnQuit " + saves.quitTime);
        PlayerPrefs.SetString("SAVES", JsonUtility.ToJson(saves));
    }
    private void load()
    {
        loading = true;

        if (PlayerPrefs.HasKey("SAVES"))
        {
            saves = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SAVES"));
            ups = saves.ups;
            bonusCounter = saves.bonusCounter;


            int counter = 0;

            for (int i = 0; i < ups.Length; i++)
            {
                counter = ups[i];
                while (counter != 0)
                {
                    addBounus(i);
                    counter--;
                }
            }
            counter = ups[ups.Length - 1];
            while (counter != 0)
            {
                hire(ups.Length - 1);
                counter--;
            }
            counter = bonusCounter;
            while (counter != 0)
            {
                buyBoost();
                counter--;
            }
        }
        score = saves.score + (ups[ups.Length - 1] * (int)(DateTime.Now - DateTime.
            ParseExact(saves.quitTime, "MM/dd/yyyy HH:mm:ss", null)).TotalSeconds);
        SortChildrenByName();
        loading = false;
    }

    private void Awake()
    {  
        sizeRect = peopleField.GetComponent<RectTransform>();     
        ups = new int[shopBttns.Length - 1];      
    }
    private void Start()
    {
        load();
        StartCoroutine(pointsPerSec());
        StartCoroutine(checkCosts());
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                save();
                backToMenu();
            }
        }
        scoreText.text = Math.Round(score, 2) + "";
        pointsPerClick.text = "За клик " + Math.Round(bonus, 2) * clickBoost;
        pointsPerSecond.text = "В секунду " + Math.Round(bonuses[2], 2);
    }
    public void OnAdLoaded(object sender, System.EventArgs args)
    {
        ad.Show();
    }
    private void OnApplicationQuit()
    {
        save();
    }
    private void OnAppliacationPause(bool pause)
    {
        if (pause)
        {
            save();
        }
    }

}

[Serializable]
public class Save
{
    public double score;
    public int[] ups;
    public int bonusCounter;
    public string quitTime;
    // public DateTime quitTime;
}
