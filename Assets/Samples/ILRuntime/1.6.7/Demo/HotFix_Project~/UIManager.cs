using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix_Project
{
    class UIManager:HotFixSingleton<UIManager>
    {
        /// <summary>
        /// 展示ui
        /// </summary>
        /// <param name="names">aa包的名字："MainUIPanel"</param>
        public  void LoadUI(string names)
        {
            Debug.Log("开始实例化"+names);
            ResMgr.Instance.InstantiateOfAddressables(names);
        }
        /// <summary>
        /// 销毁ui
        /// </summary>
        /// <param name="url">路径</param>
        public void DestroyUI(string url)
        {

        }
    }
}
