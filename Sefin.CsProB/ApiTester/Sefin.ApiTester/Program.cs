﻿using GenericsPlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sefin.ApiTester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApiTesterApp());
        }

        static void Init() {
            new DelegatePlay();
            new LinqPlay.LinqPlayground();
        }
    }
}
