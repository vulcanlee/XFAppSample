using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCreative.Models
{
    public class 創業空間NodeViewModel : BindableBase
    {
        #region 創業空間名稱
        private string _創業空間名稱;
        public string 創業空間名稱
        {
            get { return _創業空間名稱; }
            set { SetProperty(ref _創業空間名稱, value); }
        }
        #endregion

        #region 空間主照片
        private string _空間主照片;

        public string 空間主照片
        {
            get { return _空間主照片; }
            set { SetProperty(ref _空間主照片, value); }
        }
        #endregion

        #region 使用坪數
        private string _使用坪數;

        public string 使用坪數
        {
            get { return _使用坪數; }
            set { SetProperty(ref _使用坪數, value); }
        }
        #endregion

        #region 地址
        private string _地址;

        public string 地址
        {
            get { return _地址; }
            set { SetProperty(ref _地址, value); }        }

        #endregion
    }


}
