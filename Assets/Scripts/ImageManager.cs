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
        //������ ������� � �� ��������� ���������� ���� ������
        AsyncOperationHandle<Sprite> handle = _sprite.LoadAssetAsync<Sprite>(); 
        
        yield return handle;
        if(handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            //������ ��������
            _image.sprite = sprite;
            //�������� �������
            Addressables.Release(handle);
        }
    }
    */
    #endregion

    #region AsyncType 
    //������������� ����� ������������ ��� ��� ���������� � ����� ������
    //���� ���� ������ ��������� ��������� ���������
    private async void Start()
    {
        AsyncOperationHandle<Sprite> handle = _sprite.LoadAssetAsync<Sprite>();
        await handle.Task;
        if(handle.Status == AsyncOperationStatus.Succeeded )
        {
            Sprite sprite = handle.Result;
            //���� ��������
            _image.sprite = sprite;
            //�������
            Addressables.Release(handle);
        }
    }

    #endregion

}
