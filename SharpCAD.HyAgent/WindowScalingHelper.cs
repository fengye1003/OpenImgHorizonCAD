using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCAD.HyAgent
{
    internal class WindowScalingHelper
    {
        public float GetDeviceScaleFactor(Control control)
        {
            // 96 is Windows default scaling DPI（100% scale）
            float scalingFactor = (float)control.DeviceDpi / 96f;
            return scalingFactor;
        }

        public float GetDeviceScaleFactorSqrt(Control control)
        {
            // 96 is Windows default scaling DPI（100% scale）
            float scalingFactor = (float)Math.Sqrt((float)control.DeviceDpi / 96f);
            // Since a 'replace' to code will lead to operate scaling twice in some scenes, this method provide the sqrt value of a factor.
            return scalingFactor;
        }
    }
}
