﻿using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace UI.Window
{
    public interface IWindowShowProcessor
    {
        UniTask Show(WindowView windowView, IList<WindowView> openedWindows, CancellationToken ct);
    }
}