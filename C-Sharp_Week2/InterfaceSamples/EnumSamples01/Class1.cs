using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumSamples01
{
    //<summary>
    //自動從0開始
    //</summary>
    public enum MyWeekDays 
    {
        Sun, Mon, Tue, Wed, Thu, Fri, Sat
    }
    //<summary>
    //設定從1開始
    //</summary>
    public enum BrowserTypes
    { 
        IE = 1, Edge, Firefox, Chrom
    }
    //<summary>
    //全部值都手動設定
    //</summary>
    public enum SwitchTypes
    {
        On = 0, Off = 1
    }
}
