using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HotFix_Project.UI
{
    class ContentUIPanelView:HotFixSingleton<ContentUIPanelView>
    {
        /// <summary>
        /// 切换按钮，关闭按钮
        /// </summary>
        public Button cutButton, closeButton;

        public Image changeImage;
        public Sprite texture1, texture2;

        public  void InitUI()
        {
            //base.InitUI();
            Debug.Log("开始ContentUIPanel的初始化");
            cutButton= ResMgr.Instance.GetTarget<Button>("CutButton");
            closeButton = ResMgr.Instance.GetTarget<Button>("CloseButton");
            changeImage = ResMgr.Instance.GetTarget<Image>("Picture");
            cutButton.onClick.AddListener(OnCutButton);
            closeButton.onClick.AddListener(OnCloseButton);
            ResMgr.Instance.LoadByAddressable<Sprite>("睡觉");
            ResMgr.Instance.LoadByAddressable<Sprite>("1000");

            AllUIModel.Instance.ContentUIPanel.SetActive(false);
        }
        /// <summary>
        /// 切换按钮事件
        /// </summary>
        private void OnCutButton()
        {
            if (changeImage.sprite==texture1)
            {
                changeImage.sprite = texture2;
            }
            else
            {
                changeImage.sprite = texture1;
            }
            
        }
        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        private void OnCloseButton()
        {
            AllUIModel.Instance.MainUIPanel.SetActive(true);
            AllUIModel.Instance.ContentUIPanel.SetActive(false);
        }
    }
}
