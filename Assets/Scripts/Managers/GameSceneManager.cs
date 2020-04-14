using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : Singleton<GameSceneManager> {

    public static Vector2 GetScreenBounds() {
        Camera mainCamera = Camera.main;
        Vector2 screenVector = new Vector2(Screen.width, Screen.height);
        return mainCamera.ScreenToWorldPoint(screenVector);
    }
}
