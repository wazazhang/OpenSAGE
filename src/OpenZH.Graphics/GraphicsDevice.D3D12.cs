﻿using OpenZH.Graphics.Platforms.Direct3D12;
using SharpDX.Direct3D12;

namespace OpenZH.Graphics
{
    partial class GraphicsDevice
    {
        internal Device Device { get; private set; }

        internal DescriptorTablePool DescriptorHeapCbvUavSrv { get; private set; }

        private void PlatformConstruct()
        {
#if DEBUG
            DebugInterface.Get().EnableDebugLayer();
#endif

            Device = AddDisposable(new Device(null, SharpDX.Direct3D.FeatureLevel.Level_11_0));

            DescriptorHeapCbvUavSrv = AddDisposable(new DescriptorTablePool(
                Device,
                DescriptorHeapType.ConstantBufferViewShaderResourceViewUnorderedAccessView,
                1_000_000)); // Maximum descriptor count for Tier 1 hardware
        }
    }
}