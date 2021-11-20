using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    static string scorePath = Application.persistentDataPath + "/score.fun";
    static string shopItemPath = Application.persistentDataPath + "/shop_";

    public static void SaveScore()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(scorePath, FileMode.Create);

        ScoreData data = new ScoreData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        if (File.Exists(scorePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(scorePath, FileMode.Open);
            print(scorePath);
            ScoreData data = formatter.Deserialize(stream) as ScoreData;

            stream.Close();

            return data;
        }
        else
        {
            print("There is no saved data for " + scorePath);
            return null;
        }
    }




    public static void SaveShopItem(ShopItem item)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(shopItemPath + item.name + ".fun", FileMode.Create);
        
        ShopItemData data = new ShopItemData(item);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static ShopItemData LoadShopItem(string itemName)
    {
        if (File.Exists(shopItemPath + itemName + ".fun"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(shopItemPath + itemName + ".fun", FileMode.Open);

            ShopItemData data = formatter.Deserialize(stream) as ShopItemData;

            stream.Close();

            return data;
        }
        else
        {
            print("There is no saved data for " + shopItemPath + itemName + ".fun");
            return null;
        }
    }


}
