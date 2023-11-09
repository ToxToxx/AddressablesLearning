using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class PrefabLoadManager : MonoBehaviour
{
    [SerializeField] private AssetReference _prefab;
     private AsyncOperationHandle<GameObject> _handle;

    #region AsyncType

    private async void Start()
    {
        _handle = _prefab.LoadAssetAsync<GameObject>();
        await _handle.Task;
        if(_handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject gameObjectPrefab = _handle.Result;
            Instantiate(gameObjectPrefab, new Vector3(0, 4, 0), Quaternion.identity);

            
        }
    }
    #endregion

    #region FastWayToLoad
    /*
    private void Start()
    {
        _prefab.InstantiateAsync();
    }*/
    #endregion

    private void OnDestroy()
    {
        //очистка
        Addressables.Release(_handle);
    }
}
