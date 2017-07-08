using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterPanterWPF
{
    public class MainViewModel : BaseViewModel
    {
        private string _Title;

        public string Title
        {
            get {
                return _Title;
            }
            set
            {
                if(_Title != value)
                {
                    _Title = value;
                }
            }
        }


    }
}
