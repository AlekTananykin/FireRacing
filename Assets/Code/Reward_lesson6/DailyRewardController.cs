using Assets.Code;
using Assets.Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class DailyRewardController: BaseController
{
    private DailyRewardView _dailyRewardView;
    private List<RewardSlotView> _slots;

    private bool _isGetReward;

    private CurrencyController _currencyController;
    private ProfilePlayer _playerProfile;

    public DailyRewardController(Transform uiPlace, ProfilePlayer playerProfile,
        DailyRewardView generateLevelView,
        CurrencyView currencyView)
    {
        _playerProfile = playerProfile;

        _dailyRewardView = Object.Instantiate(generateLevelView, uiPlace);
        AddGameObject(_dailyRewardView.gameObject);

        _currencyController = new CurrencyController(uiPlace, currencyView);
        AddController(_currencyController);
        
    }

    public void RefreshView()
    {
        InitSlots();

        _dailyRewardView.StartCoroutine(RewardsStateUpdater());

        RefreshUi();
        SubscribeButtons();
    }

    private void InitSlots()
    {
        _slots = new List<RewardSlotView>();

        for (var i = 0; i < _dailyRewardView.Rewards.Count; i++)
        {
            var instanceSlot = GameObject.Instantiate(_dailyRewardView.ContainerSlotRewardView,
                _dailyRewardView.MountRootSlotsReward, false);

            _slots.Add(instanceSlot);
        }
    }

    private IEnumerator RewardsStateUpdater()
    {
        while (true)
        {
            RefreshRewardsState();
            yield return new WaitForSeconds(1);
        }
    }

    private void RefreshRewardsState()
    {
        _isGetReward = true;

        if (_dailyRewardView.TimeGetReward.HasValue)
        {
            var timeSpan = DateTime.UtcNow - _dailyRewardView.TimeGetReward.Value;
            _dailyRewardView.Progress.Indicator = 
                1.0f - timeSpan.Seconds / _dailyRewardView.TimeDeadline;

            if (timeSpan.Seconds > _dailyRewardView.TimeDeadline)
            {
                _dailyRewardView.TimeGetReward = null;
                _dailyRewardView.CurrentSlotInActive = 0;
            }
            else if (timeSpan.Seconds < _dailyRewardView.TimeCooldown)
            {
                _isGetReward = false;
            }
        }

        RefreshUi();
    }

    private void RefreshUi()
    {
        _dailyRewardView.GetRewardButton.interactable = _isGetReward;

        if (_isGetReward)
        {
            _dailyRewardView.TimerNewReward.text = "The reward is received today";
        }
        else
        {
            if (_dailyRewardView.TimeGetReward != null)
            {
                var nextClaimTime = 
                    _dailyRewardView.TimeGetReward.Value.AddSeconds(_dailyRewardView.TimeCooldown);
                var currentClaimCooldown = 
                    nextClaimTime - DateTime.UtcNow;
                var timeGetReward = 
                    $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:" +
                    $"{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                _dailyRewardView.TimerNewReward.text = $"Time to get the next reward: {timeGetReward}";
            }
        }

        for (var i = 0; i < _slots.Count; i++)
            _slots[i].SetData(_dailyRewardView.Rewards[i], i + 1, i == _dailyRewardView.CurrentSlotInActive);
    }

    private void SubscribeButtons()
    {
        _dailyRewardView.GetRewardButton.onClick.AddListener(ClaimReward);
        _dailyRewardView.ResetButton.onClick.AddListener(ResetTimer);
        _dailyRewardView.CloseButton.onClick.AddListener(Close);
    }

    private void ClaimReward()
    {
        if (!_isGetReward)
            return;

        var reward = _dailyRewardView.Rewards[_dailyRewardView.CurrentSlotInActive];

        switch (reward.RewardType)
        {
            case RewardType.Wood:
                CurrencyView.Instance.AddWood(reward.CountCurrency);
                break;
            case RewardType.Diamond:
                CurrencyView.Instance.AddDiamonds(reward.CountCurrency);
                break;
        }

        _dailyRewardView.TimeGetReward = DateTime.UtcNow;
        _dailyRewardView.CurrentSlotInActive = 
            (_dailyRewardView.CurrentSlotInActive + 1) % _dailyRewardView.Rewards.Count;

        RefreshRewardsState();
    }

    private void ResetTimer()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Close()
    {
        _currencyController?.Dispose();
        _playerProfile.CurrentState.Value = GameState.Start;
    }

    protected override void OnDispose()
    {
        _dailyRewardView.GetRewardButton.onClick.RemoveAllListeners();
        _dailyRewardView.ResetButton.onClick.RemoveAllListeners();
        _dailyRewardView.CloseButton.onClick.RemoveAllListeners();
    }
}
