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
        public string Day1Weekday
        {
            get
            {
                return GetWeekdayOf(1);
            }
        }
        public string Day1Results
        {
            get
            {
                return GetResultsOf(1);
            }
        }
        public string Day1Comment
        {
            get
            {
                return GetCommentOf(1);
            }
        }

        public Color Day1Color
        {
            get
            {
                return GetColorOf(1);
            }
        }

        public string Day2Weekday
        {
            get
            {
                return GetWeekdayOf(2);
            }
        }
        public string Day2Results
        {
            get
            {
                return GetResultsOf(2);
            }
        }
        public string Day2Comment
        {
            get
            {
                return GetCommentOf(2);
            }
        }
        public Color Day2Color
        {
            get
            {
                return GetColorOf(2);
            }
        }

        public string Day3Weekday
        {
            get
            {
                return GetWeekdayOf(3);
            }
        }
        public string Day3Results
        {
            get
            {
                return GetResultsOf(1);
            }
        }
        public string Day3Comment
        {
            get
            {
                return GetCommentOf(1);
            }
        }
        public Color Day3Color
        {
            get
            {
                return GetColorOf(3);
            }
        }

        public string Day4Weekday
        {
            get
            {
                return GetWeekdayOf(4);
            }
        }
        public string Day4Results
        {
            get
            {
                return GetResultsOf(4);
            }
        }
        public string Day4Comment
        {
            get
            {
                return GetCommentOf(1);
            }
        }
        public Color Day4Color
        {
            get
            {
                return GetColorOf(4);
            }
        }

        public string Day5Weekday
        {
            get
            {
                return GetWeekdayOf(5);
            }
        }
        public string Day5Results
        {
            get
            {
                return GetResultsOf(5);
            }
        }
        public string Day5Comment
        {
            get
            {
                return GetCommentOf(1);
            }
        }
        public Color Day5Color
        {
            get
            {
                return GetColorOf(5);
            }
        }

        private string GetWeekdayOf(int day)
        {
            if (DataService.Days.Count - 1 >= 0)
            {
                return DataService.Days[DataService.Days.Count - 1].Weekday;
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetResultsOf(int day)
        {
            if (DataService.Days.Count - 1 >= 0)
            {
                return DataService.Days[DataService.Days.Count - 1].Results.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetCommentOf(int day)
        {
            if (DataService.Days.Count - 1 >= 0)
            {
                return DataService.Days[DataService.Days.Count - 1].Comments;
            }
            else
            {
                return string.Empty;
            }
        }

        private Color GetColorOf(int day)
        {
            if (DataService.Days.Count - 1 >= 0)
            {
                return DataService.Days[DataService.Days.Count - 1].Color;
            }
            else
            {
                return Color.Colors["Black"];
            }
        }
    }
}
