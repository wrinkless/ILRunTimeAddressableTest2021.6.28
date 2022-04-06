/*----------------游戏启动入口脚本-------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

/// <summary>
/// 加载方式
/// </summary>
public enum LoadingMode
{
    ByLocalDll,
    ByLocalAddressable
}
public class GameLunch : MonoSingleton<GameLunch>
{
    
    
    
    //public Transform father;
    [Tooltip("dll文件的加载方式")]
    public LoadingMode loadingMode=LoadingMode.ByLocalAddressable;
    public override void Awake()
    {
        base.Awake();
        Caching.ClearCache();
        //初始化游戏框架
        //资源管理
        gameObject.AddComponent<ResMgr>();
        gameObject.AddComponent<ILRuntimeWrapper>();
        //gameObject.AddComponent<MediaPlayer>();
        StartHotFix();
        //LoadAddressables();

    }
    /// <summary>
    /// 测试加载AA
    /// </summary>
    /// <returns></returns>
    public async Task LoadAddressables()
    {
       //GameObject target= await Addressables.LoadAssetAsync<GameObject>("Canvas").Task;
       // var target = await ResMgr.Instance.GetAssetCache<GameObject>("Canvas");
       // GameObject.Instantiate(target);
       Caching.ClearCache();
       // var canvas= Addressables.InstantiateAsync("Canvas");
       // await canvas.Task;
       // await Addressables.InstantiateAsync("MainUIPanel",canvas.Result.transform).Task;
    }
    /// <summary>
    /// 加载dll
    /// </summary>
    /// <returns></returns>
    public async Task StartHotFix()
    {
        
        //去服务器上下载最新的aa包资源

        //下载热更代码
        //string m_url=null;
        byte[] dll=new byte[]{};
        byte[] pdb = new byte[] {};
        if (loadingMode == LoadingMode.ByLocalDll)
        {
            //StartCoroutine(CheckHotUpdate(dll,pdb));
        }
        else if (loadingMode==LoadingMode.ByLocalAddressable)
        {
            TextAsset assetDll= await Addressables.LoadAssetAsync<TextAsset>("HotFix_Project_dll_res").Task;
            dll = assetDll.bytes;
            TextAsset assetPdb= await Addressables.LoadAssetAsync<TextAsset>("HotFix_Project_pdb_res").Task;
            pdb = assetPdb.bytes;
            ILRuntimeWrapper.Instance.LoadHotFixAssembly(dll,pdb);
            
            
            
            ILRuntimeWrapper.Instance.EnterGame();
        }
        // ILRuntimeWrapper.Instance.LoadHotFixAssembly(dll,pdb);
        // ILRuntimeWrapper.Instance.EnterGame();
    }

//     /// <summary>
//     /// 协程热更
//     /// </summary>
//     /// <returns></returns>
//     IEnumerator CheckHotUpdate(byte[] dll,byte[] pdb)
//     {
//
// #if UNITY_ANDROID
//        string m_url = "file:///" + Application.dataPath + "/ILRunTimeAndAddressable/AssetsPackage/HotFixDll" + "/HotFix_Project.dll";
// #else
//             //m_url = "file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll";
//             m_url = "file:///" + Application.dataPath + "/ILRunTimeAndAddressable/AssetsPackage/HotFixDll" + "/HotFix_Project.dll";
//             //m_url = "http://10.1.68.28/HotFix_Project_dll_res.bytes";
//             //m_url = "http://10.1.68.28/hotfixdlltobytes_assets_all_29a623f549f85c527ed4d75ba4a51295.bundle";
//
// #endif
//             UnityWebRequest unityWebRequest = UnityWebRequest.Get(m_url);
//             yield return unityWebRequest.SendWebRequest();
//
//             if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
//             {
//                 Debug.Log(unityWebRequest.error);
//             }
//             dll = unityWebRequest.downloadHandler.data;
//             unityWebRequest.Dispose();
//
//
//             //PDB文件是调试数据库，如需要在日志中显示报错的行号，则必须提供PDB文件，不过由于会额外耗用内存，正式发布时请将PDB去掉，下面LoadAssembly的时候pdb传null即可
// #if UNITY_ANDROID
//         m_url = "file:///" + Application.dataPath + "/ILRunTimeAndAddressable/AssetsPackage/HotFixDll" + "/HotFix_Project.pdb";
// #else
//             //m_url = "file:///" + Application.streamingAssetsPath + "/HotFix_Project.pdb";
//             m_url = "file:///" + Application.dataPath + "/ILRunTimeAndAddressable/AssetsPackage/HotFixDll" + "/HotFix_Project.pdb";
//             //m_url = "http://10.1.68.28/HotFix_Project_pdb_res.bytes";
//             //m_url = "http://10.1.68.28/ui_assets_all_c09ba3563585ecd2ecdd1eeab33de5f8.bundle";
// #endif
//
//
//             unityWebRequest = UnityWebRequest.Get(m_url);
//             yield return unityWebRequest.SendWebRequest();
//
//             if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
//             {
//                 Debug.Log(unityWebRequest.error);
//             }
//
//             pdb = unityWebRequest.downloadHandler.data;
//             unityWebRequest.Dispose();
//             ILRuntimeWrapper.Instance.LoadHotFixAssembly(dll,pdb);
//             ILRuntimeWrapper.Instance.EnterGame();
//         }
    
    }
