using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkyboxManager : MonoBehaviour
{
    [SerializeField] private List<AssetReference> _skyboxMaterials;

    private AsyncOperationHandle _operationHandle;

    public void SetSkybox(int skyboxIndex)
    {
        StartCoroutine(SetSkyboxInternal(skyboxIndex));
    }

    private IEnumerator SetSkyboxInternal(int skyboxIndex)
    {
        if (_operationHandle.IsValid())
        {
            Addressables.Release(_operationHandle);
        }

        AssetReference skyboxMaterialReference = _skyboxMaterials[skyboxIndex];
        _operationHandle = skyboxMaterialReference.LoadAssetAsync<Material>();
        yield return _operationHandle;
        RenderSettings.skybox = (Material) _operationHandle.Result;
    }
}
