﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosaroterTigerWPF.ViewModels
{
    public class ColorPickerViewModel
    {
        public void PickColor(Color color)
        {
            DataService.Today.Color = color;
        }
    }
}
