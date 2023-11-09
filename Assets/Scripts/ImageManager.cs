using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private AssetReference _sprite;
    [SerializeField] private Image _image;

    #region CoroutineType
    /*
    private IEnumerator Start()
    {
        //указан заранее и не требуется приведение типа дальше
        AsyncOperationHandle<Sprite> handle = _sprite.LoadAssetAsync<Sprite>(); 
        
        yield return handle;
        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            //спрайт загружен
            _image.sprite = sprite;
            //очищение ресурса
            Addressables.Release(handle);
        }
    }
    */
    #endregion

    #region AsyncType 
    //Асинхронность лучше использовать ибо она выполнится в любом случае
    //даже если объект неактивен произойдёт подгрузка
    private async void Start()
    {
        AsyncOperationHandle<Sprite> handle = _sprite.LoadAssetAsync<Sprite>();
        await handle.Task;
        if(handle.Status == AsyncOperationStatus.Succeeded )
        {
            Sprite sprite = handle.Result;
            //файл загружен
            _image.sprite = sprite;
            //очистка
            Addressables.Release(handle);
        }
    }

    #endregion

}
