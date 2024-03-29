﻿using System;

namespace XamarinOnCrack.Models.UserInterface
{
    public interface IViewModel
    {
        IWorkspace Workspace { get; set; }
        void PopView();
        void PushView(IViewModel viewModel);
    }
}