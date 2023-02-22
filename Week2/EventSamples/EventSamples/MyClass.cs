using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSamples
{
    internal class MyClass
    {
        public event EventHandler XChanged;
        private void OnXChanged()
        {
            if (XChanged != null)
            {
                XChanged.Invoke(this, EventArgs.Empty);
            }
        }
        private int _x;
        public int X
        {
            get{ return _x; }
            set
            {
                // 若_x 的值改變了，則執行OnXChanged方法，讓XChanged事件去執行委派給他的方法們
                if (_x != value)
                {
                    _x = value;
                    OnXChanged();
                }
            }
        }
    }
}
