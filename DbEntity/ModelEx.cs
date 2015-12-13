using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DbEntity {
    /// <summary>
    /// 菜单项实体数据定义
    /// </summary>
    [Serializable]
    public class MenuData {
        public string MenuGrpName { get; set; }
        /// <summary>
        /// 菜单类名
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUsing { get; set; }

        /// <summary>
        /// 菜单数据
        /// </summary>
        public List<MenuItemData> MenuItems { get; set; }
    }

    [Serializable]
    public class MenuItemData {
        /// <summary>
        /// 菜单组名
        /// </summary>
        public string MenuGrpName { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public string MenuName { get; set; }


        public string AreaName { get; set; }

        /// <summary>
        /// 菜单类名
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 菜单程序集名
        /// </summary>
        public string ActionName { get; set; }
        public string MenuUrl { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUsing { get; set; }

    }

    public enum EnCtlType : int {
        Undefine = 0,

        /// <summary>
        /// 工具栏
        /// </summary>
        [Description("主按钮")]
        ToolButtons = 1,

        /// <summary>
        /// 网格
        /// </summary>
        [Description("网格")]
        Tables = 2,


        /// <summary>
        /// 自定义按钮
        /// </summary>
        [Description("自定义按钮")]
        CustButtons = 4,

        /// <summary>
        /// 网格列
        /// </summary>
        [Description("网格列")]
        TableColumn = 5,
    }

    [Serializable]
    public class MenuCtlData {
        public EnCtlType CtlType { get; set; }
        public string ControlName { get; set; }
        public bool IsEnabled { get; set; }
        public string TextName { get; set; }
        public string ClsName { get; set; }
        public string AsmName { get; set; }
        public string AsmMD5 { get; set; }
        public string ParentCtlName { get; set; }
        public string MenuGrpName { get; set; }
        public string MenuName { get; set; }
    }

}

namespace PetaPoco {
    public partial class Page<T> {
        public Pager Pager {
            get {
                return new Pager() {
                    CurrentPage = this.CurrentPage,
                    TotalPages= TotalPages,
                    TotalItems= TotalItems,
                    ItemsPerPage= ItemsPerPage
                };
            }
        }
    }

    public class Pager {
        public long CurrentPage {
            get;
            set;
        }
        public long TotalPages {
            get;
            set;
        }
        
        public long TotalItems {
            get;
            set;
        }
        public long ItemsPerPage {
            get;
            set;
        }
    }
}
