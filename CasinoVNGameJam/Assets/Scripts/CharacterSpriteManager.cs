using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class CharacterSpriteManager : MonoBehaviour
{
    public GameObject characterCanvas;
    public Image characterImage;
    
    [YarnCommand("setCharacterSprite")]
    public void SetCharacterSprite(string spriteName)
    {
        // Find the character sprite by name
        Sprite characterSprite = Resources.Load<Sprite>("CharacterSprites/" + spriteName);
        Debug.Log("Loading character sprite: " + spriteName);
        Debug.Log("Loading from path: " + "CharacterSprites/" + spriteName);
        Debug.Log(characterSprite);
        
        if (characterSprite != null)
        {
            // Set the sprite on the character canvas
            characterImage.GetComponent<Image>().sprite = characterSprite;
            characterCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Character sprite not found: " + spriteName);
            characterCanvas.SetActive(false);
        }
    }

    [YarnCommand("hideCharacterSprite")]
    public void HideCharacterSprite()
    {
        // Hide the character canvas
        characterCanvas.SetActive(false);
    }
}
