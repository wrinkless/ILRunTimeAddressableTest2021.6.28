using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFix_Project.UI
{
    /// <summary>
    /// 主要是存放各种UIPanel的实例
    /// </summary>
    class AllUIModel : HotFixSingleton<AllUIModel>
    {
        /// <summary>
        /// 主页面的panel，内容页面的panel
        /// </summary>
        public GameObject MainUIPanel, ContentUIPanel;
        public AllUIModel()
        {
            MainUIPanel = new GameObject();
            ContentUIPanel = new GameObject();
        }
    }
}
