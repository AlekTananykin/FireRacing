public class LoadWindowView : AssetBundleViewBase
{
    private void Start()
    {
        LoadAssets();
    }

    private void LoadAssets()
    {
        StartCoroutine(DownloadAndSetAssetBundle());
    }
}
