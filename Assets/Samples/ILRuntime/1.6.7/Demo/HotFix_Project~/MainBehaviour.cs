using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using HotFix_Project.UI;

namespace HotFix_Project
{
   public class MainBehaviour:HotFixSingleton<MainBehaviour>
    {
       
        public   void Awake()
        {
            Debug.Log("开始Awake");
            //声明委托
            ILRuntimeWrapper.Instance.TestActionDelegate  = FinishLoad;
            //HotFixEventDispatcher.GameEvent.DispatchEvent(1000);
            UIManager.Instance.LoadUI("MainUIPanel");
            UIManager.Instance.LoadUI("ContentUIPanel");
            //ResMgr.Instance.InstantiateOfAddressables("MainUIPanel");
            //ResMgr.Instance.InstantiateOfAddressables("ContentUIPanel");
        }
        /// <summary>
        /// 添加游戏逻辑
        /// </summary>
        public  void Start()
        {
            Debug.Log("开始Start");
           // HotFixEventDispatcher.GameEvent.DispatchEvent(1001);
        }
        public  void Update()
        {
           // HotFixEventDispatcher.GameEvent.DispatchEvent(1002);
        }
        public  void LateUpdate()
        {
            //Debug.Log("LateUpdate");

        }
        public  void FixedUpdate()
        {
           // Debug.Log("FixedUpdate");
        }
        public  void OnDestroy()
        {
            //HotFixEventDispatcher.GameEvent.DispatchEvent(1003);
        }
        /// <summary>
        /// 实例完prefab的回调
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="tartget"></param>
        public  void FinishLoad( string methodName,object target)
        {
            Debug.Log($"开始回调——————{target}");
            //HotFixEventDispatcher.GameEvent.DispatchEvent(2000);
            switch (methodName)
            {
                case "MainUIPanel":
                    AllUIModel.Instance.MainUIPanel = (GameObject)target;
                    MainUIPanelView.Instance.InitUI();
                    break;
                case "ContentUIPanel":
                    AllUIModel.Instance.ContentUIPanel = (GameObject)target;
                    ContentUIPanelView.Instance.InitUI();
                    break;
                case "睡觉":
                    ContentUIPanelView.Instance.texture1 = (Sprite)target;
                    break;
                case "1000":
                    ContentUIPanelView.Instance.texture2 = (Sprite)target;
                    break;
                default:
                    break;
            }
        }
    }
}
