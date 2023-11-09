using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private AssetReference _scene;
    [SerializeField] private Button _loadButton;

    private void Start()
    {
        _loadButton.onClick.AddListener(() =>
        {
            LoadSceneAddressable();
        }
        );
        
    }

    public void LoadSceneAddressable()
    {
        _scene.LoadSceneAsync();
    }
}
