﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyNotifications : MonoBehaviour
{
    public static Texture texture;
    public static float timer = 0.0f;
    private static bool callNotification = false;
    private static string message;
    public static GUIStyle textStyle;

    public static Vector2 notificationSize;
    public static Vector2 startingPosition;
    public static Vector2 wantedPosition;
    public static Vector2 currentPos;
    private static Vector3 velocity3;
    public static AudioSource audioSource;

    private static List<string> listaNotifikacija = new List<string>();
    private static List<float> listaTimera = new List<float>();
    public Texture notificationTexture;
    public GUIStyle myStyle;
    public Vector2 startinPos, endPos, size;
    public AudioSource ourSound;

    void Awake()
    {
        audioSource = ourSound;
        startingPosition = startinPos;
        wantedPosition = endPos;
        notificationSize = size;
        currentPos = startingPosition;
        texture = notificationTexture;
        textStyle = myStyle;
    }

    void OnGUI()
    {
        if (callNotification)
        {
            callNotification = pushNotification(listaNotifikacija[0], listaTimera[0]);
        }
    }

    private static bool pushNotification(string _message, float _duration)
    {
        if (timer <= 0)
        {
            timer = _duration;
            audioSource.Play();
        }
        else
        {
            if (timer < 1)
                currentPos = Vector3.SmoothDamp(currentPos, startingPosition, ref velocity3, 0.35f);
            else
                currentPos = Vector3.SmoothDamp(currentPos, wantedPosition, ref velocity3, 0.35f);

            GUI.DrawTexture(new Rect(currentPos.x, currentPos.y, notificationSize.x, notificationSize.y), texture);
            GUI.Box(new Rect(currentPos.x, currentPos.y, notificationSize.x, notificationSize.y), _message.ToString(),
                textStyle);

            timer -= 0.5f * Time.deltaTime;
            if (timer <= 0)
            {
                listaNotifikacija.RemoveAt(0);
                listaTimera.RemoveAt(0);
                if (listaNotifikacija.Count == 0)
                {
                    //print ("ne zovem");
                    return false;
                }
                else
                {
                    //print("zovem ponovno");
                    CallAgain();
                }
            }

            return true;
        }

        return true;
    }

    public static void CallNotification(string _message, float _duration)
    {
        listaNotifikacija.Add(_message);
        listaTimera.Add(_duration);

        if (callNotification == false)
            callNotification = pushNotification(listaNotifikacija[0], listaTimera[0]);
    }

    private static void CallAgain()
    {
        if (listaNotifikacija.Count != 0)
        {
            callNotification = pushNotification(listaNotifikacija[0], listaTimera[0]);
        }
    }
}