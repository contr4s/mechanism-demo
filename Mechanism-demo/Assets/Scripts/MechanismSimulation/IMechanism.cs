﻿using System.Collections.Generic;

namespace MechanismSimulation
{
    public interface IMechanism
    {
        string Name { get; }
        IReadOnlyCollection<IMechanismPart> Parts { get; }
        float CameraFov { get; }
        bool BlastState { get; }

        void DoWork();
        void SwitchBlastState();
    }
}