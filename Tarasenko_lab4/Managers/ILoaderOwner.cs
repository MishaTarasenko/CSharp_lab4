using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tarasenko_lab4.Managers
{
    internal interface ILoaderOwner
    {
        public bool IsEnabled { get; set; }
        public Visibility LoaderVisibility { get; set; }
    }
}
