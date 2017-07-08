using RosaroterTigerWPF.Helpers;
using RosaroterTigerWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RosaroterTigerWPF.ViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        private ICommand _SaveReviewCommand;
        public ICommand SaveReviewCommand
        {
            get
            {
                if (_SaveReviewCommand == null)
                {
                    _SaveReviewCommand = new RelayCommand(
                        p => CanSaveReview,
                        p => this.SaveReview());
                }
                return _SaveReviewCommand;
            }
        }

        private Models.Day _SelectedDay;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public Models.Day SelectedDay
        {
            get
            {
                return _SelectedDay;
            }
            set
            {
                if (_SelectedDay != value)
                {
                    _SelectedDay = value;
                    this.OnPropertyChanged(nameof(SelectedDay));
                }
            }
        }

        private string _Comment;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                if (_Comment != value)
                {
                    _Comment = value;
                    this.OnPropertyChanged(nameof(Comment));
                }
            }
        }

        private object _MyProperty;
        /// <summary>
        /// [TODO: CodeDoc]
        /// </summary>
        public object MyProperty
        {
            get
            {
                return _MyProperty;
            }
            set
            {
                if (_MyProperty != value)
                {
                    _MyProperty = value;
                    this.OnPropertyChanged(nameof(MyProperty));
                }
            }
        }


        private void SaveReview()
        {
            SelectedDay.Comments = this.Comment;
        }

        public bool CanSaveReview { get; private set; }
    }
}
