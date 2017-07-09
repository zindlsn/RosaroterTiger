using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterTigerWPF.ViewModels
{
    class AddCommentViewModel
    {
        public AddCommentViewModel()
        { }

        public string Text { get; set; }

        public void Finish()
        {
            DataService.Today.Comments = Text;
        }
    }
}
