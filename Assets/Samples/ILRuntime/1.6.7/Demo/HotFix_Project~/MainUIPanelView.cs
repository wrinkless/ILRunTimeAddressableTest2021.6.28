using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix_Project.UI
{
    class MainUIPanelView:HotFixSingleton<MainUIPanelView>
    {
        public Button showButton;
        public  void InitUI()
        {
           //base.InitUI();
            Debug.Log("开始MainUIPanel的初始化");
            showButton= ResMgr.Instance.GetTarget<Button>("ShowButton");
            showButton.onClick.AddListener(OnShowButton);


            AllUIModel.Instance.MainUIPanel.SetActive(true);
        }
        /// <summary>
        /// 显示按钮的事件
        /// </summary>
        private void OnShowButton()
        {
            Debug.Log("按下了显示按键");
            AllUIModel.Instance.ContentUIPanel.SetActive(true);
            AllUIModel.Instance.MainUIPanel.SetActive(false);
        }
    }
}
