using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CharactersController : MonoBehaviour
{
    public List<GameObject> characters;
    public GameObject characterPrefab;
    public List<Sprite> characterSprites;

    Random rnd = new Random();

    private void Awake()
    {
        if (characters == null)
        {
            characters = new List<GameObject>();
        }
    }

    private void Start()
    {
        
    }


    public void CreateCharacter(int num)
    {
        var spawnZone = MapController.instance.currentMap.spawnZone.gameObject;
        var rectTransform = spawnZone.gameObject.GetComponent<SpriteRenderer>();

        int width = (int)rectTransform.bounds.size.x;
        int height = (int)rectTransform.bounds.size.y;
        print(width + "/" + height);
        for (int i = 0; i < num; i++)
        {
            Vector3 rndPosition = new Vector3(rnd.Next(-width/2, width/2), rnd.Next(-height/2, height/2), 30);
            print(rndPosition);
            GameObject newCharacter = Instantiate(characterPrefab);
           
            newCharacter.transform.parent = spawnZone.transform;
            newCharacter.transform.localPosition = Vector3.zero;
            newCharacter.transform.position += rndPosition;
            

            characters.Add(newCharacter);
        }
    }



    private void FixedUpdate()
    {
        int delta = (int)GameManager.instance.GetPerClickValue() - characters.Count;
        
        if (delta > 0)
        {
            CreateCharacter(delta);
        }
    }
}
