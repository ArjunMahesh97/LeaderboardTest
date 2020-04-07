using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundleCreateRequest loadedAssetBundleCreateRequest;
    AssetBundle assetBundle;
    [SerializeField] string path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadAssetBundle(string bundleAddr)
    {
        //Application.streamingAssetsPath
        loadedAssetBundleCreateRequest = AssetBundle.LoadFromFileAsync(bundleAddr);
        assetBundle = loadedAssetBundleCreateRequest.assetBundle;
    }

    public GameObject GetObjectFromBundle(string assetName)
    {
        LoadAssetBundle(path);
        //Debug.Log(assetBundle);
        return (GameObject) assetBundle.LoadAsset<GameObject>(assetName);
    }
}
