﻿using System;
using XAI_BIBLE.AdminForms;
using System.Windows.Forms;

namespace XAI_BIBLE
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BookType());
        }
    }
}
