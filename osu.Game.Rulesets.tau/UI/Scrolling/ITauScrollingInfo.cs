using osu.Framework.Bindables;
using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Game.Rulesets.Tau.UI.Scrolling
{
    public class ITauScrollingInfo
    {
        /// <summary>
        /// The direction <see cref="HitObject"/>s should scroll in.
        /// </summary>
        IBindable<TauScrollingDirection> Direction { get; }

        /// <summary>
        ///
        /// </summary>
        IBindable<double> TimeRange { get; }

        /// <summary>
        /// The algorithm which controls <see cref="HitObject"/> positions and sizes.
        /// </summary>
        ITauScrollAlgorithm Algorithm { get; }
    }
}
