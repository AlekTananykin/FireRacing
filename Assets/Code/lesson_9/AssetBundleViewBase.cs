using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleViewBase : MonoBehaviour
{
    private const string _urlAssetBundleSprites = 
        "https://";
    private const string _urlAssetBundleAudio = 
        "https://";

    [SerializeField]
    private DataSpriteBundle[] _spriteBundles;

    [SerializeField]
    private DataAudioBundle[] _audioBundles;

    private AssetBundle _spriteAssetsBundle;
    private AssetBundle _audioAssetsBundle;


    protected IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpriteAssetBundle();
        yield return GetAudioAssetBundle();

        if (null == _spriteAssetsBundle ||
            null == _audioAssetsBundle)
        {
            Debug.LogError($"AssetBundle {_audioAssetsBundle} failed to load");
            yield break;
        }

        SetDownloadAssets();
        yield return null;
    }

    private void SetDownloadAssets()
    {
        foreach (var data in _spriteBundles)
        {
            data.Image.sprite = 
                _spriteAssetsBundle.LoadAsset<Sprite>(
                    data.NameAssetBundle);
        }

        foreach (var data in _audioBundles)
        {
            data.AudioSource.clip = _audioAssetsBundle.LoadAsset<AudioClip>(
                data.NameAssetBundle);
        }
    }

    private IEnumerator GetSpriteAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(
            _urlAssetBundleSprites);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _spriteAssetsBundle);
    }

    private IEnumerator GetAudioAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(
            _urlAssetBundleAudio);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _audioAssetsBundle);
    }

    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (null == request.error)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Complete");
        }
        else
        {
            Debug.Log(request.error);
        }
    }
}
