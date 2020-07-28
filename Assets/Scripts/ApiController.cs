using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class ApiController : MonoBehaviour
{
    public RawImage pokeImage;

    public Button GO;

    public Text[] texts;

    public readonly string BasePokeLink = "https://pokeapi.co/api/v2/";


    void Start()
    {
        pokeImage.texture = Texture2D.blackTexture;
        foreach (var item in texts)
        {
            item.text = "";
        }
    }

    public void btn_GO()
    {
        int randomPokemonIndex = UnityEngine.Random.Range(1, 808);

        texts[0].text = "Loadiing...";
        texts[1].text = randomPokemonIndex.ToString();
        texts[2].text = "";
        texts[3].text = "";
        StartCoroutine(GetPokemonAtIndex(randomPokemonIndex));
    }

    IEnumerator GetPokemonAtIndex(int randomPokemonIndex)
    {
        string pokemonURL = BasePokeLink + "pokemon/" + randomPokemonIndex.ToString();
        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);
        yield return pokeInfoRequest.SendWebRequest();

        if (pokeInfoRequest.isNetworkError || pokeInfoRequest.isHttpError)
        {
            Debug.Log(pokeInfoRequest.error);
            yield break;        
        }

        JSONNode pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text);
        string pokeName = pokeInfo["name"];
        string pokeSpriteUrl = pokeInfo["sprites"]["front_default"];

        JSONNode pokeTypes = pokeInfo["types"];
        string[] poketypeNames = new string[pokeTypes.Count];

        for (int i = 0, j  = pokeTypes.Count-1; i<pokeTypes.Count; i ++, j --)
        {
            poketypeNames[j] = pokeTypes[i]["type"]["name"];
        }

        UnityWebRequest pokemonSpriteRequest = UnityWebRequestTexture.GetTexture(pokeSpriteUrl);

        yield return pokemonSpriteRequest.SendWebRequest();

        if (pokeInfoRequest.isNetworkError || pokeInfoRequest.isHttpError)
        {
            Debug.Log(pokeInfoRequest.error);
            yield break;
        }

        pokeImage.texture = DownloadHandlerTexture.GetContent(pokemonSpriteRequest);
        pokeImage.texture.filterMode = FilterMode.Point;

        texts[0].text = pokeName;

        //texts[2].text = poketypeNames[0];

        for (int i = 0; i < poketypeNames.Length; i++)
        {
            texts[i+2].text = poketypeNames[i];
        }
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
