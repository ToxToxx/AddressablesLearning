using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PrefabLoadManager : MonoBehaviour
{
    [SerializeField] private AssetReference _prefab;

    private async void Start()
    {
        AsyncOperationHandle<GameObject> handle = _prefab.LoadAssetAsync<GameObject>();
        await handle.Task;
        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject gameObjectPrefab = handle.Result;
            Instantiate(gameObjectPrefab, new Vector3(0, 3, 0), Quaternion.identity);
            Addressables.Release(handle);
        }
    }
}
