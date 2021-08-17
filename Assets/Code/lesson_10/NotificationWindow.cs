using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;

public class NotificationWindow : MonoBehaviour
{
    private const string AndroidNotifierId = "android_notifier_id";

    [SerializeField]
    private Button _buttonNotification;

    private void Start()
    {
        _buttonNotification.onClick.AddListener(CreateNotification);

    }

    private void OnDestroy()
    {
        _buttonNotification.onClick.RemoveAllListeners();
    }

    private void CreateNotification()
    {
#if UNITY_ANDROID
        var androidSettingsChannel = new AndroidNotificationChannel
        {
            Id = AndroidNotifierId,
            Name = "FireRacing Game Notifier",
            Importance = Importance.High,
            CanBypassDnd = true,
            CanShowBadge = true,
            Description = "Enter the game and get free log",
            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public,
        };
        AndroidNotificationCenter.RegisterNotificationChannel(
            androidSettingsChannel);

        var androidSettingsNotification = new AndroidNotification
        {
            Color = Color.white,
            RepeatInterval = TimeSpan.FromSeconds(5)
        };
        AndroidNotificationCenter.SendNotification(
            androidSettingsNotification, AndroidNotifierId);

#elif UNITY_IOS
        var iosSettingsNotification = new iOSNotification
        {
           Identifier = "android_notifier_id",
           Title = "Game Notifier",
           Subtitle = "Subtitle notifier",
           Body = "Enter the game and get free logs",
           Badge = 1,
           Data = DateTime.Now.ToString("dd/MM,yyyy"),
           ForegroundPresentationOption = PresentationOption.Alert,
           ShowInForeground = false
       };
      
       iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);

#endif
        Debug.Log("You are notified!");
    }

}
