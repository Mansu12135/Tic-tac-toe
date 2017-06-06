using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyApplication
{
    interface IMadeMovingEngine
    {
        int MakeMove(List<TicTacToe> list);
    }
}
